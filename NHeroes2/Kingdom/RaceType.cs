namespace NHeroes2.Kingdom
{
    enum RaceType
    {
        NONE = 0x00,
        KNGT = 0x01,
        BARB = 0x02,
        SORC = 0x04,
        WRLK = 0x08,
        WZRD = 0x10,
        NECR = 0x20,
        MULT = 0x40,
        RAND = 0x80,
        ALL = KNGT | BARB | SORC | WRLK | WZRD | NECR
    }
}
