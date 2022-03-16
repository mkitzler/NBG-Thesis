using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain
{
    public interface ITicketService
    {
        /// <summary>
        /// Generates a QR code.
        /// </summary>
        /// <param name="content">The content of the qr code</param>
        /// <returns>The QR code bitmap as byte array</returns>
        Task<byte[]> GenerateQR(string content);

        /// <summary>
        /// Generates a ticket for the specified visit.
        /// </summary>
        /// <param name="visitorTicketLabel">The localized string for visitor ticket</param>
        /// <param name="arrivalLabel">The localized string for arrival</param>
        /// <param name="dateCulture">The local date format</param>
        /// <param name="qr">The QR Code on the ticket as a BitMap</param>
        /// <param name="id">The Guid of the visit</param>
        /// <param name="name">The Name of the Visitor</param>
        /// <param name="arrival">The arrival DateTime of the Visitor. Will print "Planned Arrival" on the ticket if in the future</param>
        /// <returns>A Pdf file as byte array</returns>
        Task<byte[]> GenerateTicket(string visitorTicketLabel, string arrivalLabel, CultureInfo dateCulture, byte[] qr, string id, string name, DateTime arrival);
    }
}
