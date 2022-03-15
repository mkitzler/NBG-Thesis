using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;

namespace NBG.Visitor.Blazor.Components
{
    public static class MudBlazorConfig
    {
        public static MudTheme Theme = new MudTheme()
        {
            Palette = new Palette()
            {
                Primary = Colors.Red.Accent4,
                Secondary = Colors.Grey.Lighten2,
                SecondaryContrastText = Colors.Grey.Darken2,
                Error = Colors.Red.Darken4,
                Dark = Colors.Shades.Black
            }
        };
    }
}
