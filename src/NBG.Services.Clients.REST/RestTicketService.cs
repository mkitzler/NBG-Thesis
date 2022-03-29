using NBG.Visitor.Domain;
using NBG.Visitor.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Clients.REST
{
    public class RestTicketService : ITicketService
    {
        private const string API_URL = "https://localhost:44323/api/Ticket";
        private static readonly HttpClient _http = new();

        public async Task<byte[]> GenerateQR(string content)
        {
            HttpResponseMessage resp = await _http.PostAsJsonAsync($"{API_URL}/GenerateQR", content).ConfigureAwait(false);
            return await resp.Content.ReadFromJsonAsync<byte[]>().ConfigureAwait(false);
        }

        public async Task<byte[]> GenerateTicket(string visitorTicketLabel, string arrivalLabel, CultureInfo dateCulture, byte[] qr, string id, string name, DateTime arrival)
        {
            HttpResponseMessage resp = await _http.PostAsJsonAsync<GenerateTicketCommand>($"{API_URL}/GenerateTicket", new() { VisitorTicketLabel = visitorTicketLabel, ArrivalLabel = arrivalLabel, DateCulture = dateCulture.Name, QR = qr, Guid = id, Name = name, Arrival = arrival }).ConfigureAwait(false);
            return await resp.Content.ReadFromJsonAsync<byte[]>().ConfigureAwait(false);
        }
    }
}
