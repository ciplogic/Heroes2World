using System;
using NHeroes2.Engine;
using NHeroes2.GameNs;
using NHeroes2.MapsNs;

namespace NHeroes2.SystemNs
{
    public class H2Settings
    {
        public static H2Settings Instance { get; } = new H2Settings();

        public static H2Settings Get() => Instance;
        H2FileInfo current_maps_file = new H2FileInfo();
        public bool PriceLoyaltyVersion()
        {
            return false;
        }

        public GameOverCondition ConditionWins()
        {
            return current_maps_file.ConditionWins();
        }

        public static bool IS_DEVEL()
        {
            throw new NotImplementedException();
        }

        public H2Point WinsMapsPositionObject()
        {
            throw new NotImplementedException();
        }

        public GameOverCondition ConditionLoss()
        {
            return current_maps_file.ConditionLoss();
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