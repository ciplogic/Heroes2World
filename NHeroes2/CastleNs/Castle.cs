using System;
using NHeroes2.Engine;
using NHeroes2.KingdomNs;
using NHeroes2.Serialize;

namespace NHeroes2.CastleNs
{
    public class Castle
    {
        public ColorBase Color = new ColorBase();
        public MapPosition Position;

        public Castle(int cx, int cy, RaceType kngt)
        {
            Position = new MapPosition(cx, cy);
        }

        public void LoadFromMP2(ByteVectorReader bvr)
        {
            throw new NotImplementedException();
        }

        public H2Point GetCenter()
        {
            throw new NotImplementedException();
        }

        public ColorKind GetColor()
        {
            return (ColorKind) Color.Color;
        }

        public RaceType GetRace()
        {
            throw new NotImplementedException();
        }

        public bool isCastle()
        {
            throw new NotImplementedException();
        }
    }
}