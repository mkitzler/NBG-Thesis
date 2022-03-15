using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NBG.Visitor.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBG.Visitor.Blazor;
using System.IO;

namespace NBG.Visitor.Services.REST
{
    [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpPost("GenerateQR")]
        public async Task<byte[]> GenerateQR([FromBody] string content)
        {
            return QRGenerator.GenerateQrCode(content).ToBytes();
        }

        [HttpPost("GenerateTicket")]
        public async Task<byte[]> GenerateTicket([FromBody] GenerateTicketCommand ticket)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (MemoryStream qr = new MemoryStream(ticket.QR))
                {
                    TicketPdfGenerator.GetPdf(ticket.VisitorTicketLabel, ticket.ArrivalLabel, ticket.DateFormat, new System.Drawing.Bitmap(qr), ticket.Guid, ticket.Name, ticket.Arrival).Save(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}
