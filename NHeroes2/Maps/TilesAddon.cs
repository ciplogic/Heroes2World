using System;
using NHeroes2.KingdomNs;

namespace NHeroes2.Maps
{
    public class TilesAddon
    {
        public UInt32 uniq;
        public byte level;
        public byte obj;
        public byte index;
        public byte tmp;
        public TilesAddon(int lv, uint gid, int obj, uint ii)
        {

        }

        public static (H2Color, RaceType) ColorRaceFromHeroSprite(TilesAddon addon)
        {
            throw new NotImplementedException();
        }

        public static bool ForceLevel2(TilesAddon ta)
        {
            return false;
        }
    }
}
