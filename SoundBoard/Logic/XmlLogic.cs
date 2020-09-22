using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
using System.Xml;
using SoundBoard.Core;
using SoundBoard.Helpers;
using SoundBoard.Utilities;
using SoundBoard.Persistence;

namespace SoundBoard.Logic
{
    class XmlLogic
    {
        private KeysTranslater keysTranslater;
        private mainForm mainFrm;
        private HotkeyLogic hkLogic;

        public XmlLogic(mainForm mainFrm, HotkeyLogic hkLogic)
        {
            this.mainFrm = mainFrm.ThrowIfNull(nameof(mainFrm), "A form is required to attach the hotkeys to.");
            this.hkLogic = hkLogic.ThrowIfNull(nameof(hkLogic), "HotkeyLogic required to work.");
            keysTranslater = new KeysTranslater();
        }

        public List<string> LoadHotkeysXml(string xmlFilePath)
        {
            List<string> errorsList = new List<string>();
            bool reMapping = false, useRelativePaths = false, skipAllAudioHotkeys = false;
            short originalLayoutIdentifier = 0;
            string audioFolderPath = " ";
            XElement rootElement = ValidateHotkeysXmlFile(xmlFilePath);
            XElement miscData = rootElement.Element("MiscData");
            originalLayoutIdentifier = XmlHelper.Load.ParseShort(miscData, "KeyboardLayoutIdentifier", 0);
            useRelativePaths = XmlHelper.Load.ParseBool(miscData, "UseRelativePaths", false);
            if (useRelativePaths)
            {
                audioFolderPath = Path.Combine(Path.GetDirectoryName(xmlFilePath), "AudioFiles");
                if (!Directory.Exists(audioFolderPath))
                {
                    skipAllAudioHotkeys = true;
                    errorsList.Add("The audio hotkeys could not be retrieved : the audio files' folder was not found.");
                }
            }
            short test = keysTranslater.GetCurrentKeyboardLayoutIdentifier();
            if (originalLayoutIdentifier != keysTranslater.GetCurrentKeyboardLayoutIdentifier())
            {
                reMapping = true;
            }
            XElement xmlHotkeys, xmlFadingValues;
            xmlHotkeys = rootElement.Element("Hotkeys");
            xmlFadingValues = rootElement.Element("FadingValues");
            if (xmlHotkeys != null)
            {
                string hotkeyType, key;
                foreach (XElement xmlHotkey in xmlHotkeys.ElementsOrEmpty())
                {
                    hotkeyType = ""; key = "";
                    try
                    {
                        hotkeyType = xmlHotkey.Name.ToString();
                        key = xmlHotkey.Element("Key").GetValueOrEmpty();
                        if (skipAllAudioHotkeys && hotkeyType == "AudioHotkey") { continue; }
                        if (reMapping) { key = hkLogic.RemapKey(key, originalLayoutIdentifier); }
                        switch (hotkeyType)
                        {
                            case "AudioHotkey":
                                LoadAudioHotkeyXml(key, xmlHotkey, audioFolderPath);
                                break;
                            case "ControlHotkey":
                                LoadControlHotkeyXml(key, xmlHotkey);
                                break;
                        }
                    }
                    catch (CustomException ex)
                    {
                        errorsList.Add(ex.MessageToUser);
                    }
                    catch (Exception ex)
                    {
                        errorsList.Add(string.Format(ErrorHelper.XmlLoad.UnexpectedHotkeyErrorException, key, Logger.LogsFolderPath));
                        Logger.NewLog(ex, string.Format("Unexpected & unmanaged error while trying to retrieve an {0} hotkey during xml loading.\nIterated XElement's string :\n'{1}'", 
                                    hotkeyType == "" ? "undefined" : hotkeyType, xmlHotkey != null ? xmlHotkey.ToString() : "null"));
                        break;
                    }
                }
                
            }
            if (xmlFadingValues != null)
            {
                LoadFadingValuesXml(xmlFadingValues);
            }
            return errorsList;
        }

        private void LoadAudioHotkeyXml(string key, XElement xmlHotkey, string audioFolderPath)
        {
            string name = xmlHotkey.Element("Name").GetValueOrEmpty();
            string files = xmlHotkey.Element("Files").GetValueOrEmpty();
            if (audioFolderPath != " ")
            {
                files = XmlHelper.Load.CombineRelativePaths(audioFolderPath, files, '*');
            }
            int startingTime = XmlHelper.Load.ParseInt(xmlHotkey, "TimeStart", 0);
            float volume = XmlHelper.Load.ParseFloat(xmlHotkey, "Volume", 0.2f);
            Guid audioDevice = XmlHelper.Load.ParseGuid(xmlHotkey, "Device");
            int hkId = hkLogic.AddNewAudioHotkey(key, files, volume, audioDevice, startingTime, name);
            mainFrm.AudioHkDataGridAddLine(key, files, volume, hkId, audioDevice, startingTime, name);
        }

