using NBG.Visitor.Blazor.Resources;
using QRCoder;
using System.Drawing;
using System.Net;

namespace NBG.Visitor.Blazor
{
    public static class QRGenerator
    {
        /// <summary>
        /// Generates a QR code.
        /// </summary>
        /// <param name="content">The content of the qr code</param>
        /// <returns>The QR code as bitmap</returns>
        public static Bitmap GenerateQrCode(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            //Old
            //Bitmap logo = BitmapFromUrl("https://fiss.dev.nbg.tech:44303/_content/NBG.Visitor.Blazor/images/NBG_Icon_Red.png");
            Bitmap logo = StaticContent.NBG_Icon_Red;
            return qrCode.GetGraphic(30, System.Drawing.Color.Black, System.Drawing.Color.White, logo, 25, 15, false);
        }

        public static Bitmap BitmapFromUrl(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    return (Bitmap)Bitmap.FromStream(stream);
                }
            }
        }

        //public static bool PrintPDF(string printer, string paperName, string filename, int copies)
        //{
        //    try
        //    {
        //        // Create the printer settings for our printer
        //        var printerSettings = new PrinterSettings
        //        {
        //            PrinterName = printer,
        //            Copies = (short)copies,
        //        };

        //        // Create our page settings for the paper size selected
        //        var pageSettings = new PageSettings(printerSettings)
        //        {
        //            Margins = new Margins(0, 0, 0, 0),
        //        };
        //        foreach (PaperSize paperSize in printerSettings.PaperSizes)
        //        {
        //            if (paperSize.PaperName == paperName)
        //            {
        //                pageSettings.PaperSize = paperSize;
        //                break;
        //            }
        //        }

        //        // Now print the PDF document
        //        using (var document = PdfDocument.Load(filename))
        //        {
        //            using (var printDocument = document.CreatePrintDocument())
        //            {
        //                printDocument.PrinterSettings = printerSettings;
        //                printDocument.DefaultPageSettings = pageSettings;
        //                printDocument.PrintController = new StandardPrintController();
        //                printDocument.Print();
        //            }
        //        }
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return false;
        //    }
        //}
    }
}
