using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    public static class Extensions
    {
        public static byte[] ToBytes(this Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
            b.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