        private void LoadControlHotkeyXml(string key, XElement xmlHotkey)
        {
            string role = xmlHotkey.Element("Role").GetValueOrEmpty(), keyToPress = "", displayedVal = "";
            float flowChangeValue = 0;
            ControlRoles hotkeyAction;
            if (!Enum.TryParse(role, out hotkeyAction)) { throw new HotkeyRoleInvalidException(role, key); }
            switch (hotkeyAction)
            {
                case ControlRoles.HoldDownKey:
                    keyToPress = xmlHotkey.Element("PressWhichKey").GetValueOrEmpty();
                    break;
                case ControlRoles.Forward:
                case ControlRoles.Backward:
                case ControlRoles.IncreaseVolume:
                case ControlRoles.DecreaseVolume:
                case ControlRoles.IncreasePitch:
                case ControlRoles.DecreasePitch:
                case ControlRoles.IncreaseTempo:
                case ControlRoles.DecreaseTempo:
                case ControlRoles.IncreaseSpeed:
                case ControlRoles.DecreaseSpeed:
                    flowChangeValue = XmlHelper.Load.ParseFloat(xmlHotkey, "FlowChangeValue", 10);
                    break;
            }
            int hkId = hkLogic.AddNewControlHotkey(key, hotkeyAction, out displayedVal, keyToPress, flowChangeValue);
            mainFrm.ControlHkDataGridAddLine(key, hotkeyAction, displayedVal, hkId);
        }

        private void LoadFadingValuesXml(XElement fadingValues)
        {
            FadingActions fAction;
            int fadeInValue, fadeOutValue;
            foreach (XElement fading in fadingValues.ElementsOrEmpty())
            {
                if (!Enum.TryParse(fading.Name?.ToString(), out fAction))
                {
                    continue;
                }
                fadeInValue = XmlHelper.Load.ParseInt(fading, "FadeIn", 0);
                fadeOutValue = XmlHelper.Load.ParseInt(fading, "FadeOut", 0);
                mainFrm.UpdateFadingValues(fadeInValue, fadeOutValue, fAction);
            }
        }

        public void SaveHotkeysToXml(string xmlFilePath, bool useRelativePaths)
        {
            List<IHotkey> currentHotkeysList = hkLogic.HotkeysList;
            XElement root = new XElement("SoundBoardRoot");
            XElement xmlHotkeys = new XElement("Hotkeys");
            XElement xmlHtk;
            foreach (IHotkey hk in currentHotkeysList)
            {
                switch (hk.GetType().Name)
                {
                    case "AudioHotkey":
                        xmlHtk = SaveAudioHotkeyToXml((AudioHotkey)hk, useRelativePaths);
                        break;
                    case "ControlHotkey":
                        xmlHtk = SaveControlHotkeyToXml((ControlHotkey)hk);
                        break;
                    default:
                        xmlHtk = null;
                        break;
                }
                if (xmlHtk != null) { xmlHotkeys.Add(xmlHtk); }
            }
            if (hkLogic.MasterHotkey.Registered) { xmlHotkeys.Add(SaveMasterHotkeyToXml(hkLogic.MasterHotkey)); }
            root.Add(xmlHotkeys, SaveFadingValuesToXml(), SaveMiscDataToXml(useRelativePaths));
            if (File.Exists(xmlFilePath))
            {
                File.Delete(xmlFilePath.Insert(xmlFilePath.Length - 4, "-backup"));
                File.Move(xmlFilePath, xmlFilePath.Insert(xmlFilePath.Length - 4, "-backup"));
            }
            Directory.CreateDirectory(Path.GetDirectoryName(xmlFilePath));
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { CheckCharacters = false, Indent = true };
            using (XmlWriter xmlWriter = XmlWriter.Create(xmlFilePath, xmlWriterSettings))
            {
                root.WriteTo(xmlWriter);
            }
        }

        public void ExportHotkeysAsZip(string zipFilePath, string folderToZip)
        {
            string audioFilesFolder = Path.Combine(folderToZip, "AudioFiles");
            string xmlFilePath = Path.Combine(folderToZip, "Hotkeys.xml");
            Directory.CreateDirectory(folderToZip);
            Directory.CreateDirectory(audioFilesFolder);
            foreach (Hotkey hk in hkLogic.HotkeysList)
            {
                if (hk.GetType() == typeof(AudioHotkey))
                {
                    foreach (string filePath in ((AudioHotkey)hk).Files.Split('*'))
                    {
                        File.Copy(filePath, Path.Combine(audioFilesFolder, Path.GetFileName(filePath)));
                    }
                }
            }
            SaveHotkeysToXml(xmlFilePath, true);
            File.Delete(zipFilePath);
            ZipFile.CreateFromDirectory(folderToZip, zipFilePath, CompressionLevel.Fastest, false);
        }

