using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;

namespace NBG.Visitor.Blazor.Components
{
    public static class VisitorOverviewTheme
    {

        public static MudTheme Theme = new MudTheme()
        {
            Palette = new Palette()
            {
                Primary = Colors.Red.Darken4,
                Secondary = Colors.Red.Darken1
            }
        };

    }
}
