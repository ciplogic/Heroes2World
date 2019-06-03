using System;

namespace NHeroes2.HeroesNs
{
    [Flags]
    enum HeroFlags
    {
        SHIPMASTER = 0x00000001,
        //UNUSED	= 0x00000002,
        SPELLCASTED = 0x00000004,
        ENABLEMOVE = 0x00000008,
        //UNUSED	= 0x00000010,
        //UNUSED	= 0x00000020,
        //UNUSED	= 0x00000040,
        JAIL = 0x00000080,
        ACTION = 0x00000100,
        SAVEPOINTS = 0x00000200,
        SLEEPER = 0x00000400,
        GUARDIAN = 0x00000800,
        NOTDEFAULTS = 0x00001000,
        NOTDISMISS = 0x00002000,
        VISIONS = 0x00004000,
        PATROL = 0x00008000,
        CUSTOMARMY = 0x00010000,
        CUSTOMSKILLS = 0x00020000
    };
}