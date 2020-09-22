using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Globalization;

namespace SoundBoard.Helpers
{
    public static class XmlHelper
    {
        public static class Load
        {
            public static Guid ParseGuid(XElement ele, XName eleNameToParse)
            {
                Guid deviceGuid;
                string guidString = ele.Element(eleNameToParse).GetValueOrEmpty();
                var devices = DirectSoundOut.Devices;
                if (!Guid.TryParse(guidString, out deviceGuid) || !devices.Select(d => d.Guid).Contains(deviceGuid))
                {
                    deviceGuid = devices.FirstOrDefault().Guid;
                }
                return deviceGuid;
            }

            public static short ParseShort(XElement ele, XName eleNameToParse, short defaultValue)
            {
                short returnValue =  short.TryParse(ele.Element(eleNameToParse).GetValueOrEmpty(), out returnValue) ? returnValue : defaultValue;
                return returnValue;
            }

            public static int ParseInt(XElement ele, XName eleNameToParse, int defaultValue)
            {
                int returnValue = int.TryParse(ele.Element(eleNameToParse).GetValueOrEmpty(), out returnValue) ? returnValue : defaultValue;
                return returnValue;
            }

            public static float ParseFloat(XElement ele, XName eleNameToParse, float defaultValue)
            {
                float returnValue = float.TryParse(ele.Element(eleNameToParse).GetValueOrEmpty(), NumberStyles.Float, CultureInfo.InvariantCulture, out returnValue) ? returnValue : defaultValue;
                return returnValue;
            }

            public static bool ParseBool(XElement ele, XName eleNameToParse, bool defaultValue)
            {
                bool returnValue = bool.TryParse(ele.Element(eleNameToParse).GetValueOrEmpty(), out returnValue) ? returnValue : defaultValue;
                return returnValue;
            }

            public static string CombineRelativePaths(string folderPath, string files, char separator)
            {
                string[] tempFiles = files.Split(separator);
                files = "";
                foreach (string filename in tempFiles)
                {
                    files += Path.Combine(folderPath, filename) + separator;
                }
                files = files.Substring(0, files.Length - 1);

                return files;
            }
        }

        public static XDocument GetXmlDoc(string filePath)
        {
            XDocument xDocument;
            try
            {
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings { CheckCharacters = false, IgnoreWhitespace = true };
                using (XmlReader xmlReader = XmlReader.Create(filePath, xmlReaderSettings))
                {
                    xmlReader.MoveToContent();
                    xDocument = XDocument.Load(xmlReader);
                }
            }
            catch (XmlException)
            {
                xDocument = null;
            }

            return xDocument;
        }
    }

    public delegate dynamic ParserMethod(string value, NumberStyles numberStyle, CultureInfo inCulture, CultureInfo outCulture);

    public static class NumericParser
    {
        public static readonly ParserMethod ParseInt = Create<int>(int.TryParse);
        public static readonly ParserMethod ParseFloat = Create<float>(float.TryParse);
        public static readonly ParserMethod ParseDouble = Create<double>(double.TryParse);
        public static readonly ParserMethod ParseDecimal = Create<decimal>(decimal.TryParse);

        delegate bool TryParseMethod<T>(string s, NumberStyles style, IFormatProvider provider, out T result);
        static ParserMethod Create<T>(TryParseMethod<T> tryParse) where T : IFormattable
        {
            return (value, numberStyle, inCulture, outCulture) =>
            {
                T result;
                if (tryParse(value, numberStyle, inCulture, out result))
                {
                    return result;
                }
                else
                {
                    return "";
                }
            };
        }
    }
}
