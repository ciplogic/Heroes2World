using System.Collections.Generic;
using NHeroes2.Serialize;

namespace NHeroes2.Agg.Music
{
    class MidTracks
    {
        public List<MidTrack> _items = new List<MidTrack>();

        public MidTracks(XMITracks xmiTracks)
        {

            foreach (XMITrack track in xmiTracks)
            {
                _items.Add(new MidTrack(track));
            }

        }

    }
}