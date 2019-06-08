using NHeroes2.ResourceNs;

namespace NHeroes2.SpellNs
{
    internal class spellstats_t
    {
        public byte bits;
        public cost_t cost;
        public string description;
        public byte extra;
        public ushort mp;
        public string name;
        public byte sp;
        public byte sprite;

        public spellstats_t(string name, byte sp, ushort mp, byte sprite, byte extra, byte bits, cost_t cost,
            string description)
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
    }
}