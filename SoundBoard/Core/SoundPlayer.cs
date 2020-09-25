using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;
using System.IO;
using SoundBoard.Persistence;
using SoundBoard.Helpers;

namespace SoundBoard.Core
{
    public enum TracksOrders { Default, Shuffle, Random }
    public enum CustomPlayBackState { Playing, Pausing, Stopping, Paused, Stopped }
    public enum FadeState { Silence, FadingIn, FullVolume, FadingOut }
    public enum FadingActions { StartSound, Stop, PlayPause, ForwardBackward }
    public enum ControlRoles { Forward, Backward, PlayPause, Stop, HoldDownKey, MasterHotkey, IncreaseVolume, DecreaseVolume, Mute, IncreaseTempo, DecreaseTempo, IncreasePitch, DecreasePitch, IncreaseSpeed, DecreaseSpeed, ResetRates, AutoRepeat, None }
    public enum ControlRolesData { TimeValue, VolumeValue, PitchTempoValue, PressWhichKey, None }

    public sealed class SoundPlayer
    {
        private static readonly SoundPlayer instance = new SoundPlayer();
        
        private IWavePlayer waveOutDevice = null, fadingOutWaveOutDevice = null;
        private AudioFileReader audioFileReader = null, fadingOutAudioFileReader = null;
        private CustomSampleProvider sampleProvider = null, fadingOutSampleProvider = null;
        private SoundTouch soundTouch = null, fadingOutSoundTouch = null;
        private float currentTempo = 1.0f, currentPitch = 0.0f, currentSpeed = 1.0f, currentVolume = 1.0f;
        private bool muted = false, autoRepeat = false;
        private readonly Dictionary<FadingActions, Dictionary<string, int>> fadingValues = new Dictionary<FadingActions, Dictionary<string, int>>()
        {
            { FadingActions.StartSound, new Dictionary<string, int>() { {"fadeIn", 0 }, { "fadeOut", 0 } } },
            { FadingActions.Stop, new Dictionary<string, int>() { {"fadeIn", 0 }, { "fadeOut", 0 } } },
            { FadingActions.PlayPause, new Dictionary<string, int>() { {"fadeIn", 0 }, { "fadeOut", 0 } } },
            { FadingActions.ForwardBackward, new Dictionary<string, int>() { {"fadeIn", 0 }, { "fadeOut", 0 } } }
        };
        private Guid currentAudioDevice = Guid.Empty;
        private string currentTrackPlayed = "", currentTracksList = "";
        private CustomPlayBackState playbackState = CustomPlayBackState.Stopped;
        private TracksOrders tracksPlayOrder = TracksOrders.Default;
        private string[] tracksOrdered = null;
        private int nextTrack;
        private readonly NotifyIcon notificator = new NotifyIcon();

        static SoundPlayer() { }

        private SoundPlayer()
        {
            notificator.Visible = true;
            notificator.Icon = Properties.Resources.soundboard_logo_icone;
            notificator.BalloonTipIcon = ToolTipIcon.Info;
        }

        public static SoundPlayer Instance { get { return instance; } }

        public bool ResetMusicRates { get; set; } = false;
        public bool ResetAutoRepeat { get; set; } = true;

        public int AudioLatency { get; set; } = 50;

        public TracksOrders TracksPlayOrder
        {
            get { return tracksPlayOrder; }
            set { tracksPlayOrder = value; tracksOrdered = null; }
        }

        public NotifyIcon Notificator { get { return notificator; } }

        public void CloseWaveOut()
        {
            try
            {
                if (waveOutDevice != null)
                {
                    waveOutDevice.Stop();
                    playbackState = CustomPlayBackState.Stopped;
                }
                if (sampleProvider != null)
                {
                    sampleProvider.Dispose();
                    sampleProvider = null;
                    audioFileReader = null;
                }
                if (waveOutDevice != null)
                {
                    waveOutDevice.Dispose();
                    waveOutDevice = null;
                }
            }
            catch { }
        }

