using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace NBG.Visitor.Blazor
{
    public static class Extensions
    {
        public static byte[] ToBytes(this Bitmap b)
        {
            return b.ToStream().ToArray();
        }

        public static MemoryStream ToStream(this Bitmap b)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                b.Save(ms, ImageFormat.Png);
                return ms;
            }
        }
    }
}
