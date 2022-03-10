using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NBG.Visitor.Blazor
{
    public class Localizer
    {
        public ResourceManager ResourceManager { get; set; }
        public CultureInfo Culture { get; set; }

        public Localizer(string baseName, Assembly assembly, string culture) : this(baseName, assembly, new CultureInfo(culture)) { }

        public Localizer(string baseName, Assembly assembly, CultureInfo culture) : this(new(baseName, assembly), culture) { }

        public Localizer(ResourceManager rm, CultureInfo culture)
        {
            ResourceManager = rm;
            Culture = culture;
        }

        public string this[string toLocalize]
        {
            get
            {
                return ResourceManager.GetString(toLocalize, Culture);
            }
        }
    }
}