        private void SetSoundTouchSettings(SoundTouch soundTouch, AudioFileReader audioFileReader, bool preventReset = false)
        {
            soundTouch.SetSampleRate(audioFileReader.WaveFormat.SampleRate);
            soundTouch.SetChannels(audioFileReader.WaveFormat.Channels);
            if (ResetMusicRates && !preventReset)
            {
                currentPitch = 0.0f;
                currentTempo = 1.0f;
                currentSpeed = 1.0f;
            }
            soundTouch.SetPitchSemiTones(currentPitch);
            soundTouch.SetTempo(currentTempo);
            soundTouch.SetRate(currentSpeed);
            soundTouch.SetUseAntiAliasing(true);
        }

        public void PlaySound(string files, Guid audioDevice, int timeStart, float volume)
        {
            try
            {
                if (!CheckFiles(files))
                {
                    throw new AudioFileMissingOrInvalidException(files);
                }
                StopSound(true);
                // files' paths separated by a *
                if (files.Contains("*"))
                {
                    if (tracksOrdered == null || currentTracksList != files)
                    {
                        currentTracksList = files;
                        OrderTracks();
                    }
                    files = GetTrack();
                }
                else
                {
                    tracksOrdered = null;
                }
                audioFileReader = new AudioFileReader(files);
                currentTrackPlayed = files;
                waveOutDevice = new DirectSoundOut(audioDevice, AudioLatency);
                currentAudioDevice = audioDevice;
                currentVolume = volume;
                audioFileReader.Volume = muted ? 0.0f : currentVolume;
                soundTouch = new SoundTouch();
                SetSoundTouchSettings(soundTouch, audioFileReader);
                if (ResetAutoRepeat) { autoRepeat = false; }
                sampleProvider = new CustomSampleProvider(audioFileReader, soundTouch, autoRepeat);
                waveOutDevice.Init(sampleProvider);
                if (timeStart > 0 && timeStart < audioFileReader.TotalTime.TotalSeconds)
                {
                    audioFileReader.Skip(timeStart);
                    sampleProvider.StartingTime = timeStart;
                }
                int fadeInTime = fadingValues[FadingActions.StartSound]["fadeIn"];
                if (fadeInTime > 0)
                {
                    sampleProvider.BeginFadeIn(fadeInTime);
                }
                waveOutDevice.Play(); 
                playbackState = CustomPlayBackState.Playing;
                NewNotification("Playing :", files);
            }
            catch (AudioFileMissingOrInvalidException ex)
            {
                MessageBox.Show(ex.MessageToUser, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ErrorHelper.UnexpectedErrorPlayback, files), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.NewLog(ex, string.Format("Unknown playback Error. Files : \"{0}\" | Guid : \"{1}\" | Timestart : \"{2}\" | Volume : \"{3}\".", files, audioDevice.ToString(), timeStart, volume));
            }
        }

        public void SkipSound(int timeValue)
        {
            try
            {
                if (audioFileReader != null && playbackState == CustomPlayBackState.Playing && waveOutDevice.PlaybackState == PlaybackState.Playing)
                {
                    int fadeOutTime, fadeInTime;
                    fadeOutTime = fadingValues[FadingActions.ForwardBackward]["fadeOut"];
                    fadeInTime = fadingValues[FadingActions.ForwardBackward]["fadeIn"];
                    if (fadeOutTime > 0)
                    {
                        DoSeekFadeOut(fadeOutTime);
                    }
                    audioFileReader.Skip(timeValue);
                    if (fadeInTime > 0)
                    {
                        sampleProvider.BeginFadeIn(fadeInTime);
                    }
                }
            }
            catch (Exception ex) { Logger.NewLog(ex); }
        }

        public void DoSeekFadeOut(int fadeOutTime)
        {
            if (fadingOutWaveOutDevice != null)
            {
                fadingOutWaveOutDevice.Stop();
            }
            if (playbackState == CustomPlayBackState.Playing)
            {
                fadingOutAudioFileReader = new AudioFileReader(currentTrackPlayed)
                {
                    Volume = audioFileReader.Volume,
                    Position = audioFileReader.Position
                };
                fadingOutSoundTouch = new SoundTouch();
                SetSoundTouchSettings(fadingOutSoundTouch, fadingOutAudioFileReader, true);
                fadingOutSampleProvider = new CustomSampleProvider(fadingOutAudioFileReader, fadingOutSoundTouch);
                fadingOutWaveOutDevice = new DirectSoundOut(currentAudioDevice, AudioLatency);
                fadingOutWaveOutDevice.Init(fadingOutSampleProvider);
                IWavePlayer thisFadingOutWave = fadingOutWaveOutDevice;
                CustomSampleProvider thisFadeOutSampleProvider = fadingOutSampleProvider;
                thisFadingOutWave.PlaybackStopped += delegate { thisFadeOutSampleProvider.Dispose(); thisFadingOutWave.Dispose(); fadingOutWaveOutDevice = null; };
                thisFadingOutWave.Play();
                fadingOutSampleProvider.BeginFadeOut(fadeOutTime, thisFadingOutWave);
            }
        }

