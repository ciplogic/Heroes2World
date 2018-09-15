using System;
using HeroesWorld.Engine;
using HeroesWorld.Settings;
using NHeroes2.Agg;
using NHeroes2.Agg.Music;
using NHeroes2.Utilities;

namespace HeroesWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var aggFile = new AggFile();
            aggFile.Open("../data/heroes2.agg");

            /*
            var extract = new ExtractFrames();
            var result = extract.Extract(aggFile, "/Users/cipriankhlud/FH2Pics/");
            foreach (var pic in result.Items)
            {
                Console.WriteLine("Pic: "+pic.SerializeToJsonString());
            }
*/
            var settings = new GameSettings()
            {
                ScreenWidth = 800,
                ScreenHeight = 600
            };
            settings.SerializeToJsonFile("config.json");

            var screen = new Screen();
            screen.SetWindow(settings.ScreenWidth, settings.ScreenHeight);


            Core myCore = new Core();

            //load a sample image
            IntPtr myTexture = screen.LoadTexture("mmmmIcon.png");

            //load a sample sound
            //IntPtr mySound = myCore.LoadSound("PlayerJump.wav");

            //MusicPlayer.Play(aggFile, 1);
            //play the sound
            //myCore.PlaySound(mySound);

            //Setup the game controller
            IntPtr gc = SDL2.SDL.SDL_GameControllerOpen(0);

            while (myCore.IsRunning)
            {
                //Don't forget this.
                myCore.MainLoop();

                //Your code here.
                screen.DrawSprite(
                    myTexture,
                    new SDL2.SDL.SDL_Rect() {x = 0, y = 0, w = 128, h = 128},
                    new SDL2.SDL.SDL_Rect() {x = 100, y = 100, w = 256, h = 256});

                //read a sample button
                if (SDL2.SDL.SDL_GameControllerGetButton(gc,
                        SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A) == 1)
                {
                   // myCore.PlaySound(mySound);
                }

                //Finish Renderering
                screen.Present();
            }
        }
    }
}