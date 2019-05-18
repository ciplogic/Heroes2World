using System.Diagnostics;

namespace NHeroes2.SystemNs
{
    public class H2Settings
    {
        public static H2Settings Instance { get; } = new H2Settings();

        public static H2Settings Get() => Instance;

        public bool PriceLoyaltyVersion()
        {
            return false;
        }
    }
}