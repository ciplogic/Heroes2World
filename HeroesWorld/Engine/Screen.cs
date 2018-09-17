using System;
using SDL2;

namespace HeroesWorld.Engine
{
    public class Screen
    {
        public IntPtr win;
        public IntPtr ren;

        public void SetWindow(int screenWidth, int screenHeight, string title = "SDL2 Sharp",
            SDL.SDL_WindowFlags flags = SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN)
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO);
            win = SDL.SDL_CreateWindow(title, 50, 50, screenWidth, screenHeight, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            ren = SDL.SDL_CreateRenderer(win, -1,
                SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
        }

        public void DrawSprite(IntPtr myTexture, SDL.SDL_Rect sourceRect, SDL.SDL_Rect destinationRect)
        {
            SDL.SDL_RenderCopy(ren, myTexture, ref sourceRect, ref destinationRect);
        }
        public void DrawSprite(Surface surface, int x, int y)
        {
            surface.Draw(this, x, y);
        }

        public void Present()
        {
            SDL.SDL_RenderPresent(ren);
        }

        public IntPtr LoadTexture(string filepath)
        {
            return SDL_image.IMG_LoadTexture(ren, filepath);
        }
    }
}