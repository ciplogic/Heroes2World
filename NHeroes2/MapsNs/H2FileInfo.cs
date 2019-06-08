using NHeroes2.GameNs;
using NHeroes2.SystemNs;

namespace NHeroes2.MapsNs
{
    internal class H2FileInfo
    {
        public byte allow_comp_colors;
        public byte allow_human_colors;
        public bool allow_normal_victory;
        public bool comp_also_wins;
        public byte conditions_loss; // 0: loss def, 1: town, 2: hero, 3: out time

        public byte conditions_wins; // 0: wins def, 1: town, 2: hero, 3: artifact, 4: side, 5: gold
        public string description;
        public byte difficulty;
        public string file;

        public byte kingdom_colors;

        public uint localtime;
        public ushort loss1;
        public ushort loss2;
        public string name;
        public byte[] races = new byte[H2Consts.KINGDOMMAX];
        public byte rnd_races;
        public ushort size_h;

        public ushort size_w;
        public byte[] unions = new byte[H2Consts.KINGDOMMAX];
        public ushort wins1;
        public ushort wins2;

        public bool with_heroes;

        public GameOverCondition ConditionWins()
        {
            switch (conditions_wins)
            {
                case 0:
                    return GameOverCondition.WINS_ALL;
                case 1:
                    return allow_normal_victory
                        ? GameOverCondition.WINS_TOWN | GameOverCondition.WINS_ALL
                        : GameOverCondition.WINS_TOWN;
                case 2:
                    return allow_normal_victory
                        ? GameOverCondition.WINS_HERO | GameOverCondition.WINS_ALL
                        : GameOverCondition.WINS_HERO;
                case 3:
                    return allow_normal_victory
                        ? GameOverCondition.WINS_ARTIFACT | GameOverCondition.WINS_ALL
                        : GameOverCondition.WINS_ARTIFACT;
                case 4:
                    return GameOverCondition.WINS_SIDE;
                case 5:
                    return allow_normal_victory
                        ? GameOverCondition.WINS_GOLD | GameOverCondition.WINS_ALL
                        : GameOverCondition.WINS_GOLD;
            }

            return GameOverCondition.COND_NONE;
        }

        public GameOverCondition ConditionLoss()
        {
            switch (conditions_loss)
            {
                case 0:
                    return GameOverCondition.LOSS_ALL;
                case 1:
                    return GameOverCondition.LOSS_TOWN;
                case 2:
                    return GameOverCondition.LOSS_HERO;
                case 3:
                    return GameOverCondition.LOSS_TIME;
            }

            return GameOverCondition.COND_NONE;
        }
    }
}