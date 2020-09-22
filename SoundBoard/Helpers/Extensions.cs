using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace SoundBoard.Helpers
{
    public static class ControlExtensions
    {
        public static IEnumerable<Control> GetAll(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }

    public static class XElementExtensions
    {
        public static IEnumerable<XElement> ElementsOrEmpty(this XElement ele, XName name)
        {
            return ele.Elements(name) ?? new List<XElement>();
        }

        public static IEnumerable<XElement> ElementsOrEmpty(this XElement ele)
        {
            return ele.Elements() ?? new List<XElement>();
        }

        public static IEnumerable<XElement> DescendantsOrEmpty(this XElement ele, XName name)
        {
            return ele.Descendants(name) ?? new List<XElement>();
        }

        public static IEnumerable<XElement> DescendantsOrEmpty(this XElement ele)
        {
            return ele.Descendants() ?? new List<XElement>();
        }

        public static string GetValueOrEmpty(this XElement ele)
        {
            return ele == null ? "" : ele.Value;
        }
    }

    public static class T
    {
        public static T ThrowIfNull<T>(this T value, string argumentName, string message = "")
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName, message); 
            }
            return value;
        }
    }
}
