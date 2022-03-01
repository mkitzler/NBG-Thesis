using QRCoder;
using System;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    internal static class QRGenerator
    {
        public static Bitmap GenerateQrCode(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap logo = BitmapFromUrl("https://fiss.dev.nbg.tech:44303/_content/NBG.Visitor.Blazor/images/NBG_Icon_Red.png");
            Bitmap qr = qrCode.GetGraphic(30, System.Drawing.Color.Black, System.Drawing.Color.White, logo, 15, 15, false);

            return qr;
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
