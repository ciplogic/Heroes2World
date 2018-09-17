using System;
using HeroesWorld.Engine;
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
                ScreenWidth = 800,
                ScreenHeight = 600
            };
            var icn = aggFile.RenderICNSprite(IcnKind.HEROES, 0);
            
            
            settings.SerializeToJsonFile("config.json");

            var screen = new Screen();
            screen.SetWindow(settings.ScreenWidth, settings.ScreenHeight);


            Core myCore = new Core();

            //load a sample image
            //IntPtr myTexture = screen.LoadTexture("mmmmIcon.png");

            icn.first.Save("h2.png");
            //IntPtr myTexture = screen.LoadTexture("h2.png");
            Surface surface = new Surface(screen, icn.first);

            
            //load a sample sound
            //IntPtr mySound = myCore.LoadSound("PlayerJump.wav");
            //IntPtr myMid = myCore.LoadMidi(@"play.mid");
            //myCore.PlaySound(myMid);

            MusicPlayer.Play(aggFile, (int) 16);
            //play the sound
            //myCore.PlaySound(myMid);

            //Setup the game controller
            IntPtr gc = SDL2.SDL.SDL_GameControllerOpen(0);

            while (myCore.IsRunning)
            {
                //Don't forget this.
                myCore.MainLoop();

                var rectSize = new SDL2.SDL.SDL_Rect() {x = 0, y = 0, w = icn.first.Width, h = icn.first.Height};
                //Your code here.
                
                /*screen.DrawSprite(
                    myTexture,
                    rectSize,
                    rectSize);*/
                surface.Draw(screen, 10, 10);

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