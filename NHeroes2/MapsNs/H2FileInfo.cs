using NHeroes2.KingdomNs;

namespace NHeroes2.MapsNs
{
    class H2FileInfo
    {
        public string file;
        public string name;
        public string description;

        public ushort size_w;
        public ushort size_h;
        public byte difficulty;
        public byte[] races = new byte[Kingdoms.KINGDOMMAX];
        public byte[] unions = new byte[Kingdoms.KINGDOMMAX];

        public byte kingdom_colors;
        public byte allow_human_colors;
        public byte allow_comp_colors;
        public byte rnd_races;

        public byte conditions_wins; // 0: wins def, 1: town, 2: hero, 3: artifact, 4: side, 5: gold
        public bool comp_also_wins;
        public bool allow_normal_victory;
        public ushort wins1;
        public ushort wins2;
        public byte conditions_loss; // 0: loss def, 1: town, 2: hero, 3: out time
        public ushort loss1;
        public ushort loss2;

        public uint localtime;

        public bool with_heroes;
    }
}
