using System;
using HeroesWorld.Engine.Graphical;
using HeroesWorld.Engine.Graphical.Pastel;
using Sdl2.Core;

namespace HeroesWorld.Engine
{
    internal class Core
    {
        private bool _bRunning = true;
        (int x, int y) _mousePos = (x: 0, y: 0);

        SDL.SDL_Event _systemEvent;

        public Core(bool initSound)
        {
            if (initSound)
            {
                SDL.SDL_Init(SDL.SDL_INIT_AUDIO);
                SDL_mixer.Mix_OpenAudio(SDL_mixer.MIX_DEFAULT_FREQUENCY, SDL_mixer.MIX_DEFAULT_FORMAT, 2, 128);

                SDL.SDL_InitSubSystem(SDL.SDL_INIT_GAMECONTROLLER);
            }
        }

        public bool IsRunning
            => _bRunning;

        public void PaintMouse(Screen screen, Surface surface)
        {
            var destRect = new SDL.SDL_Rect
            {
                x = _mousePos.x, y = _mousePos.y,
                w = surface.Sizes.Width,
                h = surface.Sizes.Height
            };
            screen.DrawSprite(surface._texture, surface.Sizes.ToSdlRect(), destRect);
        }

        public void MainLoop()
        {
            _bRunning = true;
            while (SDL.SDL_PollEvent(out _systemEvent) != 0)
            {
                if (_systemEvent.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    _bRunning = false;
                }

                if (_systemEvent.type == SDL.SDL_EventType.SDL_MOUSEMOTION)
                {
                    _mousePos = (x: _systemEvent.motion.x, y: _systemEvent.motion.y);
                }
            }
        }

        public IntPtr LoadSound(string filepath)
        {
            return SDL_mixer.Mix_LoadWAV(filepath);
        }


        public IntPtr LoadMidi(string filepath)
        {
            var s = SDL_mixer.Mix_LoadMUS(filepath);
            SDL_mixer.Mix_PlayMusic(s, 1);
            return s;
        }

        public void PlaySound(IntPtr mySound)
        {
            SDL_mixer.Mix_PlayChannel(-1, mySound, 0);
        }
    }
}