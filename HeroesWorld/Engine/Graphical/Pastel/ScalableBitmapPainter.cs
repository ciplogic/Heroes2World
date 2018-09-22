using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace HeroesWorld.Engine.Graphical.Pastel
{
    internal class ScalableBitmapPainter : IBitmapPainterCommand
    {
        private readonly Bitmap _bitmap;
        private readonly Padding  _innerRect;
        private readonly Rectangle _targetPaint;

        public ScalableBitmapPainter(Bitmap bitmap, Padding innerRect, Rectangle targetPaint)
        {
            _bitmap = bitmap;
            _innerRect = innerRect;
            _targetPaint = targetPaint;
        }


        private void DrawScaled(Rectangle cloneRect, Graphics graph, Point point, int newWidth, int newHeight)
        {
            var cutImage = BitmapUtils.CutImage(_bitmap, cloneRect);
            var scaled = BitmapUtils.CloneImageScaled(cutImage, newWidth, newHeight);
            cutImage.Dispose();
            graph.DrawImage(scaled, point);
            scaled.Dispose();
        }

        private void DrawCut(Rectangle cloneRect, Graphics graph, Point point)
        {
            var cutImage = BitmapUtils.CutImage(_bitmap, cloneRect);
            graph.DrawImage(cutImage, point);
            cutImage.Dispose();
        }

        public void Paint(Size bitmapSize, Graphics g)
        {
            var targetScalableImage = new Bitmap(_targetPaint.Width, _targetPaint.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(targetScalableImage);
            var rightMargin = _innerRect.Right;
            int widthTarget = _targetPaint.Width - _innerRect.Left - _innerRect.Right;
            var innerRectWidth = _bitmap.Width - _innerRect.Left - _innerRect.Right;
            var innerRectHeight = _bitmap.Height - _innerRect.Top - _innerRect.Bottom;

            int heightTarget = _targetPaint.Height - _innerRect.Bottom - _innerRect.Top;
       
            //left
            DrawScaled(new Rectangle(0, _innerRect.Top, _innerRect.Left, innerRectHeight),
                graphics, 
                new Point(0, _innerRect.Top), _innerRect.Left, heightTarget);
            
            //right
            DrawScaled(new Rectangle(_bitmap.Width-rightMargin, _innerRect.Top, rightMargin, innerRectHeight),
                graphics,
                new Point(_targetPaint.Width - rightMargin, _innerRect.Top), rightMargin, heightTarget);
    

       //top bar
       DrawScaled(new Rectangle(_innerRect.Left, 0, innerRectWidth, _innerRect.Top), 
           graphics, 
           new Point(_innerRect.Left, 0), widthTarget, _innerRect.Top);


       DrawScaled(new Rectangle(_innerRect.Left, _bitmap.Height - _innerRect.Bottom, innerRectWidth, _innerRect.Bottom),
           graphics,
           new Point(_innerRect.Left, _targetPaint.Height - _innerRect.Bottom), 
           widthTarget, _innerRect.Bottom);
            
           DrawScaled(new Rectangle(_innerRect.Left, _innerRect.Top, innerRectWidth, innerRectHeight),
               graphics,
               new Point(_innerRect.Left, _innerRect.Top),
               widthTarget, heightTarget);

            DrawCut(new Rectangle(0, 0, _innerRect.Left, _innerRect.Top), graphics, new Point(0, 0));

            DrawCut(new Rectangle(0, _bitmap.Height - _innerRect.Bottom, _innerRect.Left, _innerRect.Bottom),
                graphics,
                new Point(0, _targetPaint.Height - _innerRect.Bottom));

            DrawCut(new Rectangle(_bitmap.Width - _innerRect.Right, 0, rightMargin, _innerRect.Top),
                graphics,
                new Point(_targetPaint.Width  - _innerRect.Right, 0));

            DrawCut(new Rectangle(_bitmap.Width  - _innerRect.Right, _bitmap.Height - _innerRect.Bottom, _innerRect.Right, _innerRect.Bottom),
                graphics,
                new Point(_targetPaint.Width  - _innerRect.Right, _targetPaint.Height  - _innerRect.Bottom));

            graphics.Dispose();
            g.DrawImage(targetScalableImage, new Point(_targetPaint.X, _targetPaint.Y));
        }
    }
}
