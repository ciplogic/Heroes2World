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
    }
}