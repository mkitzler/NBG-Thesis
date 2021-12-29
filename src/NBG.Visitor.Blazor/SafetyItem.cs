using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    public class SafetyItem
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

		public SafetyItem(string title, string text, string imagePath)
		{
            Title = title;
            Text = text;
            ImagePath = imagePath;
		}
    }
}
