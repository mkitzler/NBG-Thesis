using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Globalization;

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
