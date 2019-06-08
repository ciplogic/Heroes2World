namespace NHeroes2.ResourceNs
{
    internal class Funds
    {
        public int crystal;
        public int gems;
        public int gold;
        public int mercury;
        public int ore;
        public int sulfur;
        public int wood;

        private Funds(cost_t cost)
        {
            wood = cost.wood;
            mercury = cost.mercury;
            ore = cost.ore;
            sulfur = cost.sulfur;
            crystal = cost.crystal;
            gems = cost.gems;
            gold = cost.gold;
        }
    }
}