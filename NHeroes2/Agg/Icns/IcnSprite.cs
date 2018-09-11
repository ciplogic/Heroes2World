using System.Drawing;
using System.Drawing.Imaging;

namespace NHeroes2.Agg.Icns
{
    public class IcnSprite
    {
        public Bitmap first;
        public Bitmap second;
        public Point offset;

        public void SetSize(bool isFirst, int width, int height, bool b)
        {
            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            if (isFirst)
                first = bmp;
            else
                second = bmp;
        }
    }
}