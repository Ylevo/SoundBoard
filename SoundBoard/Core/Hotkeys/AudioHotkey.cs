using System;
using System.Windows.Forms;

namespace SoundBoard.Core
{
    public class AudioHotkey : Hotkey, IHotkey
    {
        public AudioHotkey(KeyAndModifiers fullKey, Guid audioDevice, string files, float volume, int timeStart = 0, string name = "")
            : base(fullKey)
        {
            this.AudioDevice = audioDevice;
            this.Files = files;
            this.StartingTime = timeStart;
            this.Name = name;
            this.Volume = volume;
        }

        public AudioHotkey(string fullKey, Guid audioDevice, string files, float volume, int timeStart = 0, string name = "")
            : base(fullKey)
        {
            this.AudioDevice = audioDevice;
            this.Files = files;
            this.StartingTime = timeStart;
            this.Name = name;
            this.Volume = volume;
        }

        public Guid AudioDevice { get; set; }

        public string Files { get; set; }

        public int StartingTime { get; set; }

        public string Name { get; set; }

        public float Volume { get; set; }

        public override int Register(Control windowControl)
        {
            int result;
            result = base.Register(windowControl);
            if (result == 1)
            {
                if (IsPressedEventNull())
                {
                    base.Pressed += delegate { SoundPlayer.Instance.PlaySound(this.Files, this.AudioDevice, this.StartingTime, this.Volume); };
                }
            }
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + " | Type : Audio Hotkey" + " | Name : " + Name + " | Audio Device : " + AudioDevice.ToString() + " | Files : " + Files + " | Time Start : " + StartingTime + " | Volume : " + Volume;
        }
    }

}
