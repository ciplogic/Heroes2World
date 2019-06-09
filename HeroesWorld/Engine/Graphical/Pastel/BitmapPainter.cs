using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace HeroesWorld.Engine.Graphical.Pastel
{
    public class BitmapPainter
    {
        private readonly Bitmap _bitmap;
        private readonly int _height;
        private readonly string _outFile;
        private readonly int _width;

        public List<IBitmapPainterCommand> Commands = new List<IBitmapPainterCommand>();

        public BitmapPainter(int width, int height, string outFile)
        {
            _width = width;
            _height = height;
            _outFile = outFile;
            _bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        }

        public void Paint()
        {
            var graphics = Graphics.FromImage(_bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (var command in Commands) command.Paint(new Size(_width, _height), graphics);

            graphics.Dispose();
            _bitmap.Save(_outFile);
        }
    }
}