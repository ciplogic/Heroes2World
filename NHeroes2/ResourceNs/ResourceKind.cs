namespace NHeroes2.ResourceNs
{
    internal enum ResourceKind
    {
        UNKNOWN = 0x00,
        WOOD = 0x01,
        MERCURY = 0x02,
        ORE = 0x04,
        SULFUR = 0x08,
        CRYSTAL = 0x10,
        GEMS = 0x20,
        GOLD = 0x40,
        ALL = WOOD | MERCURY | ORE | SULFUR | CRYSTAL | GEMS | GOLD
    }
}