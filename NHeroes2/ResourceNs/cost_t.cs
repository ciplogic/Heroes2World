using System;

namespace NHeroes2.ResourceNs
{
    class cost_t
    {
        public ushort gold;
        public byte wood;
        public byte mercury;
        public byte ore;
        public byte sulfur;
        public byte crystal;
        public byte gems;

        public cost_t(ushort gold, byte wood, byte mercury, byte ore, byte sulfur, byte crystal, byte gems)
        {
            this.gold = gold;
            this.wood = wood;
            this.mercury = mercury;
            this.ore = ore;
            this.sulfur = sulfur;
            this.crystal = crystal;
            this.gems = gems;
        }
        
        public static cost_t COST_NONE = new cost_t(0,0,0,0,0,0,0);
    }
}