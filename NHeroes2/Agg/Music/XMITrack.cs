using System.Collections.Generic;
using NHeroes2.Serialize;

namespace NHeroes2.Agg.Music
{
    public class MidTrack
    {
        IFFChunkHeader mtrk;
        MidEvents events;

        public MidTrack(XMITrack track)
        {
            mtrk = new IFFChunkHeader(Xml2Mid.TAG_MTRK, 0);
            events = new MidEvents(track);
            {
                mtrk.length = events._items.Count;
            }
        }

        static MidTrack()
        {
            
            ByteVectorReflect.AddTypeWriter((ByteVectorWriter sb, MidTrack st) =>
            {
                sb.Write(st.mtrk);
                sb.Write(st.events);
            });
        }

    }
    public class XMITrack
    {
        public byte[] timb;
        public byte[] evnt;
    }
}
