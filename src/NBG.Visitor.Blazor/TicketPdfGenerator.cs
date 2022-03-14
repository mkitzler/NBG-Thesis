using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace NBG.Visitor.Blazor
{
    public class TicketPdfGenerator
    {
        /// <summary>
        /// Generates a ticket for the specified visit.
        /// </summary>
        /// <param name="loc">A Localizer for the text</param>
        /// <param name="qr">The QR Code on the ticket as a BitMap</param>
        /// <param name="id">The Guid of the visit</param>
        /// <param name="name">The Name of the Visitor</param>
        /// <param name="arrival">The arrival DateTime of the Visitor. Will print "Planned Arrival" on the ticket if in the future</param>
        /// <returns>A PdfSharp PdfDocument</returns>
        public static PdfSharp.Pdf.PdfDocument GetPdf(Localizer loc, Bitmap qr, string id, string name, DateTime arrival)
        {
            return GetPdf(loc["VisitorTicket"], (arrival > DateTime.Now ? loc["PlannedArrival"] : loc["Arrival"]), loc.Culture, qr, id, name, arrival);
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
        /// <returns></returns>
        public static PdfSharp.Pdf.PdfDocument GetPdf(string visitorTicketLabel, string arrivalLabel, CultureInfo dateFormat, Bitmap qr, string id, string name, DateTime arrival)
        {
            // Register windows encoding
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            PdfSharp.Pdf.PdfDocument doc = new();
            PdfSharp.Pdf.PdfPage page = doc.AddPage();
            page.Height = new(3.35, XGraphicsUnit.Inch);
            page.Width = new(2.1, XGraphicsUnit.Inch);

            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(XImage.FromStream(qr.ToStream()), 21.6, 21.6, 108, 108);   // 1 Point == 1/72 Inch
            gfx.DrawString(id, new("Consolas", 4, XFontStyle.Regular), XBrushes.Black, 75.6, 133, XStringFormats.Center);
            gfx.DrawString(visitorTicketLabel, new("Consolas", 14, XFontStyle.Regular), XBrushes.Black, 75.6, 150, XStringFormats.Center);
            gfx.DrawString(name, new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 180, XStringFormats.Center);
            gfx.DrawString(arrivalLabel + ":", new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 200, XStringFormats.Center);
            gfx.DrawString(arrival.ToString("g", dateFormat), new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 210, XStringFormats.Center);
            //gfx.DrawLine(new(XColor.FromArgb(0, 0, 0)), 0, 151.2, 151.2, 151.2);

            return doc;
        }
    }
}
