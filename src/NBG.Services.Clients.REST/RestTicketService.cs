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
    public class RestTicketService
    {
        private const string API_URL = "https://localhost:44323/api/Ticket";
        private static HttpClient _http = new HttpClient();

        /// <summary>
        /// Generates a QR code.
        /// </summary>
        /// <param name="content">The content of the qr code</param>
        /// <returns>The QR code bitmap as byte array</returns>
        public static async Task<byte[]> GenerateQR(string content)
        {
            HttpResponseMessage resp = await _http.PostAsJsonAsync<string>($"{API_URL}/GenerateQR", content).ConfigureAwait(false);
            return await resp.Content.ReadFromJsonAsync<byte[]>().ConfigureAwait(false);
        }

        /// <summary>
        /// Generates a ticket for the specified visit.
        /// </summary>
        /// <param name="visitorTicketLabel">The localized string for visitor ticket</param>
        /// <param name="arrivalLabel">The localized string for arrival</param>
        /// <param name="dateFormat">The local date format</param>
        /// <param name="qr">The QR Code on the ticket as a BitMap</param>
        /// <param name="id">The Guid of the visit</param>
        /// <param name="name">The Name of the Visitor</param>
        /// <param name="arrival">The arrival DateTime of the Visitor. Will print "Planned Arrival" on the ticket if in the future</param>
        /// <returns>A Pdf file as byte array</returns>
        public static async Task<byte[]> GenerateTicket(string visitorTicketLabel, string arrivalLabel, CultureInfo dateFormat, byte[] qr, string id, string name, DateTime arrival)
        {
            HttpResponseMessage resp = await _http.PostAsJsonAsync<GenerateTicketCommand>($"{API_URL}/GenerateTicket", new() { VisitorTicketLabel = visitorTicketLabel, ArrivalLabel = arrivalLabel, DateFormat = dateFormat, QR = qr, Guid = id, Name = name, Arrival = arrival }).ConfigureAwait(false);
            return await resp.Content.ReadFromJsonAsync<byte[]>().ConfigureAwait(false);
        }
    }
}
