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

namespace NBG.Services.Clients.REST
{
    public class RestTicketService : ITicketService
    {
        private const string API_URL = "https://localhost:44323/api/Ticket";
        private static HttpClient _http = new HttpClient();

        public static async Task<byte[]> GenerateQR(string content)
        {
            HttpResponseMessage resp = await _http.PostAsJsonAsync<string>($"{API_URL}/GenerateQR", content).ConfigureAwait(false);
            return await resp.Content.ReadFromJsonAsync<byte[]>().ConfigureAwait(false);
        }

        public static async Task<byte[]> GenerateTicket(string visitorTicketLabel, string arrivalLabel, string dateCulture, byte[] qr, string id, string name, DateTime arrival)
        {
            HttpResponseMessage resp = await _http.PostAsJsonAsync<GenerateTicketCommand>($"{API_URL}/GenerateTicket", new() { VisitorTicketLabel = visitorTicketLabel, ArrivalLabel = arrivalLabel, DateCulture = dateCulture, QR = qr, Guid = id, Name = name, Arrival = arrival }).ConfigureAwait(false);
            return await resp.Content.ReadFromJsonAsync<byte[]>().ConfigureAwait(false);
        }

        public Task<byte[]> GenerateQR(string content)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GenerateTicket(Localizer loc, byte[] qr, string id, string name, DateTime arrival)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GenerateTicket(string visitorTicketLabel, string arrivalLabel, CultureInfo dateCulture, byte[] qr, string id, string name, DateTime arrival)
        {
            throw new NotImplementedException();
        }
    }
}
