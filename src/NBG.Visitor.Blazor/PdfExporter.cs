using Microsoft.AspNetCore.Components;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    internal static class PdfExporter
    {
        public static Bitmap GenerateQrCode(Guid id)
        {
            DateTime registeredAt = DateTime.Now;

            #if DEBUG
                    Guid id = new("00000000-0000-0000-0000-000000000100");
                    await Task.Delay(1000);
            #else
            #endif

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(id.ToString(), QRCodeGenerator.ECCLevel.H);
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
    }
}
