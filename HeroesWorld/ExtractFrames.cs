using System.Collections.Generic;
using System.IO;
using NHeroes2.Agg;
using NHeroes2.Agg.Icns;

namespace HeroesWorld
{
    public class PictureData
    {
        public int Width, Height;
        public int Index;
        public bool BackImage;
    }

    public class FrameData
    {
        public PictureData[] Items { get; set; } 
    }
    class ExtractFrames
    {
        
        public FrameData Extract(AggFile aggFile, string outDir)
        {
            var data = new List<PictureData>();
            
            for (var i = 0; i < (int) IcnKind.LASTICN; i++)
            {
                var picKind = (IcnKind) i;
                var countPics = aggFile.IcnSpriteCount(picKind);

                for (var idx = 0; idx < countPics; idx++)
                {
                    try
                    {
                        var pic = aggFile.RenderICNSprite(picKind, idx);
                        var imageFormatted = $"{picKind}_{idx}.png";
                        var fileName = Path.Combine(outDir, imageFormatted);
                        pic.first.Save(fileName);
                        
                        var item = new PictureData()
                        {
                            Width = pic.first.Width,
                            Height = pic.first.Height,
                            BackImage = pic.second!=null,
                            Index = idx
                        };
                        data.Add(item);
                    }
                    catch
                    {
                    }
                }


            }

            var result = new FrameData
            {
                Items = data.ToArray()
            };

            return result;
        }
    }
}