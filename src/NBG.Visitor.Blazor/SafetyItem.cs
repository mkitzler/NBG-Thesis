using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    public class SafetyItem
    {
        public string Text { get; set; }
        public string ImagePath { get; set; }

		public SafetyItem(string text, string imagePath)
		{
            Text = text;
            ImagePath = imagePath;
		}
    }
}
