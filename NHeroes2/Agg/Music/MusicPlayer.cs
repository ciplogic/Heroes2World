using System;
using System.IO;
using NHeroes2.Serialize;
using SDL2;

namespace NHeroes2.Agg.Music
{
    public class MusicPlayer
    {
        public static void Play(AggFile aggFile, int midSong)
        {
            //XmiKind xmi = XmiKind.MIDI0003;
            XmiKind xmi = (XmiKind) 16;
            byte[]v = GetMID(aggFile, xmi);
            Play(v);
            
            //PlayMid(v, loop);

        }

        private static byte[] GetMID(AggFile aggFile, XmiKind xmi)
        {
            var xmiName = xmi + ".XMI";
            var chunk = aggFile.Read(xmiName);
            return Xmi2Mid(chunk);

        }

        static byte[] Xmi2Mid(byte[] buf)
        {
            XMIData xmi = new XMIData (buf);
            ByteVectorWriter sb = new ByteVectorWriter(16 * 4096);

            if (xmi.isvalid())
            {
                MidData mid = new MidData(xmi.tracks, 64);
                sb.Write(mid); 
            }

            return sb.data();
        }

        static void Play(byte[] buf)
        {
            
            File.WriteAllBytes("play.mid", buf);
            

            IntPtr mix = SDL_mixer.Mix_LoadMUS("play.mid");
            SDL_mixer.Mix_PlayMusic(mix, 1);
        }

    }
}