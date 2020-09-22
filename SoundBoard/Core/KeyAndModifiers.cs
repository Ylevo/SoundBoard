using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoundBoard.Utilities;

namespace SoundBoard.Core
{
    public class KeyAndModifiers
    {
        public KeyAndModifiers(Keys keyCode, bool shift, bool ctrl, bool alt)
        {
            this.Keycode = keyCode;
            this.Shift = shift;
            this.Control = ctrl;
            this.Alt = alt;
        }

        public KeyAndModifiers(string fullKey)
        {
            if (fullKey == null) { throw new ArgumentNullException(nameof(fullKey), "String can be empty but not null."); }
            this.KeyString = GetKeyString(fullKey);
            this.Keycode = new KeysTranslater().StringToKeyCode(this.KeyString);
            this.Shift = fullKey.Contains("SHIFT+");
            this.Control = fullKey.Contains("CTRL+");
            this.Alt = fullKey.Contains("ALT+");
            this.ModifiersString = GetModifiersString();
        }

        public string KeyString
        {
            get; private set;
        }

        public string ModifiersString
        {
            get; private set;
        }

        public string FullKeyString
        {
            get { return ToString(); }
        }

        public Keys Keycode
        {
            get; private set;
        }

        public bool Control
        {
            get; private set;
        }
        public bool Alt
        {
            get; private set;
        }
        public bool Shift
        {
            get; private set;
        }

        private string GetKeyString(string fullKey)
        {
            string keyString = fullKey.Split('+').Last();
            if (keyString == "" && fullKey.LastOrDefault() == '+')
            {
                keyString = "+";
            }
            return keyString;
        }

        private string GetModifiersString()
        {
            return string.Concat((Control ? "CTRL+" : ""), (Alt ? "ALT+" : ""), (Shift ? "SHIFT+" : ""));
        }

        public bool IsActualKey()
        {
            return this.Keycode != Keys.None;
        }

        public override string ToString()
        {
            return string.Concat(GetModifiersString(), KeyString);
        }
        
    }
}
