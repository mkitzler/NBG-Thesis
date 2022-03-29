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
        public static byte[] GenerateQrCode(string content)
        {
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new (qrCodeData);
            //Old
            //Bitmap logo = BitmapFromUrl("https://fiss.dev.nbg.tech:44303/_content/NBG.Visitor.Blazor/images/NBG_Icon_Red.png");
            Bitmap logo = StaticContent.NBG_Icon_Red;
            return qrCode.GetGraphic(30, System.Drawing.Color.Black, System.Drawing.Color.White, logo, 25, 15, false).ToBytes();
        }

        // Old
        //public static Bitmap BitmapFromUrl(string url)
        //{
        //    HttpWebRequest request = WebRequest.CreateHttp(url);
        //    request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //    using (var response = request.GetResponse())
        //    {
        //        using (var stream = response.GetResponseStream())
        //        {
        //            return (Bitmap)Bitmap.FromStream(stream);
        //        }
        //    }
        //}
    }
}
