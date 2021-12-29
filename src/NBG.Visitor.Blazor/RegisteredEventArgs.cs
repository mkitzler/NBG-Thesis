using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    public class RegisteredEventArgs : EventArgs
    {
        public string Message { get; set; }

        public RegisteredEventArgs(string message)
        {
            Message = message;
        }
    }
}
