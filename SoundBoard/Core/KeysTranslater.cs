using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SoundBoard.Core
{
    interface IKeysTranslater
    {
        Keys CharToKeyCode(char ch);
        Keys StringToKeyCode(string str);
        string KeyCodeToString(Keys kc);
        uint ScanCodeToKeyCode(uint scanCode);
        uint KeyCodeToScanCode(Keys kc);
        Keys ReMapKey(short originalKeyboardLayoutId, string key);
        Keys ReMapKey(short originalKeyboardLayoutId,Keys keyCode);
        short GetCurrentKeyboardLayoutIdentifier();
        void SetKeyboardLayout(short keyboardLayout = 0);
    }


    public class KeysTranslater : IKeysTranslater
    {
        #region Interop

        [DllImport("user32.dll")]
        static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);
        [DllImport("user32.dll")]
        static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[]
           lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff,
           int cchBuff, uint wFlags, IntPtr dwhkl);
        [DllImport("user32.dll")]
        static extern IntPtr GetKeyboardLayout(uint idThread);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern short VkKeyScanEx(char ch, IntPtr dwhkl);
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
        
        private readonly string[,] specialKeys = new string[,] {  { "Divide", "111", "/(NUMPAD)"},
                                                         { "Multiply", "106", "*(NUMPAD)"},
                                                         { "Subtract", "109", "-(NUMPAD)"},
                                                         { "Add", "107", "+(NUMPAD)"},
                                                         { "Decimal", "110", ".(NUMPAD)"},
                                                         { "NumPad0", "96", "0(NUMPAD)"},
                                                         { "NumPad1", "97", "1(NUMPAD)"},
                                                         { "NumPad2", "98", "2(NUMPAD)"},
                                                         { "NumPad3", "99", "3(NUMPAD)"},
                                                         { "NumPad4", "100", "4(NUMPAD)"},
                                                         { "NumPad5", "101", "5(NUMPAD)"},
                                                         { "NumPad6", "102", "6(NUMPAD)"},
                                                         { "NumPad7", "103", "7(NUMPAD)"},
                                                         { "NumPad8", "104", "8(NUMPAD)"},
                                                         { "NumPad9", "105", "9(NUMPAD)"},
                                                         { "\n", "13", "ENTER"},
                                                      };
       
        private short keyboardLayoutId = 0;
        /// <summary>
        /// Convert a single char to its corresponding keycode within the currently defined keyboard layout.
        /// </summary>
        /// <param name="ch">Char to convert to keycode.</param>
        public Keys CharToKeyCode(char ch)
        {
            Keys ky;
            try
            {
                var virtualKeyCode = new ShortHelper { Value = VkKeyScanEx(ch, GetKeyboardLayoutCustom()) };
                ky = (Keys)virtualKeyCode.Low;
                if ((uint)ky == 255)
                {
                    ky = Keys.None;
                }
            }
            catch
            {
                ky = Keys.None;
            }
            return ky;
        }

        /// <summary>
        /// Convert a string to its corresponding keycode within the currently defined keyboard layout.
        /// </summary>
        /// <param name="str">String to convert to keycode.</param>
        public Keys StringToKeyCode(string str)
        {
            Keys ky = Keys.None;
            if (str != null && !CheckIfSpecKeyStrToKey(str, ref ky))
            {
                if (str.Length > 1)
                {
                    try
                    {
                        str = str.First().ToString().ToUpper() + str.Substring(1);
                        ky = (Keys)Enum.Parse(typeof(Keys), str);
                    }
                    catch
                    {
                        ky = Keys.None;
                    }
                }
                else
                {
                    if (str.Length == 1)
                    {
                        ky = CharToKeyCode(Convert.ToChar(str));
                    }
                    else
                    {
                        ky = Keys.None;
                    }
                }
            }
            return ky;
        }
        /// <summary>
        /// Convert a keycode to its explicit string representation within the currently defined keyboard layout.
        /// </summary>
        /// <param name="kc">Keycode to convert to string.</param>
        public string KeyCodeToString(Keys kc)
        {
            string str = "";
            if (!CheckIfSpecKeyKeyToStr(kc, ref str))
            {
                uint vk = (uint)kc;
                var buf = new StringBuilder(256);
                var keyboardState = new byte[256];
                int result = ToUnicodeEx(vk, KeyCodeToScanCode((Keys)vk), keyboardState, buf, 256, 0, GetKeyboardLayoutCustom());
                switch (result)
                {
                    case 0:
                        str = kc.ToString();
                        break;
                    case 1:
                        str = buf.ToString();
                        break;
                    case 2:
                        str = buf.ToString().Substring(1);
                        break;
                    default:
                        str = "";
                        break;
                }
            }
            return str;
        }

        /// <summary>
        /// Convert a scancode to its corresponding keycode within the currently defined keyboard layout.
        /// </summary>
        /// <param name="scanCode">Scancode to convert to keycode.</param>
        public uint ScanCodeToKeyCode(uint scanCode)
        {
            uint result;
            result = MapVirtualKeyEx(scanCode, 1, GetKeyboardLayoutCustom());
            return result;
        }
        /// <summary>
        /// Convert a keycode to its corresponding scancode within the currently defined keyboard layout.
        /// </summary>
        /// <param name="kc">Keycode to convert to scancode.</param>
        public uint KeyCodeToScanCode(Keys kc)
        {
            uint result;
            result = MapVirtualKeyEx((uint)kc, 0, GetKeyboardLayoutCustom());
            return result;
        }
        /// <summary>
        /// Remap a keycode or a string representation of a key from another language/keyboard layout to the currently defined keyboard layout.
        /// </summary>
        /// <param name="originalKeyboardLayoutId">Original keyboard layout to convert the key from.</param>
        /// <param name="key">String representation of the key to remap. Without modifiers.</param>
        public Keys ReMapKey(short originalKeyboardLayoutId, string key)
        {
            Keys keyCode;
            SetKeyboardLayout(originalKeyboardLayoutId);
            keyCode = StringToKeyCode(key);
            uint scanCode = KeyCodeToScanCode(keyCode);
            SetKeyboardLayout();
            keyCode = (Keys)ScanCodeToKeyCode(scanCode);
            return keyCode;
        }

        /// <summary>
        /// Remap a keycode or a string representation of a key from another language/keyboard layout to the currently defined keyboard layout.
        /// </summary>
        /// <param name="originalKeyboardLayoutId">Original keyboard layout to convert the key from.</param>
        /// <param name="keyCode">Key to remap.</param>
        public Keys ReMapKey(short originalKeyboardLayoutId, Keys keyCode)
        {
            SetKeyboardLayout(originalKeyboardLayoutId);
            uint scanCode = KeyCodeToScanCode(keyCode);
            SetKeyboardLayout();
            keyCode = (Keys)ScanCodeToKeyCode(scanCode);
            return keyCode;
        }

        /// <summary>
        /// Retrieve the language identifier of the current keyboard layout.
        /// </summary>
        public short GetCurrentKeyboardLayoutIdentifier()
        {
            return new ShortHelper { Value = (short)GetKeyboardLayout(0) }.Value;
        }

        /// <summary>
        /// Set which keyboard layout to use for KeysHelper methods. Default (0) is currently active keyboard layout.
        /// </summary>
        /// <param name="keyboardLayout">Language identifier of the keyboard layout.</param>
        public void SetKeyboardLayout(short keyboardLayout = 0)
        {
            keyboardLayoutId = keyboardLayout;
        }

        /// <summary>
        /// Retrieve the keyboard layout to use for KeysHelper methods. It can be set with SetKeyboardLayout. Default is currently active keyboard layout.
        /// </summary>
        private IntPtr GetKeyboardLayoutCustom()
        {
            IntPtr layout;
            if (keyboardLayoutId != 0)
            {
                layout = new IntPtr(keyboardLayoutId);
            }
            else
            {
                layout = GetKeyboardLayout(0);
            }
            return layout;
        }

        // Keycode.ToString() to explicit string for special characters (numpav, enter)
        private bool CheckIfSpecKeyKeyToStr(string strKey, ref string str)
        {
            bool found = false;
            string specKey;
            int index = 0, arrayLength = specialKeys.GetLength(0);
            while (index < arrayLength && !found)
            {
                specKey = specialKeys[index, 0];
                if (specKey == strKey)
                {
                    str = specialKeys[index, 2];
                    found = true;
                }
                ++index;
            }
            return found;
        }

        // Keycode Value to explicit string for special characters (numpav, enter)
        private bool CheckIfSpecKeyKeyToStr(Keys key, ref string str)
        {
            bool found = false;
            int specKey;
            int index = 0, arrayLength = specialKeys.GetLength(0);
            while (index < arrayLength && !found)
            {
                specKey = Convert.ToInt32(specialKeys[index, 1]);
                if ((Keys)specKey == key)
                {
                    str = specialKeys[index, 2];
                    found = true;
                }
                ++index;
            }
            return found;
        }

        // Explicit string to Keycode for special characters (numpav, enter)
        private bool CheckIfSpecKeyStrToKey(string strKey, ref Keys keyCode)
        {
            bool found = false;
            string specKey;
            int index = 0, arrayLength = specialKeys.GetLength(0);
            while (index < arrayLength && !found)
            {
                specKey = specialKeys[index, 2];
                if (specKey == strKey)
                {
                    keyCode = (Keys)Convert.ToInt32(specialKeys[index, 1]);
                    found = true;
                    break;
                }
                ++index;
            }
            return found;
        }

    }
}
