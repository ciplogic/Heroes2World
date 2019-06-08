using NHeroes2.MonsterNs;
using static NHeroes2.SystemNs.Translation;

namespace NHeroes2.KingdomNs
{
    internal class Week
    {
        private static readonly string[] str_name =
        {
            "Unnamed", _("week|PLAGUE"),
            _("week|Ant"), _("week|Grasshopper"), _("week|Dragonfly"), _("week|Spider"),
            _("week|Butterfly"), _("week|Bumblebee"),
            _("week|Locust"), _("week|Earthworm"), _("week|Hornet"), _("week|Beetle"),
            _("week|Squirrel"), _("week|Rabbit"),
            _("week|Gopher"), _("week|Badger"), _("week|Eagle"), _("week|Weasel"), _("week|Raven"),
            _("week|Mongoose"), _("week|Aardvark"),
            _("week|Lizard"), _("week|Tortoise"), _("week|Hedgehog"), _("week|Condor")
        };

        public WeekKind first;
        public MonsterType second;

        public string Name
        {
            get
            {
                switch (first)
                {
                    case WeekKind.PLAGUE:
                        return str_name[1];
                    case WeekKind.ANT:
                        return str_name[2];
                    case WeekKind.GRASSHOPPER:
                        return str_name[3];
                    case WeekKind.DRAGONFLY:
                        return str_name[4];
                    case WeekKind.SPIDER:
                        return str_name[5];
                    case WeekKind.BUTTERFLY:
                        return str_name[6];
                    case WeekKind.BUMBLEBEE:
                        return str_name[7];
                    case WeekKind.LOCUST:
                        return str_name[8];
                    case WeekKind.EARTHWORM:
                        return str_name[9];
                    case WeekKind.HORNET:
                        return str_name[10];
                    case WeekKind.BEETLE:
                        return str_name[11];
                    case WeekKind.SQUIRREL:
                        return str_name[12];
                    case WeekKind.RABBIT:
                        return str_name[13];
                    case WeekKind.GOPHER:
                        return str_name[14];
                    case WeekKind.BADGER:
                        return str_name[15];
                    case WeekKind.EAGLE:
                        return str_name[16];
                    case WeekKind.WEASEL:
                        return str_name[17];
                    case WeekKind.RAVEN:
                        return str_name[18];
                    case WeekKind.MONGOOSE:
                        return str_name[19];
                    case WeekKind.AARDVARK:
                        return str_name[20];
                    case WeekKind.LIZARD:
                        return str_name[21];
                    case WeekKind.TORTOISE:
                        return str_name[22];
                    case WeekKind.HEDGEHOG:
                        return str_name[23];
                    case WeekKind.CONDOR:
                        return str_name[24];
                    case WeekKind.MONSTERS:
                        return new Monster(second).GetName();
                }

                return str_name[0];
            }
        }
    }
}