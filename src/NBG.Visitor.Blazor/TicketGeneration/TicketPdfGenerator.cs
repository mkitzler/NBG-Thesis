using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace NBG.Visitor.Blazor.TicketGeneration
{
    public class TicketPdfGenerator
    {
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
        /// <returns>A PdfSharp PdfDocument as byte array</returns>
        public static byte[] GetPdf(string visitorTicketLabel, string arrivalLabel, CultureInfo dateCulture, byte[] qr, string id, string name, DateTime arrival)
        {
            // Register windows encoding
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            PdfDocument doc = new();
            PdfPage page = doc.AddPage();
            page.Height = new(3.35, XGraphicsUnit.Inch);
            page.Width = new(2.1, XGraphicsUnit.Inch);

            XGraphics gfx = XGraphics.FromPdfPage(page);
            using (MemoryStream qrStream = new MemoryStream(qr))
            {
                gfx.DrawImage(XImage.FromStream(qrStream), 21.6, 21.6, 108, 108);   // 1 Point == 1/72 Inch
            }
            gfx.DrawString(id, new("Consolas", 4, XFontStyle.Regular), XBrushes.Black, 75.6, 133, XStringFormats.Center);
            gfx.DrawString(visitorTicketLabel, new("Consolas", 14, XFontStyle.Regular), XBrushes.Black, 75.6, 150, XStringFormats.Center);
            gfx.DrawString(name, new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 180, XStringFormats.Center);
            gfx.DrawString(arrivalLabel + ":", new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 200, XStringFormats.Center);
            gfx.DrawString(arrival.ToString("g", dateCulture), new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 210, XStringFormats.Center);
            //gfx.DrawLine(new(XColor.FromArgb(0, 0, 0)), 0, 151.2, 151.2, 151.2);

            using (MemoryStream docStream = new MemoryStream())
            {
                doc.Save(docStream);
                return docStream.ToArray();
            }
        }
    }
}
