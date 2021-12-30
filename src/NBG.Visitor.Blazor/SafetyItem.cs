using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace NBG.Visitor.Blazor
{
    public class SafetyItem
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

        public SafetyItem(string data)
        {
            string[] fields = data.Split("\n");
            Title = fields[0];
            Text = fields[1];
            ImagePath = fields[2];
        }

		public SafetyItem(string title, string text, string imagePath)
		{
            Title = title;
            Text = text;
            ImagePath = imagePath;
		}

        public static IEnumerable<SafetyItem> LoadFromResource(Assembly assembly, CultureInfo culture, string baseName = "NBG.Visitor.Blazor.Resources.SafetyItems")
        {
            Localizer Loc = new(baseName, assembly, culture);
            string? data = null;
            for (int i = 1; (data = Loc["String" + i.ToString()]) != null; i++)
            {
                yield return new(data);
            }
        }
    }
}
