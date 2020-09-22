using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using SoundBoard.Persistence;

namespace SoundBoard.Core
{

    public interface IHotkey
    {
        int Register(Control windowControl);
        int Unregister();
        int Reregister();
        bool PreFilterMessage(ref Message message);
        int Id { get; }
        KeyAndModifiers Key { get; set; }
        Control WindowControl { get; }
        event HandledEventHandler Pressed;
        void AssignKey(string fullKey);
        void AssignKey(Keys keycode, bool shift, bool ctrl, bool alt);
    }

    public class Hotkey : IHotkey, IMessageFilter
    {
        #region Interop

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int UnregisterHotKey(IntPtr hWnd, int id);

        private const uint WM_HOTKEY = 0x312;

        private const uint MOD_ALT = 0x1;
        private const uint MOD_CONTROL = 0x2;
        private const uint MOD_SHIFT = 0x4;
        private const uint MOD_WIN = 0x8;

        private const uint ERROR_HOTKEY_ALREADY_REGISTERED = 1409;

        #endregion

        private static int currentID = 0;
        private const int maximumID = 0xBFFF;

        public event HandledEventHandler Pressed;

        public Hotkey() : this(Keys.None, false, false, false)
        {
            // No work done here
        }

        public Hotkey(Keys keyCode, bool shift, bool control, bool alt)
        {
            // Assign properties
            Key = new KeyAndModifiers(keyCode, shift, control, alt);

            // Register us as a message filter
            Application.AddMessageFilter(this);
        }

        /// <param name="fullKey">Determines the key and modifiers used by the hotkey. Can be empty but not null.</param>
        public Hotkey (string fullKey)
        {
            if (fullKey == null) { throw new ArgumentNullException(nameof(fullKey), "Fullkey can be empty but not null."); }
            Key = new KeyAndModifiers(fullKey);
            Application.AddMessageFilter(this);
        }

        public Hotkey (KeyAndModifiers fullKey)
        {
            Key = fullKey;
            Application.AddMessageFilter(this);
        }

        ~Hotkey()
        {
            // Unregister the hotkey if necessary
            if (this.Registered)
            { this.Unregister(); }
        }

        public bool Registered { get; private set; }

        public KeyAndModifiers Key { get; set; }

        public int Id { get; private set; } = -1;

        public Control WindowControl { get; private set; }

        public bool Empty { get { return this.Key?.Keycode == Keys.None; } }

        virtual public int Register(Control windowControl)
        {
            // Return 1 if successfully registered, 0 if hotkey empty, -1 if already registered/used/forbidden, -2 by default
            int result = -2;
            if (this.Registered)
            {
                result = -1;
            }
            else
            {
                if (this.Empty)
                {
                    result = 0;
                }
                else
                {
                    if (this.Id == -1)
                    {
                        this.Id = Hotkey.currentID;
                        Hotkey.currentID = Hotkey.currentID + 1 % Hotkey.maximumID;
                    }
                    uint modifiers = (this.Key.Alt ? Hotkey.MOD_ALT : 0) | (this.Key.Control ? Hotkey.MOD_CONTROL : 0) |
                                    (this.Key.Shift ? Hotkey.MOD_SHIFT : 0);
                    if (Hotkey.RegisterHotKey(windowControl.Handle, this.Id, modifiers, this.Key.Keycode) == 0)
                    {
                        if (Marshal.GetLastWin32Error() == ERROR_HOTKEY_ALREADY_REGISTERED)
                        {
                            result = -1;
                        }
                        else
                        {
                            throw new Win32Exception();
                        }
                    }
                    else
                    {
                        this.Registered = true;
                        this.WindowControl = windowControl;
                        result = 1;
                    }
                }
            }
            return result;
        }

        public int Unregister()
        {
            // Return 1 if successfully unregistered, -2 by default, -3 if not registered
            int result = -2;
            if (!this.Registered)
            {
                result = -3;
            }
            else
            {
                if (!this.WindowControl.IsDisposed)
                {
                    if (Hotkey.UnregisterHotKey(this.WindowControl.Handle, this.Id) == 0)
                    {
                        throw new Win32Exception();
                    }
                }
                this.Registered = false;
                this.WindowControl = null;
                result = 1;
            }
            return result;
        }
        
        public int Reregister()
        {
            // Return 1 if successfully reregistered, 0 if empty hotkey, -1 if already registered/used/forbidden, -2 if problem unknown, -3 if not registered
            int result = -2, check = 1;
            Control windowControl;
            if (!this.Registered)
            {
                result = -3;
            }
            else
            {
                windowControl = this.WindowControl;
                check = Unregister();
                if (check == 1)
                {
                    result = this.Register(windowControl);
                }
                else
                {
                    result = check;
                }
            }
            return result;
        }

        public bool PreFilterMessage(ref Message message)
        {
            if (message.Msg != Hotkey.WM_HOTKEY)
            { return false; }
            
            if (this.Registered && (message.WParam.ToInt32() == this.Id))
            {
                return this.OnPressed();
            }
            else
            { return false; }
        }

        private bool OnPressed()
        {
            HandledEventArgs handledEventArgs = new HandledEventArgs(false);
            this.Pressed?.Invoke(this, handledEventArgs);
            return handledEventArgs.Handled;
        }

        public bool IsPressedEventNull()
        {
            return Pressed == null ? true : false;
        }
        
        public void AssignKey(Keys keycode, bool shift, bool ctrl, bool alt)
        {
            this.Key = new KeyAndModifiers(keycode, shift, ctrl, alt);
        }

        public void AssignKey(string fullKey)
        {
            this.Key = new KeyAndModifiers(fullKey);
        }

        public override string ToString()
        {
            return "Fullkey : " + Key.FullKeyString + " | Registered : " + (Registered ? "Yes" : "No");
        }
    }

}
