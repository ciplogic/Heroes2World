using System;
using NHeroes2.Engine;
using NHeroes2.Serialize;

namespace NHeroes2.KingdomNs
{
    internal class MapSphinx : MapObjectSimple
    {
        public void LoadFromMP2(int findobject, ByteVectorReader bvr)
        {
            throw new NotImplementedException();
        }
    }

    internal class MapObjectSimple : MapPosition
    {
        public int type;
        public uint uid;
    }

    public class MapPosition
    {
        public H2Point center;

        public MapPosition()
        {
        }

        public MapPosition(int cx, int cy)
        {
            center = new H2Point(cx, cy);
        }
    }
}