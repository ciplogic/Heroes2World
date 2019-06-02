using NHeroes2.Engine;
using NHeroes2.KingdomNs;
using NHeroes2.Serialize;

namespace NHeroes2.CastleNs
{
    class Castle
    {
        public MapPosition Position;
        public Castle(int cx, int cy, RaceType kngt)
        {
            Position = new MapPosition(cx, cy);
        }

        public void LoadFromMP2(ByteVectorReader bvr)
        {
            throw new System.NotImplementedException();
        }

        public H2Point GetCenter()
        {
            throw new System.NotImplementedException();
        }

        public ColorKind GetColor()
        {
            throw new System.NotImplementedException();
        }

        public RaceType GetRace()
        {
            throw new System.NotImplementedException();
        }

        public bool isCastle()
        {
            throw new System.NotImplementedException();
        }
    }
}