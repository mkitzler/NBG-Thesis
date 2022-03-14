using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain.Commands
{
    public class GenerateTicketCommand
    {
        public string VisitorTicketLabel { get; set; }
        public string ArrivalLabel { get; set; }
        public CultureInfo DateFormat { get; set; }
        public byte[] QR { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public DateTime Arrival { get; set; }
    }
}
