using System;
using HeroesWorld.Engine;
using HeroesWorld.Settings;
using NHeroes2.Agg;
using SDL2SharpTutorial.Utilities;

namespace HeroesWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var aggFile = new AggFile();
            aggFile.Read("../data/heroes2.agg");
            
            var settings = new GameSettings()
            {
                ScreenWidth = 800,
                ScreenHeight = 600
            };
            settings.SerializeToFile("config.json");

            var screen = new Screen();
            screen.SetWindow(settings.ScreenWidth,  settings.ScreenHeight);
            
            
            CORE myCore = new CORE();

            //load a sample image
            IntPtr myTexture = screen.LoadTexture("mmmmIcon.png");

            //load a sample sound
            IntPtr mySound = myCore.LoadSound("PlayerJump.wav");

            //play the sound
            myCore.PlaySound(mySound);

            //Setup the game controller
            IntPtr gc = SDL2.SDL.SDL_GameControllerOpen(0);

            while(myCore.bRunning)
            {
                //Don't forget this.
                myCore.MainLoop();

                //Your code here.
                screen.DrawSprite(
                    myTexture, 
                    new SDL2.SDL.SDL_Rect() { x = 0, y = 0, w = 128, h = 128},
                    new SDL2.SDL.SDL_Rect() { x = 100, y = 100, w = 256, h = 256});
                
                //read a sample button
                if (SDL2.SDL.SDL_GameControllerGetButton(gc, SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A) == 1)
                {
                    myCore.PlaySound(mySound);
                }

                //Finish Renderering
                screen.Present();
            }
        }
    }
}
