using System;
using NHeroes2.ResourceNs;

namespace NHeroes2.SpellNs
{
    class spellstats_t
    {
        public string name;
        public byte sp;
        public ushort mp;
        public byte sprite;
        public byte extra;
        public byte bits;
        public cost_t cost;
        public string description;

        public spellstats_t(string name, byte sp, ushort mp, byte sprite, byte extra, byte bits, cost_t cost, string description)
        {
            this.name = name;
            this.sp = sp;
            this.mp = mp;
            this.sprite = sprite;
            this.extra = extra;
            this.bits = bits;
            this.cost = cost;
            this.description = description;
        }
    };
}