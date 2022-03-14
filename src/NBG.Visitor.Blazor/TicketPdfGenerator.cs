using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace NBG.Visitor.Blazor
{
    internal class TicketPdfGenerator
    {
        private Localizer Loc;

        public TicketPdfGenerator(Localizer localizer)
        {
            Loc = localizer;
        }

        /// <summary>
        /// Generates a ticket for the specified visit.
        /// </summary>
        /// <param name="qr">The QR Code on the ticket as a BitMap</param>
        /// <param name="id">The Guid of the visit</param>
        /// <param name="name">The Name of the Visitor</param>
        /// <param name="arrival">The arrival DateTime of the Visitor. Will print "Planned Arrival" on the ticket if in the future</param>
        /// <returns></returns>
        public PdfSharp.Pdf.PdfDocument GetPdf(byte[] qr, string id, string name, DateTime arrival)
        {
            // Register windows encoding
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            PdfSharp.Pdf.PdfDocument doc = new();
            PdfSharp.Pdf.PdfPage page = doc.AddPage();
            page.Height = new(3.35, XGraphicsUnit.Inch);
            page.Width = new(2.1, XGraphicsUnit.Inch);

            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(XImage.FromStream(new MemoryStream(qr)), 21.6, 21.6, 108, 108);   // 1 Point == 1/72 Inch
            gfx.DrawString(id, new("Consolas", 4, XFontStyle.Regular), XBrushes.Black, 75.6, 133, XStringFormats.Center);
            gfx.DrawString(Loc["VisitorTicket"], new("Consolas", 14, XFontStyle.Regular), XBrushes.Black, 75.6, 150, XStringFormats.Center);
            gfx.DrawString(name, new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 180, XStringFormats.Center);
            gfx.DrawString((arrival > DateTime.Now ? Loc["PlannedArrival"] : Loc["Arrival"]) + ":", new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 200, XStringFormats.Center);
            gfx.DrawString(arrival.ToString("g", Loc.Culture), new("Consolas", 8, XFontStyle.Regular), XBrushes.Black, 75.6, 210, XStringFormats.Center);
            //gfx.DrawLine(new(XColor.FromArgb(0, 0, 0)), 0, 151.2, 151.2, 151.2);

            return doc;
        }

        /// <summary>
        /// Generates a ticket for the specified visit.
        /// </summary>
        /// <remarks>
        /// Does not utilize PdfSharp.
        /// </remarks>
        /// <param name="qr">The QR Code on the ticket as a BitMap</param>
        /// <param name="id">The Guid of the visit</param>
        /// <param name="name">The Name of the Visitor</param>
        /// <param name="arrival">The arrival DateTime of the Visitor. Will print "Planned Arrival" on the ticket if in the future</param>
        /// <returns></returns>
        public byte[] AlternativeGetPdf(byte[] qr, string id, string name, DateTime arrival)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(new(151.2f, 241.2f));  //Also uses Points
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                var test = new ImgRaw(108, 108, 3, 8, qr);
                test.Left = 21.6f;
                test.Top = 21.6f;
                doc.Add(test);

                doc.Close();

                return ms.ToArray();
            }
        }
    }
}
