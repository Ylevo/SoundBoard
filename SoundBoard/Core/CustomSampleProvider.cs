using System;
using NAudio.Wave;

namespace SoundBoard.Core
{
    public class CustomSampleProvider : ISampleProvider, IDisposable
    {
        private readonly object lockObject = new object();
        private AudioFileReader source;
        private SoundTouch soundTouch;
        private int fadeSamplePosition, fadeSampleCount;
        private bool isDisposed = false;
        private readonly float[] sourceReadBuffer, soundTouchReadBuffer;
        private readonly int channelCount;
        private IWavePlayer playerToStop = null;
        public FadeState FadeState { get; set; }
        public bool AutoRepeat { get; set; }
        public int StartingTime { get; set; }

        /// <summary>
        /// Creates a new CustomSampleProvider
        /// </summary>
        /// <param name="source">The source stream with the audio to be faded in or out</param>
        public CustomSampleProvider(AudioFileReader source, SoundTouch soundTouch, bool autoRepeat = false, int startingTime = 0)
        {
            this.source = source;
            this.FadeState = FadeState.FullVolume;
            AutoRepeat = autoRepeat;
            this.soundTouch = soundTouch;
            this.channelCount = source.WaveFormat.Channels;
            this.StartingTime = startingTime;
            sourceReadBuffer = new float[(WaveFormat.SampleRate * channelCount * (long)100) / 1000];
            soundTouchReadBuffer = new float[sourceReadBuffer.Length * 10]; // support down to 0.1 speed
        }

        /// <summary>
        /// WaveFormat of this SampleProvider
        /// </summary>
        public WaveFormat WaveFormat
        {
            get { return source.WaveFormat; }
        }

        /// <summary>
        /// Requests that a fade-in begins (will start on the next call to Read)
        /// </summary>
        /// <param name="fadeDurationInMilliseconds">Duration of fade in milliseconds</param>
        public void BeginFadeIn(double fadeDurationInMilliseconds)
        {
            lock (lockObject)
            {
                fadeSamplePosition = 0;
                fadeSampleCount = (int)((fadeDurationInMilliseconds * source.WaveFormat.SampleRate) / 1000);
                FadeState = FadeState.FadingIn;
            }
        }

        /// <summary>
        /// Requests that a fade-out begins (will start on the next call to Read)
        /// </summary>
        /// <param name="fadeDurationInMilliseconds">Duration of fade in milliseconds</param>
        public void BeginFadeOut(double fadeDurationInMilliseconds, IWavePlayer playerToStop = null)
        {
            lock (lockObject)
            {
                fadeSamplePosition = 0;
                fadeSampleCount = (int)((fadeDurationInMilliseconds * source.WaveFormat.SampleRate) / 1000);

                FadeState = FadeState.FadingOut;
                this.playerToStop = playerToStop;
            }
        }
        
        /// <summary>
        /// Reads samples from this sample provider
        /// </summary>
        /// <param name="buffer">Buffer to read into</param>
        /// <param name="offset">Offset within buffer to write to</param>
        /// <param name="count">Number of samples desired</param>
        /// <returns>Number of samples read</returns>
        public int Read(float[] buffer, int offset, int count)
        {
            if (isDisposed)
            {
                return 0;
            }
            int samplesRead = 0;
            while (samplesRead < count)
             {
                 if (soundTouch.NumberOfSamplesAvailable == 0)
                 {
                     var readFromSource = source.Read(sourceReadBuffer, 0, sourceReadBuffer.Length);
                     if (readFromSource > 0)
                     {
                         soundTouch.PutSamples(sourceReadBuffer, readFromSource / channelCount);
                     }
                     else
                     {
                         soundTouch.Flush();
                     }
                 }
                 var desiredSampleFrames = (count - samplesRead) / channelCount;

                 var received = soundTouch.ReceiveSamples(soundTouchReadBuffer, desiredSampleFrames) * channelCount;
                 // use loop instead of Array.Copy due to WaveBuffer
                 for (int n = 0; n < received; n++)
                 {
                     buffer[offset + samplesRead++] = soundTouchReadBuffer[n];
                 }
             }

             if (AutoRepeat && source.Length == source.Position)
             {
                 source.Position = 0;
                 source.Skip(StartingTime);
                 soundTouch.ReceiveSamples(soundTouchReadBuffer, soundTouch.NumberOfSamplesAvailable);
             }

             lock (lockObject)
             {
                 if (FadeState == FadeState.FadingIn)
                 {
                     FadeIn(buffer, offset, samplesRead);
                 }
                 else if (FadeState == FadeState.FadingOut)
                 {
                     FadeOut(buffer, offset, samplesRead);
                 }
                 else if (FadeState == FadeState.Silence)
                 {
                     ClearBuffer(buffer, offset, count);
                     playerToStop?.Stop();
                 }
             }
             return samplesRead;
        }

        private static void ClearBuffer(float[] buffer, int offset, int count)
        {
            for (int n = 0; n < count; n++)
            {
                buffer[n + offset] = 0;
            }
        }

        private void FadeOut(float[] buffer, int offset, int sourceSamplesRead)
        {
            int sample = 0;
            while (sample < sourceSamplesRead)
            {
                float multiplier = 1.0f - (fadeSamplePosition / (float)fadeSampleCount);
                for (int ch = 0; ch < source.WaveFormat.Channels; ch++)
                {
                    buffer[offset + sample++] *= multiplier;
                }
                fadeSamplePosition++;
                if (fadeSamplePosition > fadeSampleCount)
                {
                    FadeState = FadeState.Silence;
                    // clear out the end
                    ClearBuffer(buffer, sample + offset, sourceSamplesRead - sample);
                    break;
                }
            }
        }

        private void FadeIn(float[] buffer, int offset, int sourceSamplesRead)
        {
            int sample = 0;
            while (sample < sourceSamplesRead)
            {
                float multiplier = (fadeSamplePosition / (float)fadeSampleCount);
                for (int ch = 0; ch < source.WaveFormat.Channels; ch++)
                {
                    buffer[offset + sample++] *= multiplier;
                }
                fadeSamplePosition++;
                if (fadeSamplePosition > fadeSampleCount)
                {
                    FadeState = FadeState.FullVolume;
                    break;

                }
            }
        }

        public void Dispose()
        {
            source.Dispose();
            soundTouch.Dispose();
            source = null;
            soundTouch = null;
            isDisposed = true;
        }
       
    }

}
