namespace NHeroes2.CastleNs
{
    internal enum BuildCondType
    {
        NOT_TODAY = -1,
        ALREADY_BUILT = -2,
        NEED_CASTLE = -3,
        BUILD_DISABLE = -4,
        UNKNOWN_UPGRADE = -5,
        REQUIRES_BUILD = -6,
        LACK_RESOURCES = -7,
        UNKNOWN_COND = 0,
        ALLOW_BUILD = 1
    }
}