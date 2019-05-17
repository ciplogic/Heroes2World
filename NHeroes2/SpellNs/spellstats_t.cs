using System;
using NHeroes2.ResourceNs;

namespace NHeroes2.SpellNs
{
    class spellstats_t
    {
        string name;
        byte sp;
        UInt16 mp;
        byte sprite;
        byte extra;
        byte bits;
        cost_t cost;
        string description;
    };
}