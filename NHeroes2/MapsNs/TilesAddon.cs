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

        public static bool isSkeletonFix(TilesAddon ta)
        {
            return (Agg.Icns.IcnKind.OBJNDSRT == Mp2.GetICNObject(ta.obj)) && (ta.index == 83);
        }

        public static bool isX_LOC123(TilesAddon ta)
        {    return Agg.Icns.IcnKind.X_LOC1 == Mp2.GetICNObject(ta.obj) ||
                    Agg.Icns.IcnKind.X_LOC2 == Mp2.GetICNObject(ta.obj) ||
                    Agg.Icns.IcnKind.X_LOC3 == Mp2.GetICNObject(ta.obj);
        }

        public static ObjKind GetLoyaltyObject(TilesAddon it)
        {
            throw new NotImplementedException();
        }
    }
}
