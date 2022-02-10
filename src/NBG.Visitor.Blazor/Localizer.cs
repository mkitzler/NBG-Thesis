using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NBG.Visitor.Blazor
{
    public class Localizer
    {
        private ResourceManager rm;
        public CultureInfo Culture { get; set; }

        public Localizer(string baseName, Assembly assembly, CultureInfo culture)
        {
            rm = new(baseName, assembly);
            Culture = culture;
        }

        public Localizer(string baseName, Assembly assembly, string culture) : this(baseName, assembly, new CultureInfo(culture)) { }

        public string this[string toLocalize]
        {
            get
            {
                return rm.GetString(toLocalize, Culture);
            }
        }
    }
}
