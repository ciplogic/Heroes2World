using System.Collections.Generic;
using NHeroes2.Agg.Music;

namespace NHeroes2.Agg
{
    class MidEvent
    {
        byte[] pack;
        byte[] data = new byte[4];
    }

    class  MidEvents
    {
        List<MidEvent> _items;
    }
    class MidTrack
    {
        IFFChunkHeader mtrk;
        MidEvents events;
        
    }
    class MidTracks
    {
        public List<MidTrack> _items;
    }

    class XMITrack
    {
        public byte[] timb;
        public byte[] evnt;
    };
}