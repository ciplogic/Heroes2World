using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace HeroesWorld
{
    class DownloaderMaps
    {
        public bool DownloadSuccessful()
        {
            if (!File.Exists("../data/heroes2.agg"))
            {
                var downloadDemo = DownloadDemoIsSuccessful();
                if (!downloadDemo)
                    return false;
            }

            return true;
        }

        private bool DownloadDemoIsSuccessful()
        {
            var urlToDownload = "https://github.com/ciplogic/fheroes2enh/releases/download/0.9.1/h2demo.zip";
            Console.WriteLine("You don't have assets to play the game. Do you want to download Heroes 2 Demo files? (Y/N)");
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("Downloading Heroes 2 Demo");
                    var webClient = new WebClient();
                    webClient.DownloadFile(urlToDownload, "h2demo.zip");
                    ZipFile.ExtractToDirectory("h2demo.zip", "..");
                    break;
                case ConsoleKey.N:
                    return false;
            }

            return true;
        }
    }
}