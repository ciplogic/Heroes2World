namespace NHeroes2.ResourceNs
{
    internal enum ArtifactLevel
    {
        ART_NONE = 0,
        ART_LEVEL1 = 0x01,
        ART_LEVEL2 = 0x02,
        ART_LEVEL3 = 0x04,
        ART_LEVEL123 = ART_LEVEL1 | ART_LEVEL2 | ART_LEVEL3,
        ART_ULTIMATE = 0x08,
        ART_LOYALTY = 0x10,
        ART_NORANDOM = 0x20
    }
}