        public void PausePlaySound()
        {
            if (IsMusicPlaying())
            {               
                switch (playbackState)
                {
                    case CustomPlayBackState.Playing:
                        int fadeOutTime = fadingValues[FadingActions.PlayPause]["fadeOut"];
                        if (fadeOutTime > 0)
                        {                     
                            playbackState = CustomPlayBackState.Pausing;
                            sampleProvider.BeginFadeOut(fadeOutTime);
                            PauseAndExecuter.Execute(delegate
                            {
                                if (playbackState == CustomPlayBackState.Pausing)
                                {
                                    waveOutDevice.Pause();
                                    playbackState = CustomPlayBackState.Paused;
                                }
                            }, fadeOutTime + 100);
                        }
                        else
                        {
                            waveOutDevice.Pause();
                            playbackState = CustomPlayBackState.Paused;
                        }
                        NewNotification("Paused :", currentTrackPlayed);
                        break;
                    case CustomPlayBackState.Pausing:
                        PauseAndExecuter.AbortLast();
                        goto case CustomPlayBackState.Paused;
                    case CustomPlayBackState.Paused:
                        playbackState = CustomPlayBackState.Playing;
                        int fadeInTime = fadingValues[FadingActions.PlayPause]["fadeIn"];
                        if (fadeInTime > 0)
                        {
                            sampleProvider.BeginFadeIn(fadeInTime);
                        }
                        else
                        {
                            sampleProvider.FadeState = FadeState.FullVolume;
                        }
                        waveOutDevice.Play();
                        NewNotification("Unpaused :", currentTrackPlayed);
                        break;
                }
            }
        }

        public void StopSound(bool fromNewSound = false)
        {
            if (IsMusicPlaying())
            {
                int fadeOutTime = fromNewSound ? fadingValues[FadingActions.StartSound]["fadeOut"] : fadingValues[FadingActions.Stop]["fadeOut"];
                switch (playbackState)
                {
                    case CustomPlayBackState.Pausing:
                        PauseAndExecuter.AbortLast();
                        goto case CustomPlayBackState.Playing;
                    case CustomPlayBackState.Playing:
                        if (fadeOutTime > 0)
                        {
                            IWavePlayer currentWaveOut = waveOutDevice;
                            CustomSampleProvider currentProvider = sampleProvider;
                            playbackState = CustomPlayBackState.Stopping;
                            currentWaveOut.PlaybackStopped += delegate 
                            {
                                if (playbackState == CustomPlayBackState.Stopping)
                                {
                                    playbackState = CustomPlayBackState.Stopped;
                                }
                                currentProvider.Dispose();
                                currentWaveOut.Dispose();
                            };
                            sampleProvider.BeginFadeOut(fadeOutTime, currentWaveOut);
                        }
                        else
                        {
                            CloseWaveOut();
                        }
                        break;
                    case CustomPlayBackState.Paused:
                        CloseWaveOut();
                        break;
                }
            }
        }

        public void OrderTracks()
        {
            string[] tracksArray = currentTracksList.Split('*');

            switch (tracksPlayOrder)
            {
                case TracksOrders.Default:
                case TracksOrders.Random:
                    tracksOrdered = tracksArray;
                    break;
                case TracksOrders.Shuffle:
                    int k, i = tracksArray.Length;
                    string temp;
                    while (i > 1)
                    {
                        k = new Random().Next(i--);
                        temp = tracksArray[i];
                        tracksArray[i] = tracksArray[k];
                        tracksArray[k] = temp;
                    }
                    tracksOrdered = tracksArray;
                    break;
            }
            nextTrack = 0;
        }

