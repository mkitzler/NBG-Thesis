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

        public static IEnumerable<SafetyItem> LoadFromResource(Localizer loc)
        {
            string data;
            for (int i = 1; (data = loc["String" + i.ToString("00")]) != null; i++)
            {
                yield return new(data);
            }
        }
    }
}
