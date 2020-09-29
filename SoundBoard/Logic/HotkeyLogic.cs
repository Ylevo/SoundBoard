using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using SoundBoard.Core;
using SoundBoard.Utilities;
using SoundBoard.Helpers;

namespace SoundBoard.Logic
{
    class HotkeyLogic
    {
        private readonly List<IHotkey> hotkeysList;
        private readonly Control mainFrm;
        private bool inProcess = false;
        private readonly KeysTranslater keysTranslater;

        public HotkeyLogic(Control mainFrm)
        {
            this.mainFrm = mainFrm.ThrowIfNull(nameof(mainFrm), "A form is required to attach the hotkeys to.");
            hotkeysList = new List<IHotkey>();
            keysTranslater = new KeysTranslater();
            MasterHotkey = new ControlHotkey { Role = ControlRoles.MasterHotkey };
            MasterHotkey.Pressed += delegate { DisableEnableHotkeys(); };
            HotkeysEnabled = true;
        }

        public List<IHotkey> HotkeysList { get { return hotkeysList.ToList(); } }
        public ControlHotkey MasterHotkey { get; set; }
        public bool HotkeysEnabled { get; set; }

        public int AddNewAudioHotkey(string key, string files, float volume, Guid audioDevice, int startingTime = 0, string name = "")
        {
            KeyAndModifiers fullKey = CreateAndValidateFullKey(key);
            AudioHotkey hk = new AudioHotkey(fullKey, audioDevice, files, volume, startingTime, name);
            CheckHotkeyResult(hk.Register(mainFrm), key);
            hotkeysList.Add(hk);
            return hk.Id;
        }

        public int AddNewControlHotkey(string key, ControlRoles role, out string displayedVal, string holdDownKey = "", float flowChangeValue = 0)
        {
            ControlHotkey ctrlHk = null;
            KeyAndModifiers fullKey = CreateAndValidateFullKey(key);
            displayedVal = "";
            ctrlHk = new ControlHotkey(fullKey, role);
            switch (role)
            {
                case ControlRoles.Forward:
                case ControlRoles.Backward:
                    ctrlHk.FlowChangeValue = flowChangeValue;
                    displayedVal = flowChangeValue + " sec";
                    break;
                case ControlRoles.IncreaseVolume:
                case ControlRoles.DecreaseVolume:
                    ctrlHk.FlowChangeValue = flowChangeValue;
                    displayedVal = flowChangeValue + "%";
                    break;
                case ControlRoles.HoldDownKey:
                    ctrlHk.HoldDownKey = keysTranslater.StringToKeyCode(holdDownKey);
                    displayedVal = holdDownKey;
                    break;
                case ControlRoles.IncreaseTempo:
                case ControlRoles.DecreaseTempo:
                case ControlRoles.IncreaseSpeed:
                case ControlRoles.DecreaseSpeed:
                    ctrlHk.FlowChangeValue = flowChangeValue;
                    displayedVal = flowChangeValue + "%";
                    break;
                case ControlRoles.IncreasePitch:
                case ControlRoles.DecreasePitch:
                    ctrlHk.FlowChangeValue = flowChangeValue;
                    displayedVal = "+" + (flowChangeValue / 10) + ((flowChangeValue / 10) >= 2 ? " semitones" : " semitone");
                    break;
                case ControlRoles.MasterHotkey:
                    ctrlHk = null;
                    if (MasterHotkey.Registered)
                    {
                        throw new MasterHotkeyUsedException(MasterHotkey.Key.FullKeyString);
                    }
                    MasterHotkey.Key = fullKey;
                    CheckHotkeyResult(MasterHotkey.Register(mainFrm), key);
                    return MasterHotkey.Id;
            }
            CheckHotkeyResult(ctrlHk.Register(mainFrm), key);
            hotkeysList.Add(ctrlHk);
            return ctrlHk.Id;
        }

        private void CheckHotkeyResult(int result, string key = "")
        {
            switch(result)
            {
                case 0:
                    throw new KeyEmptyException();
                case -1:
                    throw new KeyForbiddenException(key);
                case -2:
                    throw new UnknownErrorRegisterHotkey();
            }
        }