        public bool CheckFiles(string mp3String)
        {
            bool allGood = true;
            string[] mp3s;
            mp3s = mp3String.Split('*');
            string[] supportedFormats = { ".mp3", ".wav" };
            foreach (string mp3Path in mp3s)
            {
                if (!File.Exists(mp3Path) || !supportedFormats.Contains(Path.GetExtension(mp3Path).ToLower()))
                {
                    allGood = false;
                    break;
                }
            }
            return allGood;
        }

        public string GetTrack()
        {
            string track;
            if (tracksPlayOrder == TracksOrders.Random)
            {
                track = tracksOrdered[new Random().Next(tracksOrdered.Length)];
            }
            else
            {
                if (nextTrack == tracksOrdered.Length) nextTrack = 0;
                track = tracksOrdered[nextTrack++];
            }
            return track;
        }

        public void ChangeVolume(float volume)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Volume = volume;
            }
        }

        public void IncreaseDecreaseTempo(float tempoValue)
        {
            currentTempo += tempoValue;
            if (currentTempo > 10.0f)
            {
                currentTempo = 10.0f;
            }
            if (currentTempo < 0.15)
            {
                currentTempo = 0.15f;
            }
            if (IsMusicPlaying())
            {
                soundTouch.SetTempo(currentTempo);
            }
        }

        public void IncreaseDecreasePitch(float pitchValue)
        {
            currentPitch += pitchValue;
            if (currentPitch > 20f)
            {
                currentPitch = 20f;
            }
            if (currentPitch < -20f)
            {
                currentPitch = -20f;
            }
            if (IsMusicPlaying())
            {
                soundTouch.SetPitchSemiTones(currentPitch);
            }
        }

        public void IncreaseDecreaseSpeed(float speedValue)
        {
            currentSpeed += speedValue;
            if (currentSpeed > 10.0f)
            {
                currentSpeed = 10.0f;
            }
            if (currentSpeed < 0.15)
            {
                currentSpeed = 0.15f;
            }
            if (IsMusicPlaying())
            {
                soundTouch.SetRate(currentSpeed);
            }
        }

        public void IncreaseDecreaseVolume(float volumeValue)
        {
            currentVolume += volumeValue;
            if (currentVolume <= 0.0f)
            {
                currentVolume = 0.0f;
            }
            else
            {
                if (currentVolume >= 1.0f)
                {
                    currentVolume = 1.0f;
                }
            }
            if (IsMusicPlaying() && !muted)
            {
                audioFileReader.Volume = currentVolume;
            }
        }

        public void MuteSound()
        {
            if (IsMusicPlaying())
            {
                if (muted)
                {
                    audioFileReader.Volume = currentVolume;
                }
                else
                {
                    audioFileReader.Volume = 0.0f;
                }
                muted = !muted;
            }
        }

        public void ResetRates()
        {
            currentPitch = 0.0f;
            currentTempo = 1.0f;
            currentSpeed = 1.0f;
            if (IsMusicPlaying())
            {
                soundTouch.SetPitchSemiTones(currentPitch);
                soundTouch.SetTempo(currentTempo);
                soundTouch.SetRate(currentSpeed);
            }
        }

        public void SwitchAutoRepeat()
        {
            autoRepeat = !autoRepeat;
            if (IsMusicPlaying())
            {
                sampleProvider.AutoRepeat = autoRepeat;
            }
        }

        public bool IsMusicPlaying()
        {
            return playbackState != CustomPlayBackState.Stopped;
        }

        public void ChangeFadingValue(FadingActions fadeAction, string fadeType, int fadeDurationValue)
        {
            fadingValues[fadeAction][fadeType] = fadeDurationValue;
        }

        public int GetFadingValue(FadingActions fadeAction, string fadeType)
        {
            return fadingValues[fadeAction][fadeType];
        }
        
        private void NewNotification(string state, string file)
        {
            if (notificator.Visible)
            {
                notificator.BalloonTipTitle = "SoundBoard - " + state;
                notificator.BalloonTipText = file.Split('\\').Last();
                notificator.ShowBalloonTip(3000);
            }
        }
    }

}
