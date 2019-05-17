using HeroesWorld.Engine.Graphical;
using NHeroes2.Serialize;

namespace NHeroes2.KingdomNs
{
    internal class MapSphinx : MapObjectSimple
    {
        public void LoadFromMP2(int findobject, ByteVectorReader bvr)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class MapObjectSimple : MapPosition
    {
        public uint uid;
        public int type;
    }

    internal class MapPosition
    {
        public H2Point center = new H2Point();

        public MapPosition()
        {
            
        }
        public MapPosition(int cx, int cy)
        {
            center = new H2Point(cx, cy);
        }
    }
}