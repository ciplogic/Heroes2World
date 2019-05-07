using NHeroes2.Serialize;
using NHeroes2.Utilities;

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
            mtrk.length = events.size();
            //_items.Count; 
        }

        public override string ToString()
        {
            return this.SerializeToJsonString();
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
}