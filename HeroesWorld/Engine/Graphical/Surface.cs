using System;
using System.Drawing;
using HeroesWorld.Engine.Graphical.Pastel;
using Sdl2.Core;

namespace HeroesWorld.Engine.Graphical
{
    public class Surface
    {
        public readonly IntPtr _texture;
        public Rectangle Sizes { get; }

        public Surface(IntPtr texture, Rectangle rect)
        {
            _texture = texture;
            Sizes = rect;
        }

        public Surface(Screen screen, Bitmap icnFirst)
        {
            icnFirst.Save("pic.png");
            _texture = screen.LoadTexture("pic.png");
            Sizes = new Rectangle(0,0,icnFirst.Width, icnFirst.Height);
        }

        public void Draw(Screen screen, int x, int y)
        {
            //Your code here.
            screen.DrawSprite(
                _texture,
                Sizes.ToSdlRect(),
                new SDL.SDL_Rect() {x = x, y = y, w = Sizes.Width, h = Sizes.Height});
        }
    }
}