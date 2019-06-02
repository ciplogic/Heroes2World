using System;
using NHeroes2.Engine;

namespace NHeroes2.SystemNs
{
    class Settings
    {

        public static Settings Get() => Instance;
        public static Settings Instance { get; } = new Settings();

        public static bool IS_DEVEL()
        {
            throw new NotImplementedException();
        }

        public H2Point WinsMapsPositionObject()
        {
            throw new NotImplementedException();
        }

        public int ConditionLoss()
        {
            throw new NotImplementedException();
        }

        public H2Point LossMapsPositionObject()
        {
            throw new NotImplementedException();
        }

        public bool ExtWorldStartHeroLossCond4Humans()
        {
            throw new NotImplementedException();
        }
    }
}
