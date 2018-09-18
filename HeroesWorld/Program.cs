using System;
using HeroesWorld.Engine;
using HeroesWorld.Engine.Graphics;
using HeroesWorld.Settings;
using NHeroes2.Agg;
using NHeroes2.Agg.Icns;
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
            var result = extract.Extract(aggFile, "/cs-oss/FH2Pics/");
            foreach (var pic in result.Items)
            {
                Console.WriteLine("Pic: "+pic.SerializeToJsonString());
            }*/

            var settings = new GameSettings
            {
                ScreenWidth = 1600,
                ScreenHeight = 1200
            };

            settings.SerializeToJsonFile("config.json");

            var screen = new Screen();
            screen.SetWindow(settings.ScreenWidth, settings.ScreenHeight);


            var icn = aggFile.RenderICNSprite(IcnKind.HEROES, 0);
            icn.first.Save("h2.png");
            Surface surface = new Surface(screen, icn.first);


            Core myCore = new Core(false);
            MusicPlayer.Play(aggFile, (int)16);

            //load a sample image
            //IntPtr myTexture = screen.LoadTexture("mmmmIcon.png");

            //IntPtr myTexture = screen.LoadTexture("h2.png");


            //load a sample sound
            //IntPtr mySound = myCore.LoadSound("PlayerJump.wav");
            //IntPtr myMid = myCore.LoadMidi(@"play.mid");
            //myCore.PlaySound(myMid);

            //play the sound
            //myCore.PlaySound(myMid);

            //Setup the game controller
            IntPtr gc = SDL2.SDL.SDL_GameControllerOpen(0);
            screen.Transforms
                .ScaleMatrix(1.5, 1.2)
                .TranslateMatrix(25, 150);
            while (myCore.IsRunning)
            {
                //Don't forget this.
                myCore.MainLoop();

                //Your code here.
                
                screen.DrawSprite(surface, 10, 10);
                //surface.Draw(screen, 10, 10);

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