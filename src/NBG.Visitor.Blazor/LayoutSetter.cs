using Microsoft.AspNetCore.Components;
using NBG.Visitor.Blazor.Components;
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
        public IMainLayout layout { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; } = null;

        [Parameter]
        public RenderFragment Footer { get; set; } = null;

        protected override void OnInitialized()
        {
            if (Header != null)
                layout.SetHeader(Header);
            if (Footer != null)
                layout.SetFooter(Footer);
        }
    }

}
