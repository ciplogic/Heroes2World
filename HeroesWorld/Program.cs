using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HeroesWorld.Engine;
using HeroesWorld.Engine.Graphical;
using HeroesWorld.Engine.Graphical.Pastel;
using HeroesWorld.Settings;
using NHeroes2.Agg;
using NHeroes2.Agg.Icns;
using NHeroes2.Agg.Music;
using NHeroes2.KingdomNs;
using NHeroes2.Utilities;
using Sdl2.Core;
using Screen = HeroesWorld.Engine.Graphical.Screen;

namespace HeroesWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("../DATA/HEROES2.AGG"))
            {
                var mapsDownloader = new DownloaderMaps();
                if(!mapsDownloader.DownloadSuccessful())
                    return;
            }
            var aggFile = new AggFile();
            aggFile.Open("../DATA/HEROES2.AGG");

            /*
            var extract = new ExtractFrames();
            var result = extract.Extract(aggFile, "/cs-oss/FH2Pics/");
            foreach (var pic in result.Items)
            {
                Console.WriteLine("Pic: "+pic.SerializeToJsonString());
            }*/
            var world = World.Instance;
            world.LoadMapMP2("../MAPS/BROKENA.MP2");

            var settings = new GameSettings
            {
                ScreenWidth = 1200,
                ScreenHeight = 850
            };

            settings.SerializeToJsonFile("config.json");

            var screen = new Screen();
            screen.SetWindow(settings.ScreenWidth, settings.ScreenHeight);


            var icn = aggFile.RenderICNSprite(IcnKind.HEROES, 0);
            icn.first.Save("h2.png");
            Surface surface = new Surface(screen, icn.first);

            var mouse = aggFile.RenderICNSprite(IcnKind.ADVMCO, 0);


            Core myCore = new Core(false);
            MusicPlayer.Play(aggFile, (int) 16);

            //load a sample image
            //IntPtr myTexture = screen.LoadTexture("mmmmIcon.png");

            //IntPtr myTexture = screen.LoadTexture("h2.png");


            //load a sample sound
            //IntPtr mySound = myCore.LoadSound("PlayerJump.wav");
            //IntPtr myMid = myCore.LoadMidi(@"play.mid");
            //myCore.PlaySound(myMid);

            //play the sound
            //myCore.PlaySound(myMid);

            var bitmapPainter = new BitmapPainter(800, 500, "dialog.png");
            var picBmp = new Bitmap(@"..\Extras\Buttons\BtnPic.png");
/*
            bitmapPainter.Commands.Add(new ScalableBitmapPainter(picBmp,
                new Rectangle(20, 20, 200, 130),
                new Rectangle(0, 0, 777, 480)
            ));
*/
            bitmapPainter.Commands.Add(new ScalableBitmapPainter( /*picBmp*/icn.first,
                new Padding(2, 2, 2, 2),
                new Rectangle(30, 20, 577, 420)
            ));

            /*
            bitmapPainter.Commands.Add(new ScalableBitmapPainter(picBmp,
                new Padding(20, 20, 20, 20), 
                new Rectangle(450, 120, 277, 120)
            ));
            */
            bitmapPainter.Paint();
            //Setup the game controller
            IntPtr gc = SDL.SDL_GameControllerOpen(0);
            screen.Transforms
                .ScaleMatrix(1.5, 1.2)
                .TranslateMatrix(25, 150);

            Surface mouseSurface = new Surface(screen, mouse.first);
            while (myCore.IsRunning)
            {
                //Don't forget this.
                myCore.MainLoop();

                //Your code here.

                screen.Clear();
                screen.DrawSprite(surface, 10, 10);
                myCore.PaintMouse(screen, mouseSurface);

                //surface.Draw(screen, 10, 10);

                //read a sample button
                if (SDL.SDL_GameControllerGetButton(gc,
                        SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A) == 1)
                {
                    // myCore.PlaySound(mySound);
                }

                //Finish Renderering
                screen.Present();
            }
        }
    }
}