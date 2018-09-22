using System;
using HeroesWorld.Engine.Graphical.Pastel;
using SDL2;

namespace HeroesWorld.Engine.Graphical
{
    public class Screen
    {
        public IntPtr win;
        public IntPtr ren;

        public Matrix2D Transforms = Matrix2D.MakeIdentity();

        public void SetWindow(int screenWidth, int screenHeight, string title = "Heroes World",
            SDL.SDL_WindowFlags flags = SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN)
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO);
            win = SDL.SDL_CreateWindow(title, 50, 50, screenWidth, screenHeight, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            ren = SDL.SDL_CreateRenderer(win, -1,
                SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            SDL.SDL_ShowCursor(0);
        }

        public void DrawSprite(IntPtr myTexture, SDL.SDL_Rect sourceRect, SDL.SDL_Rect destinationRect)
        {
            SDL.SDL_RenderCopy(ren, myTexture, ref sourceRect, ref destinationRect);
        }
        public void DrawSprite(Surface surface, int x, int y)
        {
            SDL.SDL_Rect sourceRect = surface.Sizes.ToSdlRect();
            
            var topLeftCoord = (x:x, y:y);
            topLeftCoord = Transforms.TransformCoordinate(topLeftCoord);
            var botRight = (x:x + sourceRect.w, y: y + sourceRect.h);
            botRight = Transforms.TransformCoordinate(botRight);


            var destinationRect = new SDL.SDL_Rect {
                x = topLeftCoord.x, y = topLeftCoord.y,
                w = botRight.x-topLeftCoord.x, h = botRight.y - topLeftCoord.y};
            SDL.SDL_RenderCopy(ren, surface._texture, ref sourceRect, ref destinationRect);
        }

        public void Present()
        {
            SDL.SDL_RenderPresent(ren);
        }

        public IntPtr LoadTexture(string filepath)
        {
            return SDL_image.IMG_LoadTexture(ren, filepath);
        }

        public void Clear()
        {
            SDL.SDL_RenderClear(ren);
        }
    }
}