        private XElement SaveAudioHotkeyToXml(AudioHotkey hotkey, bool useRelativePaths)
        {
            XElement xmlHotkey = new XElement("AudioHotkey", new XElement("Name", hotkey.Name), 
                                                             new XElement("Key", hotkey.Key.FullKeyString));
            XElement files;
            if (useRelativePaths)
            {
                string relativeFiles = "";
                foreach (string file in hotkey.Files.Split('*'))
                {
                    relativeFiles += Path.GetFileName(file) + "*";
                }
                relativeFiles = relativeFiles.Substring(0, relativeFiles.Length - 1);
                files = new XElement("Files", relativeFiles);
            }
            else
            {
                files = new XElement("Files", hotkey.Files);
            }
            xmlHotkey.Add(files, new XElement("Device", hotkey.AudioDevice), 
                                 new XElement("TimeStart", hotkey.StartingTime), 
                                 new XElement("Volume", hotkey.Volume));
            return xmlHotkey;
        }

        private XElement SaveControlHotkeyToXml(ControlHotkey hotkey)
        {
            XElement xmlHotkey = new XElement("ControlHotkey", new XElement("Key", hotkey.Key.FullKeyString));
            XElement ctrlData = null;
            ControlRoles ctrlRole = hotkey.Role;
            xmlHotkey.Add(new XElement("Role", ctrlRole.ToString()));
            switch (ctrlRole)
            {
                case ControlRoles.HoldDownKey:
                    ctrlData = new XElement("PressWhichKey", keysTranslater.KeyCodeToString((hotkey.HoldDownKey)));
                    break;
                case ControlRoles.Forward:
                case ControlRoles.Backward:
                case ControlRoles.IncreaseVolume:
                case ControlRoles.DecreaseVolume:
                case ControlRoles.IncreasePitch:
                case ControlRoles.DecreasePitch:
                case ControlRoles.IncreaseTempo:
                case ControlRoles.DecreaseTempo:
                case ControlRoles.IncreaseSpeed:
                case ControlRoles.DecreaseSpeed:
                    ctrlData = new XElement("FlowChangeValue", hotkey.FlowChangeValue.ToString());
                    break;
            }
            if (ctrlData != null)
            {
                xmlHotkey.Add(ctrlData);
            }
            return xmlHotkey;
        }

        private XElement SaveMasterHotkeyToXml(ControlHotkey masterHotkey)
        {
            return new XElement("ControlHotkey", new XElement("Key", masterHotkey.Key.FullKeyString),
                                                 new XElement("Role", masterHotkey.Role.ToString()));
        }

        private XElement SaveFadingValuesToXml()
        {
            XElement fadingValues = new XElement("FadingValues");
            XElement fadingAction, fadeIn, fadeOut;
            foreach (FadingActions fAction in Enum.GetValues(typeof(FadingActions)))
            {
                fadingAction = new XElement(fAction.ToString());
                fadeIn = new XElement("FadeIn", SoundPlayer.Instance.GetFadingValue(fAction, "fadeIn"));
                fadeOut = new XElement("FadeOut", SoundPlayer.Instance.GetFadingValue(fAction, "fadeOut"));
                fadingAction.Add(fadeIn, fadeOut);
                fadingValues.Add(fadingAction);
            }
            return fadingValues;
        }

        private XElement SaveMiscDataToXml(bool useRelativePaths)
        {
            return new XElement("MiscData", new XElement("KeyboardLayoutIdentifier", keysTranslater.GetCurrentKeyboardLayoutIdentifier()),
                                            new XElement("UseRelativePaths", useRelativePaths));
        }

        private XElement ValidateHotkeysXmlFile(string xmlFilePath)
        {
            if (xmlFilePath != null && !File.Exists(xmlFilePath))
            {
                throw new XmlFileNotFoundException(xmlFilePath);
            }
            XDocument xDocument = XmlHelper.GetXmlDoc(xmlFilePath);
            XElement rootElement = xDocument?.Root;
            if (rootElement == null || rootElement.DescendantsOrEmpty().Count() == 0)
            {
                throw new XmlFileEmptyException(xmlFilePath);
            }
            else
            {
                return rootElement;
            }
        }
        

    }
}
