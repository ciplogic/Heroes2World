using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace HeroesWorld.Engine.Graphical.Pastel
{
    internal static class BitmapUtils
    {
        public static Bitmap CloneImageScaled(Bitmap rawImage, int newWidth, int newHeight)
        {
            var cloneBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
            var scaleWidth = (double) rawImage.Width/ newWidth ;
            var scaleHeight = (double) rawImage.Height / newHeight ;

            for (var y = 0; y < newHeight; y++)
            {
                var posY = (int) (y * scaleHeight);
                for (var x = 0; x < newWidth; x++)
                {
                    var origPixel = rawImage.GetPixel((int) (x * scaleWidth), posY);
                    cloneBitmap.SetPixel(x,y, origPixel);
                    
                }
            }
            return cloneBitmap;
        }

        public static SDL.SDL_Rect ToSdlRect(this Rectangle r)
        {
            return new SDL.SDL_Rect {x = r.X, y = r.Y, w = r.Width, h = r.Height};
        }
        public static Bitmap CutImage(Bitmap rawBitmap, Rectangle area)
        {
            var cloneBitmap = new Bitmap(area.Width, area.Height, rawBitmap.PixelFormat);
            var w = cloneBitmap.Width;
            var h = cloneBitmap.Height;
            var lx = area.X;
            var ly = area.Y;
            for (var y = 0; y < h; y++)
            {
                for (var x = 0; x < w; x++)
                {
                    var pixel = rawBitmap.GetPixel(lx + x, ly + y);
                    cloneBitmap.SetPixel(x, y, pixel);
                }
            }
            

            return cloneBitmap;
        }
    }
}
