using System.Diagnostics;
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

        public int ConditionWins()
        {
            throw new System.NotImplementedException();
        }
    }
}