using NHeroes2.GameNs;
using NHeroes2.KingdomNs;
using NHeroes2.SystemNs;

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
        public byte[] races = new byte[H2Consts.KINGDOMMAX];
        public byte[] unions = new byte[H2Consts.KINGDOMMAX];

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
                default:
                    break;
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
                default:
                    break;
            }

            return GameOverCondition.COND_NONE;
        }
    }
}
