namespace NHeroes2.ResourceNs
{
    class Funds
    {
        public int wood;
        public int mercury;
        public int ore;
        public int sulfur;
        public int crystal;
        public int gems;
        public int gold;

        Funds(cost_t cost)
        {
            wood=(cost.wood); mercury=(cost.mercury); ore=(cost.ore); sulfur=(cost.sulfur); crystal=(cost.crystal);
            gems=(cost.gems);
            gold = (cost.gold);
        }
    }
}