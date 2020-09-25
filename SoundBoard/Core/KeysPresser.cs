using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace SoundBoard.Core
{
    class KeysPresser
    {
        #region Interop
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendInput(uint cInputs, ref Input inputs, int cbSize);
        [DllImport("user32.dll")]
        static extern IntPtr GetMessageExtraInfo();
        #endregion

        [StructLayout(LayoutKind.Explicit)]
        private struct ShortHelper
        {
            [FieldOffset(0)]
            public short Value;
            [FieldOffset(0)]
            public byte Low;
            [FieldOffset(1)]
            public byte High;
        }

        [StructLayout(LayoutKind.Explicit, Size = 28)]
        private struct Input
        {
            [FieldOffset(0)]
            public uint type;
            [FieldOffset(4)]
            public KeyboardInput ki;
        }

        private struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public long time;
            public IntPtr dwExtraInfo;
        }

        private const int KEYEVENTF_KEYUP = 0x0002;
        private const int KEYEVENTF_SCANCODE = 0x0008;
        private const int INPUT_KEYBOARD = 1;
        private const ushort VK_SHIFT = 0x10;
        private const ushort VK_CTRL = 0x11;
        private const ushort VK_ALT = 0x12;
        private readonly KeysTranslater keysTranslater = new KeysTranslater();

        /// <summary>
        /// Press once and hold down or release a key along with its modifiers. The order in which the modifiers are pressed is : alt -> shift -> ctrl. Not recommended.
        /// </summary>
        /// <param name="kc">Key to press or release.</param>
        /// <param name="alt">Alt modifier.</param>
        /// <param name="ctrl">Ctrl modifier.</param>
        /// <param name="shift">Shift modifier.</param>
        public void PressKeyAndModifiers(Keys kc, bool alt, bool ctrl, bool shift)
        {
            if (alt)
            {
                PressKey((Keys)VK_ALT);
            }
            if (shift)
            {
                PressKey((Keys)VK_SHIFT);
            }
            if (ctrl)
            {
                PressKey((Keys)VK_CTRL);
            }

            PressKey(kc);
        }
        /// <summary>
        /// Press once and hold down or release a key. The current state of the key is checked beforehand to determine whether it will be pressed or released.
        /// </summary>
        /// <param name="kc">Key to press or release.</param>
        public void PressKey(Keys kc)
        {
            uint flags = KEYEVENTF_SCANCODE;
            if (System.Windows.Input.Keyboard.IsKeyDown(KeyInterop.KeyFromVirtualKey((int)kc))) { flags = flags |= KEYEVENTF_KEYUP; }
            Input input = CreateNewInput((ushort)keysTranslater.KeyCodeToScanCode(kc), flags);
            SendInput(1, ref input, Marshal.SizeOf(typeof(Input)));
        }

        /// <summary>
        /// Create and return a new Input object for the PressKey method.
        /// </summary>
        /// <param name="scanCode">Hardware scancode of they key concerned.</param>
        /// <param name="flags">Specifies various aspects of the keystroke.</param>
        private Input CreateNewInput(ushort scanCode, uint flags)
        {
            Input newInput = new Input
            {
                type = INPUT_KEYBOARD
            };
            newInput.ki.wScan = scanCode;
            newInput.ki.dwFlags = flags;
            newInput.ki.time = 0;
            newInput.ki.dwExtraInfo = GetMessageExtraInfo();
            return newInput;
        }
    }
}
