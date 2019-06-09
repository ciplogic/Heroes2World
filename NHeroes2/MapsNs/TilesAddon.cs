using System;
using NHeroes2.Agg.Icns;
using NHeroes2.KingdomNs;
using NHeroes2.Objects;

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


        public static ObjKind GetLoyaltyObject(TilesAddon it)
        {
            throw new NotImplementedException();
        }

        public bool isUniq(uint id)
        {
            return uniq == id;
        }

        public bool isICN(int icn)
        {
            return icn == (int) Mp2.GetICNObject(obj);
        }

        public bool isStream(TilesAddon ta)
        {
            return IcnKind.STREAM == Mp2.GetICNObject(ta.obj) ||
                   IcnKind.OBJNMUL2 == Mp2.GetICNObject(ta.obj) && ta.index < 14;
        }

        public bool isRoad(TilesAddon ta)
        {
            return IcnKind.ROAD == Mp2.GetICNObject(ta.obj);
        }

        public bool isWaterResource(TilesAddon ta)
        {
            return IcnKind.OBJNWATR == Mp2.GetICNObject(ta.obj) &&
                   (0 == ta.index || // buttle
                    19 == ta.index || // chest
                    45 == ta.index || // flotsam
                    111 == ta.index) // surviror
                ;
        }

        public bool isWhirlPool(TilesAddon ta)
        {
            return IcnKind.OBJNWATR == Mp2.GetICNObject(ta.obj) && ta.index >= 202 && ta.index <= 225;
        }

        public bool isStandingStone(TilesAddon ta)
        {
            return IcnKind.OBJNMULT == Mp2.GetICNObject(ta.obj) &&
                   (ta.index == 84 || ta.index == 85);
        }

        public bool isResource(TilesAddon ta)
        {
            // OBJNRSRC
            return IcnKind.OBJNRSRC == Mp2.GetICNObject(ta.obj) && ta.index % 2 != 0 ||
                   // TREASURE
                   IcnKind.TREASURE == Mp2.GetICNObject(ta.obj);
        }

        public bool isRandomResource(TilesAddon ta)
        {
            // OBJNRSRC
            return IcnKind.OBJNRSRC == Mp2.GetICNObject(ta.obj) && 17 == ta.index;
        }

        public bool isArtifact(TilesAddon ta)
        {
            // OBJNARTI (skip ultimate)
            return IcnKind.OBJNARTI == Mp2.GetICNObject(ta.obj) && ta.index > 0x10 && ta.index % 2 != 0;
        }

        public bool isRandomArtifact(TilesAddon ta)
        {
            // OBJNARTI
            return IcnKind.OBJNARTI == Mp2.GetICNObject(ta.obj) && 0xA3 == ta.index;
        }

        public bool isRandomArtifact1(TilesAddon ta)
        {
            // OBJNARTI
            return IcnKind.OBJNARTI == Mp2.GetICNObject(ta.obj) && 0xA7 == ta.index;
        }

        public bool isRandomArtifact2(TilesAddon ta)
        {
            // OBJNARTI
            return IcnKind.OBJNARTI == Mp2.GetICNObject(ta.obj) && 0xA9 == ta.index;
        }

        public bool isRandomArtifact3(TilesAddon ta)
        {
            // OBJNARTI
            return IcnKind.OBJNARTI == Mp2.GetICNObject(ta.obj) && 0xAB == ta.index;
        }

        public bool isUltimateArtifact(TilesAddon ta)
        {
            // OBJNARTI
            return IcnKind.OBJNARTI == Mp2.GetICNObject(ta.obj) && 0xA4 == ta.index;
        }

        public bool isCampFire(TilesAddon ta)
        {
            // MTNDSRT
            return IcnKind.OBJNDSRT == Mp2.GetICNObject(ta.obj) && 61 == ta.index ||
                   // OBJNMULT
                   IcnKind.OBJNMULT == Mp2.GetICNObject(ta.obj) && 131 == ta.index ||
                   // OBJNSNOW
                   IcnKind.OBJNSNOW == Mp2.GetICNObject(ta.obj) && 4 == ta.index;
        }

        public bool isMonster(TilesAddon ta)
        {
            // MONS32
            return IcnKind.MONS32 == Mp2.GetICNObject(ta.obj);
        }

        public bool isArtesianSpring(TilesAddon ta)
        {
            return IcnKind.OBJNCRCK == Mp2.GetICNObject(ta.obj) &&
                   (ta.index == 3 || ta.index == 4);
        }

        public bool isSkeleton(TilesAddon ta)
        {
            return IcnKind.OBJNDSRT == Mp2.GetICNObject(ta.obj) && ta.index == 84;
        }

        public static bool isSkeletonFix(TilesAddon ta)
        {
            return IcnKind.OBJNDSRT == Mp2.GetICNObject(ta.obj) && ta.index == 83;
        }

        public bool isOasis(TilesAddon ta)
        {
            return IcnKind.OBJNDSRT == Mp2.GetICNObject(ta.obj) &&
                   (ta.index == 108 || ta.index == 109);
        }

        public bool isWateringHole(TilesAddon ta)
        {
            return IcnKind.OBJNCRCK == Mp2.GetICNObject(ta.obj) && ta.index >= 217 && ta.index <= 220;
        }

        public bool isJail(TilesAddon ta)
        {
            return IcnKind.X_LOC2 == Mp2.GetICNObject(ta.obj) && 0x09 == ta.index;
        }

        public bool isEvent(TilesAddon ta)
        {
            // OBJNMUL2
            return IcnKind.OBJNMUL2 == Mp2.GetICNObject(ta.obj) && 0xA3 == ta.index;
        }

        public bool isMine(TilesAddon ta)
        {
            // EXTRAOVR
            return IcnKind.EXTRAOVR == Mp2.GetICNObject(ta.obj);
        }

        public bool isBoat(TilesAddon ta)
        {
            // OBJNWAT2
            return IcnKind.OBJNWAT2 == Mp2.GetICNObject(ta.obj) && 0x17 == ta.index;
        }

        public bool isMiniHero(TilesAddon ta)
        {
            // MINIHERO
            return IcnKind.MINIHERO == Mp2.GetICNObject(ta.obj);
        }

        public bool isCastle(TilesAddon ta)
        {
            // OBJNTOWN
            return IcnKind.OBJNTOWN == Mp2.GetICNObject(ta.obj);
        }

        public bool isRandomCastle(TilesAddon ta)
        {
            // OBJNTWRD
            return IcnKind.OBJNTWRD == Mp2.GetICNObject(ta.obj) && 32 > ta.index;
        }

        public bool isRandomMonster(TilesAddon ta)
        {
            // MONS32
            return IcnKind.MONS32 == Mp2.GetICNObject(ta.obj) && 0x41 < ta.index && 0x47 > ta.index;
        }

        public bool isBarrier(TilesAddon ta)
        {
            return IcnKind.X_LOC3 == Mp2.GetICNObject(ta.obj) &&
                   60 <= ta.index && 102 >= ta.index && 0 == ta.index % 6;
        }

        private int ColorFromBarrierSprite(TilesAddon ta)
        {
            // 60, 66, 72, 78, 84, 90, 96, 102
            return IcnKind.X_LOC3 == Mp2.GetICNObject(ta.obj) &&
                   60 <= ta.index && 102 >= ta.index
                ? (ta.index - 60) / 6 + 1
                : 0;
        }

        private int ColorFromTravellerTentSprite(TilesAddon ta)
        {
            // 110, 114, 118, 122, 126, 130, 134, 138
            return IcnKind.X_LOC3 == Mp2.GetICNObject(ta.obj) &&
                   110 <= ta.index && 138 >= ta.index
                ? (ta.index - 110) / 4 + 1
                : 0;
        }

        public bool isAbandoneMineSprite(TilesAddon ta)
        {
            return IcnKind.OBJNGRAS == Mp2.GetICNObject(ta.obj) && 6 == ta.index ||
                   IcnKind.OBJNDIRT == Mp2.GetICNObject(ta.obj) && 8 == ta.index;
        }

        public bool isFlag32(TilesAddon ta)
        {
            return IcnKind.FLAG32 == Mp2.GetICNObject(ta.obj);
        }

        public static bool isX_LOC123(TilesAddon ta)
        {
            return IcnKind.X_LOC1 == Mp2.GetICNObject(ta.obj) ||
                   IcnKind.X_LOC2 == Mp2.GetICNObject(ta.obj) ||
                   IcnKind.X_LOC3 == Mp2.GetICNObject(ta.obj);
        }

        public bool IsShadow(TilesAddon ta)
        {
            IcnKind icn = Mp2.GetICNObject(ta.obj);

            switch (icn)
            {
                case IcnKind.MTNDSRT:
                case IcnKind.MTNGRAS:
                case IcnKind.MTNLAVA:
                case IcnKind.MTNMULT:
                case IcnKind.MTNSNOW:
                case IcnKind.MTNSWMP:
                    return ObjMnts1.isShadow(ta.index);

                case IcnKind.MTNCRCK:
                case IcnKind.MTNDIRT:
                    return ObjMnts2.isShadow(ta.index);

                case IcnKind.TREDECI:
                case IcnKind.TREEVIL:
                case IcnKind.TREFALL:
                case IcnKind.TREFIR:
                case IcnKind.TREJNGL:
                case IcnKind.TRESNOW:
                    return ObjTree.isShadow(ta.index);

                case IcnKind.OBJNCRCK:
                    return ObjCrck.isShadow(ta.index);
                case IcnKind.OBJNDIRT:
                    return ObjDirt.isShadow(ta.index);
                case IcnKind.OBJNDSRT:
                    return ObjDsrt.isShadow(ta.index);
                case IcnKind.OBJNGRA2:
                    return ObjGra2.isShadow(ta.index);
                case IcnKind.OBJNGRAS:
                    return ObjGras.isShadow(ta.index);
                case IcnKind.OBJNMUL2:
                    return ObjMul2.isShadow(ta.index);
                case IcnKind.OBJNMULT:
                    return ObjMult.isShadow(ta.index);
                case IcnKind.OBJNSNOW:
                    return ObjSnow.isShadow(ta.index);
                case IcnKind.OBJNSWMP:
                    return ObjSwmp.isShadow(ta.index);
                case IcnKind.OBJNWAT2:
                    return ObjWat2.isShadow(ta.index);
                case IcnKind.OBJNWATR:
                    return ObjWatr.isShadow(ta.index);

                case IcnKind.OBJNARTI:
                case IcnKind.OBJNRSRC:
                    return 0 == ta.index % 2;

                case IcnKind.OBJNTWRD:
                    return ta.index > 31;
                case IcnKind.OBJNTWSH:
                    return true;

                default:
                    break;
            }

            return false;
        }
    }
}