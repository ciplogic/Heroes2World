using System;
using SDL2;

namespace HeroesWorld.Engine
{
    internal class Core
    {
        public Core()
        {
            SDL.SDL_Init(SDL.SDL_INIT_AUDIO);
            SDL_mixer.Mix_OpenAudio(SDL_mixer.MIX_DEFAULT_FREQUENCY, SDL_mixer.MIX_DEFAULT_FORMAT, 2, 2048);

            SDL.SDL_InitSubSystem(SDL.SDL_INIT_GAMECONTROLLER);
        }

        private bool _bRunning = true;

        public bool IsRunning
            => _bRunning;

        SDL.SDL_Event _systemEvent;

        public void MainLoop()
        {
            while (SDL.SDL_PollEvent(out _systemEvent) != 0)
            {
                if (_systemEvent.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    _bRunning = false;
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