        public void RemoveHotkey(int hotkeyId)
        {
            if (hotkeyId == MasterHotkey.Id)
            {
                MasterHotkey.Unregister();
            }
            else
            {
                IHotkey hk = FindHotkeyById(hotkeyId);
                hk.Unregister();
                hotkeysList.Remove(hk);
            }
        }
        
        public void ModifyAudioHotkey(int hotkeyId, string newName = "", string newKey = "", string newFiles = "", float newVolume = -1, int newStartingTime = -1, string newAudioDevice = "")
        {
            IHotkey hk = FindHotkeyById(hotkeyId);
            CheckIfProperHotkeyType(typeof(AudioHotkey), hk);
            AudioHotkey hotkey = (AudioHotkey)hk;
            if (newName != "") { hotkey.Name = newName; }
            if (newKey != "") { ModifyHotkey(hotkeyId, newKey); }
            if (newFiles != "") { hotkey.Files = newFiles; }
            if (newVolume != -1) { hotkey.Volume = newVolume / 100; }
            if (newStartingTime != -1) { hotkey.StartingTime = newStartingTime; }
            if (newAudioDevice != "") { hotkey.AudioDevice = new Guid(newAudioDevice); }
        }

        public void ModifyHotkey(int hotkeyId, string newKey)
        {
            IHotkey hk = FindHotkeyById(hotkeyId);
            KeyAndModifiers newFullKey = CreateAndValidateFullKey(newKey);
            KeyAndModifiers oldFullKey = hk.Key;
            hk.Key = newFullKey;
            int result = hk.Reregister();
            if (result != 1 && result != -3)
            {
                hk.Key = oldFullKey;
                hk.Register(mainFrm);
                CheckHotkeyResult(result, newKey);
            }
        }
        
        private void CheckIfProperHotkeyType(Type t, IHotkey hk)
        {
            if (t != hk.GetType())
            {
                throw new Exception("Invalid hotkey type");
            }
        }

        public KeyAndModifiers CreateAndValidateFullKey(string key)
        {
            if (key == "") { throw new KeyMissingException(); }
            KeyAndModifiers fullKey = new KeyAndModifiers(key);
            if (!fullKey.IsActualKey())
            {
                throw new KeyInvalidException(key);
            }
            if (IsKeyAlreadyUsed(fullKey))
            {
                throw new KeyAlreadyUsedException(key);
            }
            return fullKey;
        }

        private void DisableEnableHotkeys()
        {
            if (inProcess)
            {
                return;
            }
            inProcess = true;
            int i = 0;
            switch (HotkeysEnabled)
            {
                case true:
                    for (i = 0; i < hotkeysList.Count; ++i)
                    {
                        hotkeysList[i].Unregister();
                    }
                    break;
                case false:
                    for (i = 0; i < hotkeysList.Count; ++i)
                    {
                        hotkeysList[i].Register(mainFrm);
                    }
                    break;
            }
            HotkeysEnabled = !HotkeysEnabled;
            inProcess = false;
        }

        public bool IsKeyAlreadyUsed(KeyAndModifiers fullKey)
        {
            bool result;
            IHotkey hk;
            hk = hotkeysList.Find(hkey => hkey.Key.ToString() == fullKey.FullKeyString);
            result = hk != null;
            result |= MasterHotkey.Registered && (fullKey.FullKeyString == MasterHotkey.Key.FullKeyString);

            return result;
        }

        public IHotkey FindHotkeyById(int id)
        {
            IHotkey hk = null;
            hk = hotkeysList.Find(hkey => hkey.Id == id);
            return hk;
        }

        public void ClearHotkeysList()
        {
            foreach (IHotkey hk in hotkeysList)
            {
                hk.Unregister();
            }
            hotkeysList.Clear();
            if (MasterHotkey.Registered)
            {
                MasterHotkey.Unregister();
            }
        }

        public string RemapKey(string fullkey, short originalLayoutIdentifier)
        {
            KeyAndModifiers key = new KeyAndModifiers(fullkey);
            string remappedKey = key.ModifiersString + keysTranslater.KeyCodeToString(keysTranslater.ReMapKey(originalLayoutIdentifier, key.KeyString));
            if (remappedKey == "Keys.None" || remappedKey == "None")
            {
                throw new KeyRemappingFailedException(fullkey, originalLayoutIdentifier);
            }
            return remappedKey;
        }
    }
}
