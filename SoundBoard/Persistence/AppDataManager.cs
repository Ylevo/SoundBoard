using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using SoundBoard.Helpers;

namespace SoundBoard.Persistence
{
    public enum AppDataNames { DefaultXmlFilePath, DefaultAudioOutputDevice, LoadXmlOnStartUp, SaveOnClosing, DisableDirtyTracker, ResetRatesOnNewPlay, ResetAutoRepeatOnNewPlay, AudioLatency, TracksPlayOrder, DisplayTracksFullFilepaths, EnableNotifications }

    public static class AppDataManager
    {
        private static readonly string appDataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SoundBoard");
        private static readonly string appConfigFilePath = Path.Combine(appDataFolderPath, "config.xml");
        private static readonly Dictionary<AppDataNames, string> appDataDefaultValues = new Dictionary<AppDataNames, string>()
        {
            { AppDataNames.DefaultXmlFilePath, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SoundBoard\\Hotkeys.xml") },
            { AppDataNames.LoadXmlOnStartUp, "1" },
            { AppDataNames.SaveOnClosing, "0" },
            { AppDataNames.DisableDirtyTracker, "0" },
            { AppDataNames.ResetRatesOnNewPlay, "0" },
            { AppDataNames.ResetAutoRepeatOnNewPlay, "1" },
            { AppDataNames.AudioLatency, "50" },
            { AppDataNames.TracksPlayOrder, "Default" },
            { AppDataNames.DisplayTracksFullFilepaths, "0" },
            { AppDataNames.DefaultAudioOutputDevice, "00000000-0000-0000-0000-000000000000" },
            { AppDataNames.EnableNotifications, "0" }
        };

        private static XElement loadedCfg;

        public static bool isFolderExisting()
        {
            return Directory.Exists(appDataFolderPath);
        }

        public static bool isConfigFileExisting()
        {
            return File.Exists(appConfigFilePath);
        }

        public static void initializeCfgFile()
        {
            Directory.CreateDirectory(appDataFolderPath);
            createConfigXML();
        }

        public static string getAppDataFolderPath()
        {
            return appDataFolderPath;
        }

        private static void createConfigXML()
        {
            List<XElement> dataElements = new List<XElement>();
            XElement newDataElement, root;
            foreach (AppDataNames dataName in appDataDefaultValues.Keys)
            {
                newDataElement = new XElement(dataName.ToString(), appDataDefaultValues[dataName]);
                dataElements.Add(newDataElement);
            }
            root = new XElement("AppConfigData");
            root.Add(dataElements);
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { CheckCharacters = false, Indent = true };
            using (XmlWriter xmlWriter = XmlWriter.Create(appConfigFilePath, xmlWriterSettings))
            {
                root.WriteTo(xmlWriter);
            }
            loadedCfg = root;
        }

        public static bool loadCfgFile()
        {
            bool allGood = false;
            if (!isFolderExisting() || !isConfigFileExisting())
            {
                initializeCfgFile();
            }
            else
            {
                XDocument xDocument = XmlHelper.GetXmlDoc(appConfigFilePath);
                if (xDocument != null)
                {
                    loadedCfg = xDocument.Root;
                    XElement missingData;
                    bool somethingWasMissing = false;
                    foreach (AppDataNames dataName in Enum.GetValues(typeof(AppDataNames)))
                    {
                        if (loadedCfg.Element(dataName.ToString()) == null)
                        {
                            missingData = new XElement(dataName.ToString(), appDataDefaultValues[dataName]);
                            loadedCfg.Add(missingData);
                            somethingWasMissing = true;
                        }
                    }
                    if (somethingWasMissing)
                    {
                        saveCfg();
                    }
                    allGood = true;
                }
                else
                {
                    createConfigXML();
                    allGood = false;
                }
            }
            return allGood;
        }

        public static void setCfgParameter(AppDataNames dataName, string dataValue)
        {
            loadedCfg.Element(dataName.ToString()).SetValue(dataValue);
        }

        public static string getCfgParameter(AppDataNames dataName)
        {
            string value = "";
            value = loadedCfg.Element(dataName.ToString()).Value;
            return value;
        }

        public static void saveCfg()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { CheckCharacters = false, Indent = true };
            using (XmlWriter xmlWriter = XmlWriter.Create(appConfigFilePath, xmlWriterSettings))
            {
                loadedCfg.WriteTo(xmlWriter);
            }
        }
    }
}
