using NHeroes2.Agg.Icns;
using NHeroes2.SystemNs;

namespace NHeroes2.Maps
{
    public class Mp2
    {
        public static IcnKind GetICNObject(int type)
        {

            switch (type)
            {
                // reserverd
                case 0:
                    return IcnKind.UNKNOWN;
                // manual
                case 0x11:
                    return IcnKind.TELEPORT1;
                case 0x12:
                    return IcnKind.TELEPORT2;
                case 0x13:
                    return IcnKind.TELEPORT3;
                case 0x14:
                    return IcnKind.FOUNTAIN;
                case 0x15:
                    return IcnKind.TREASURE;

                // artifact
                case 0x2C:
                case 0x2D:
                case 0x2E:
                case 0x2F:
                    return IcnKind.OBJNARTI;

                // monster
                case 0x30:
                case 0x31:
                case 0x32:
                case 0x33:
                    return IcnKind.MONS32;

                // castle flags
                case 0x38:
                case 0x39:
                case 0x3A:
                case 0x3B:
                    return IcnKind.FLAG32;

                // heroes
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x57:
                    return IcnKind.MINIHERO;

                // relief: snow
                case 0x58:
                case 0x59:
                case 0x5A:
                case 0x5B:
                    return IcnKind.MTNSNOW;

                // relief: swamp
                case 0x5C:
                case 0x5D:
                case 0x5E:
                case 0x5F:
                    return IcnKind.MTNSWMP;

                // relief: lava
                case 0x60:
                case 0x61:
                case 0x62:
                case 0x63:
                    return IcnKind.MTNLAVA;

                // relief: desert
                case 0x64:
                case 0x65:
                case 0x66:
                case 0x67:
                    return IcnKind.MTNDSRT;

                // relief: dirt
                case 0x68:
                case 0x69:
                case 0x6A:
                case 0x6B:
                    return IcnKind.MTNDIRT;

                // relief: others
                case 0x6C:
                case 0x6D:
                case 0x6E:
                case 0x6F:
                    return IcnKind.MTNMULT;

                // mines
                case 0x74:
                    return IcnKind.EXTRAOVR;

                // road
                case 0x78:
                case 0x79:
                case 0x7A:
                case 0x7B:
                    return IcnKind.ROAD;

                // relief: crck
                case 0x7C:
                case 0x7D:
                case 0x7E:
                case 0x7F:
                    return IcnKind.MTNCRCK;

                // relief: gras
                case 0x80:
                case 0x81:
                case 0x82:
                case 0x83:
                    return IcnKind.MTNGRAS;

                // trees jungle
                case 0x84:
                case 0x85:
                case 0x86:
                case 0x87:
                    return IcnKind.TREJNGL;

                // trees evil
                case 0x88:
                case 0x89:
                case 0x8A:
                case 0x8B:
                    return IcnKind.TREEVIL;

                // castle and tower
                case 0x8C:
                case 0x8D:
                case 0x8E:
                case 0x8F:
                    return IcnKind.OBJNTOWN;

                // castle lands
                case 0x90:
                case 0x91:
                case 0x92:
                case 0x93:
                    return IcnKind.OBJNTWBA;

                // castle shadow
                case 0x94:
                case 0x95:
                case 0x96:
                case 0x97:
                    return IcnKind.OBJNTWSH;

                // random castle
                case 0x98:
                case 0x99:
                case 0x9A:
                case 0x9B:
                    return IcnKind.OBJNTWRD;

                // water object
                case 0xA0:
                case 0xA1:
                case 0xA2:
                case 0xA3:
                    return IcnKind.OBJNWAT2;

                // object other
                case 0xA4:
                case 0xA5:
                case 0xA6:
                case 0xA7:
                    return IcnKind.OBJNMUL2;

                // trees snow
                case 0xA8:
                case 0xA9:
                case 0xAA:
                case 0xAB:
                    return IcnKind.TRESNOW;

                // trees trefir
                case 0xAC:
                case 0xAD:
                case 0xAE:
                case 0xAF:
                    return IcnKind.TREFIR;

                // trees
                case 0xB0:
                case 0xB1:
                case 0xB2:
                case 0xB3:
                    return IcnKind.TREFALL;

                // river
                case 0xB4:
                case 0xB5:
                case 0xB6:
                case 0xB7:
                    return IcnKind.STREAM;

                // resource
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xBB:
                    return IcnKind.OBJNRSRC;

                // gras object
                case 0xC0:
                case 0xC1:
                case 0xC2:
                case 0xC3:
                    return IcnKind.OBJNGRA2;

                // trees tredeci
                case 0xC4:
                case 0xC5:
                case 0xC6:
                case 0xC7:
                    return IcnKind.TREDECI;

                // sea object
                case 0xC8:
                case 0xC9:
                case 0xCA:
                case 0xCB:
                    return IcnKind.OBJNWATR;

                // vegetation gras
                case 0xCC:
                case 0xCD:
                case 0xCE:
                case 0xCF:
                    return IcnKind.OBJNGRAS;

                // object on snow
                case 0xD0:
                case 0xD1:
                case 0xD2:
                case 0xD3:
                    return IcnKind.OBJNSNOW;

                // object on swamp
                case 0xD4:
                case 0xD5:
                case 0xD6:
                case 0xD7:
                    return IcnKind.OBJNSWMP;

                // object on lava
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDB:
                    return IcnKind.OBJNLAVA;

                // object on desert
                case 0xDC:
                case 0xDD:
                case 0xDE:
                case 0xDF:
                    return IcnKind.OBJNDSRT;

                // object on dirt
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                    return IcnKind.OBJNDIRT;

                // object on crck
                case 0xE4:
                case 0xE5:
                case 0xE6:
                case 0xE7:
                    return IcnKind.OBJNCRCK;

                // object on lava
                case 0xE8:
                case 0xE9:
                case 0xEA:
                case 0xEB:
                    return IcnKind.OBJNLAV3;

                // object on earth
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    return IcnKind.OBJNMULT;

                //  object on lava
                case 0xF0:
                case 0xF1:
                case 0xF2:
                case 0xF3:
                    return IcnKind.OBJNLAV2;

                // extra objects for loyalty version
                case 0xF4:
                case 0xF5:
                case 0xF6:
                case 0xF7:
                    if (H2Settings.Get().PriceLoyaltyVersion()) return IcnKind.X_LOC1;
                    break;

                // extra objects for loyalty version
                case 0xF8:
                case 0xF9:
                case 0xFA:
                case 0xFB:
                    if (H2Settings.Get().PriceLoyaltyVersion()) return IcnKind.X_LOC2;
                    break;

                // extra objects for loyalty version
                case 0xFC:
                case 0xFD:
                case 0xFE:
                case 0xFF:
                    if (H2Settings.Get().PriceLoyaltyVersion()) return IcnKind.X_LOC3;
                    break;

                default:
                    break;
            }

            return IcnKind.UNKNOWN;
        }
    }
}