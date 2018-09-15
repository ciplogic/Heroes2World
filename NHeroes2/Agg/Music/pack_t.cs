using System;
using NHeroes2.Utilities;

namespace NHeroes2.Agg.Music
{
    internal class pack_t
    {
        public UInt32 first, second;

        public override string ToString() 
            => this.SerializeToJsonString();
    }
}