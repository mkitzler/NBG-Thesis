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
        public Task<byte[]> GenerateQR(string content)
        {
            return Task.FromResult(QRGenerator.GenerateQrCode(content));
        }

        public Task<byte[]> GenerateTicket(string visitorTicketLabel, string arrivalLabel, CultureInfo dateCulture, byte[] qr, string id, string name, DateTime arrival)
        {
            return Task.FromResult(TicketPdfGenerator.GetPdf(visitorTicketLabel, arrivalLabel, dateCulture, qr, id, name, arrival));
        }
    }
}
