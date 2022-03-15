using NBG.Visitor.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor.TicketGeneration
{
    public class TicketService : ITicketService
    {
        public async Task<byte[]> GenerateQR(string content)
        {
            return QRGenerator.GenerateQrCode(content);
        }

        public async Task<byte[]> GenerateTicket(Localizer loc, byte[] qr, string id, string name, DateTime arrival)
        {
            return await GenerateTicket(loc["VisitorTicket"], arrival > DateTime.Now ? loc["PlannedArrival"] : loc["Arrival"], loc.Culture, qr, id, name, arrival);
        }

        public async Task<byte[]> GenerateTicket(string visitorTicketLabel, string arrivalLabel, CultureInfo dateCulture, byte[] qr, string id, string name, DateTime arrival)
        {
            return TicketPdfGenerator.GetPdf(visitorTicketLabel, arrivalLabel, dateCulture, qr, id, name, arrival);
        }
    }
}
