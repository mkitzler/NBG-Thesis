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
using System.Globalization;
using NBG.Visitor.Blazor.TicketGeneration;

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
            return QRGenerator.GenerateQrCode(content);
        }

        [HttpPost("GenerateTicket")]
        public async Task<byte[]> GenerateTicket([FromBody] GenerateTicketCommand ticket)
        {
            return TicketPdfGenerator.GetPdf(ticket.VisitorTicketLabel, ticket.ArrivalLabel, new CultureInfo(ticket.DateCulture), ticket.QR, ticket.Guid, ticket.Name, ticket.Arrival);
        }
    }
}
