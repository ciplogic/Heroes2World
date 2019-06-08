using System;
using NHeroes2.Agg.Icns;
using NHeroes2.KingdomNs;

namespace NHeroes2.MapsNs
{
    public class TilesAddon
    {
        public byte index;
        public byte level;
        public byte obj;
        public byte tmp;
        public uint uniq;

        public TilesAddon(int lv, uint gid, int obj, uint ii)
        {
        }

        public static (ColorKind, RaceType) ColorRaceFromHeroSprite(TilesAddon addon)
        {
            throw new NotImplementedException();
        }

        public static bool ForceLevel2(TilesAddon ta)
        {
            return false;
        }

        public static bool isSkeletonFix(TilesAddon ta)
        {
            return IcnKind.OBJNDSRT == Mp2.GetICNObject(ta.obj) && ta.index == 83;
        }

        public static bool isX_LOC123(TilesAddon ta)
        {
            return IcnKind.X_LOC1 == Mp2.GetICNObject(ta.obj) ||
                   IcnKind.X_LOC2 == Mp2.GetICNObject(ta.obj) ||
                   IcnKind.X_LOC3 == Mp2.GetICNObject(ta.obj);
        }

        public static ObjKind GetLoyaltyObject(TilesAddon it)
        {
            throw new NotImplementedException();
        }
    }
}