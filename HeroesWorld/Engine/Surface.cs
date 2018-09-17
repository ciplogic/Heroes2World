using System;
using System.Drawing;

namespace HeroesWorld.Engine
{
    public class Surface
    {
        private readonly IntPtr _texture;
        private readonly Rect _rect;

        public Surface(IntPtr texture, Rect rect)
        {
            _texture = texture;
            _rect = rect;
        }

        public Surface(Screen screen, Bitmap icnFirst)
        {
            icnFirst.Save("pic.png");
            _texture = screen.LoadTexture("pic.png");
            _rect = new Rect(0,0,icnFirst.Width, icnFirst.Height);
        }

        public void Draw(Screen screen, int x, int y)
        {
            //Your code here.
            screen.DrawSprite(
                _texture,
                _rect.ToSdlRect(),
                new SDL2.SDL.SDL_Rect() {x = x, y = y, w = _rect.Width, h = _rect.Height});
        }
    }
}