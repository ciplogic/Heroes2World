using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace HeroesWorld.Engine.Graphics.Pastel
{
    public class BitmapPainter
    {
        private readonly int _width;
        private readonly int _height;
        private readonly string _outFile;
        private Bitmap _bitmap;

        public BitmapPainter(int width, int height, string outFile)
        {
            _width = width;
            _height = height;
            _outFile = outFile;
            _bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        }

        public void Paint()
        {
            var graphics = System.Drawing.Graphics.FromImage(_bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphics.Dispose();
            _bitmap.Save(_outFile);
        }
        
        
    }
}