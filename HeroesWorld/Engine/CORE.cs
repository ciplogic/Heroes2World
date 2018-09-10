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
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
            win = SDL.SDL_CreateWindow(title, 50, 50, screenWidth, screenHeight, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            ren = SDL.SDL_CreateRenderer(win, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
        }
        
        public void DrawSprite(IntPtr myTexture, SDL.SDL_Rect sourceRect, SDL.SDL_Rect destinationRect)
        {
            SDL.SDL_RenderCopy(ren, myTexture, ref sourceRect, ref destinationRect);
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
    
    class CORE
    {
        public bool bRunning = true;

        public CORE()
        {
            SDL.SDL_Init(SDL.SDL_INIT_AUDIO);
            SDL_mixer.Mix_OpenAudio(SDL_mixer.MIX_DEFAULT_FREQUENCY, SDL_mixer.MIX_DEFAULT_FORMAT, 2, 128);
            SDL.SDL_InitSubSystem(SDL.SDL_INIT_GAMECONTROLLER);
        }

        SDL.SDL_Event systemEvent;
        public void MainLoop()
        {
            while(SDL.SDL_PollEvent(out systemEvent) != 0)
            {
                if(systemEvent.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    bRunning = false;
                }
            }
        }

        public IntPtr LoadSound(string filepath)
        {
            return SDL_mixer.Mix_LoadWAV(filepath);
        }

        public void PlaySound(IntPtr mySound)
        {
            SDL_mixer.Mix_PlayChannel(-1, mySound, 0);
        }
    }
}
