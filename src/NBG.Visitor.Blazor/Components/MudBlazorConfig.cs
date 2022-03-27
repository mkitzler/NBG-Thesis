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
        public static MudTheme TerminalViewTheme = new MudTheme()
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

        public static MudTheme VisitorOverviewTheme = new MudTheme()
        {
            Palette = new Palette()
            {
                Primary = Colors.Red.Darken3,
                Secondary = Colors.Grey.Lighten1,
                SecondaryContrastText = Colors.Grey.Darken2,
                Error = Colors.Red.Default,
                Dark = Colors.Shades.Black
            }
        };
    }
}
