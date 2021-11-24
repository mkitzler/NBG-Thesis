using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    public interface IMainLayout
    {
        void SetHeader(RenderFragment header);
        void SetFooter(RenderFragment footer);
    }
}
