using System;

namespace NHeroes2.MapsNs
{
    [Flags]
    public enum GroundType
    {
        UNKNOWN = 0x0000,
        DESERT = 0x0001,
        SNOW = 0x0002,
        SWAMP = 0x0004,
        WASTELAND = 0x0008,
        BEACH = 0x0010,
        LAVA = 0x0020,
        DIRT = 0x0040,
        GRASS = 0x0080,
        WATER = 0x0100,
        ALL = DESERT | SNOW | SWAMP | WASTELAND | BEACH | LAVA | DIRT | GRASS
    }
}