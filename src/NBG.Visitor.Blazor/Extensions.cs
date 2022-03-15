using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace NBG.Visitor.Blazor
{
    public static class Extensions
    {
        public static byte[] ToBytes(this Bitmap b)
        {
            using (MemoryStream ms = new MemoryStream())
            {
#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
                b.Save(ms, ImageFormat.Png);
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
                return ms.ToArray();
            }
        }
    }
}
