using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace SoundBoard.Core
{
    public class ControlHotkey : Hotkey, IHotkey
    {
        public ControlHotkey() { }

        public ControlHotkey(KeyAndModifiers fullKey, ControlRoles role)
            : base(fullKey)
        {
            this.Role = role;
        }

        public ControlHotkey(string fullKey, ControlRoles role)
            : base(fullKey)
        {
            this.Role = role;
        }

        private static KeysPresser keysPresser = new KeysPresser();
        public ControlRoles Role { get; set; }
        public float FlowChangeValue { get; set; }
        public Keys HoldDownKey { get; set; }

        public override int Register(Control windowControl)
        {
            int result;
            result = base.Register(windowControl);
            if (result == 1)
            {
                if (IsPressedEventNull())
                {
                    switch (Role)
                    {
                        case ControlRoles.Forward:
                            base.Pressed += delegate { SoundPlayer.Instance.SkipSound((int)FlowChangeValue); };
                            break;
                        case ControlRoles.Backward:
                            base.Pressed += delegate { SoundPlayer.Instance.SkipSound(0 - (int)FlowChangeValue); };
                            break;
                        case ControlRoles.PlayPause:
                            base.Pressed += delegate { SoundPlayer.Instance.PausePlaySound(); };
                            break;
                        case ControlRoles.Stop:
                            base.Pressed += delegate { SoundPlayer.Instance.StopSound(); };
                            break;
                        case ControlRoles.Mute:
                            base.Pressed += delegate { SoundPlayer.Instance.MuteSound(); };
                            break;
                        case ControlRoles.HoldDownKey:
                            base.Pressed += delegate { keysPresser.PressKey(HoldDownKey); };
                            break;
                        case ControlRoles.IncreaseVolume:
                            base.Pressed += delegate { SoundPlayer.Instance.IncreaseDecreaseVolume(FlowChangeValue / 100); };
                            break;
                        case ControlRoles.DecreaseVolume:
                            base.Pressed += delegate { SoundPlayer.Instance.IncreaseDecreaseVolume(FlowChangeValue / -100); };
                            break;
                        case ControlRoles.IncreaseTempo:
                            base.Pressed += delegate { SoundPlayer.Instance.IncreaseDecreaseTempo(FlowChangeValue / 100); };
                            break;
                        case ControlRoles.DecreaseTempo:
                            base.Pressed += delegate { SoundPlayer.Instance.IncreaseDecreaseTempo(FlowChangeValue / -100); };
                            break;
                        case ControlRoles.IncreasePitch:
                            base.Pressed += delegate { SoundPlayer.Instance.IncreaseDecreasePitch(FlowChangeValue / 10); };
                            break;
                        case ControlRoles.DecreasePitch:
                            base.Pressed += delegate { SoundPlayer.Instance.IncreaseDecreasePitch(FlowChangeValue / -10); };
                            break;
                        case ControlRoles.IncreaseSpeed:
                            base.Pressed += delegate { SoundPlayer.Instance.IncreaseDecreaseSpeed(FlowChangeValue / 100); };
                            break;
                        case ControlRoles.DecreaseSpeed:
                            base.Pressed += delegate { SoundPlayer.Instance.IncreaseDecreaseSpeed(FlowChangeValue / -100); };
                            break;
                        case ControlRoles.ResetRates:
                            base.Pressed += delegate { SoundPlayer.Instance.ResetRates(); };
                            break;
                        case ControlRoles.AutoRepeat:
                            base.Pressed += delegate { SoundPlayer.Instance.SwitchAutoRepeat(); };
                            break;
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + " | Type : Control Hotkey | Role : " + Role.ToString();
        }
    }

}
