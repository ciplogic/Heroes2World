using System.Drawing;

namespace HeroesWorld.Engine.Graphical.Pastel
{
    public interface IBitmapPainterCommand
    {
        void Paint(Size bitmapSize, Graphics graphics);
    }
}