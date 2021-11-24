using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    public class LayoutSetter : ComponentBase
    {
        [CascadingParameter]
        public MainLayout Layout { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        protected override void OnInitialized()
        {
            Layout.SetHeaderAndFooter(Header, Footer);
        }
    }

}
