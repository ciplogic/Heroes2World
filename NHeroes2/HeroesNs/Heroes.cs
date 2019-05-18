using NHeroes2.Engine;
using NHeroes2.KingdomNs;
using NHeroes2.Serialize;

namespace NHeroes2.HeroesNs
{
    public class Heroes
    {
        public MapPosition position = new MapPosition();
        public RaceType GetRace()
        {
            throw new System.NotImplementedException();
        }

        public void LoadFromMP2(int findobject, H2Color none, RaceType getRace, ByteVectorReader bvr)
        {
            throw new System.NotImplementedException();
        }

        public void SetModes(HeroesFlags jail)
        {
            throw new System.NotImplementedException();
        }

        public bool isFreeman()
        {
            throw new System.NotImplementedException();
        }

        public bool isPosition(H2Point center)
        {
            return position.center.AreEqual(center);
        }
    }
}