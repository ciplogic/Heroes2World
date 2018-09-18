using SDL2;

namespace HeroesWorld.Engine.Graphics
{
    public struct Rect
    {
        public int X, Y, Width, Height;

        public Rect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public SDL2.SDL.SDL_Rect ToSdlRect()
        {
            return new SDL.SDL_Rect {x = X, y = Y, w = Width, h = Height};
        }
    }
}