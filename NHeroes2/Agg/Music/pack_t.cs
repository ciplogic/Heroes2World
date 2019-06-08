using NHeroes2.Utilities;

namespace NHeroes2.Agg.Music
{
    internal class pack_t
    {
        public uint first, second;

        public override string ToString()
        {
            return this.SerializeToJsonString();
        }
    }
}