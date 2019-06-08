using NHeroes2.KingdomNs;
using static NHeroes2.SpellNs.SpellStats;

namespace NHeroes2.SpellNs
{
    public class Spell
    {
        public Spell(SpellType id = SpellType.NONE)
        {
            Id = id > SpellType.STONE ? SpellType.NONE : id;
        }

        public SpellType Id { get; }

        public string Name =>
            spells[(int) Id].name;

        public string Description =>
            spells[(int) Id].description;

        public int Level
        {
            get
            {
                switch (Id)
                {
                    case SpellType.BLESS:
                    case SpellType.BLOODLUST:
                    case SpellType.CURE:
                    case SpellType.CURSE:
                    case SpellType.DISPEL:
                    case SpellType.HASTE:
                    case SpellType.ARROW:
                    case SpellType.SHIELD:
                    case SpellType.SLOW:
                    case SpellType.STONESKIN:

                    case SpellType.VIEWMINES:
                    case SpellType.VIEWRESOURCES:
                        return 1;

                    case SpellType.BLIND:
                    case SpellType.COLDRAY:
                    case SpellType.DEATHRIPPLE:
                    case SpellType.DISRUPTINGRAY:
                    case SpellType.DRAGONSLAYER:
                    case SpellType.LIGHTNINGBOLT:
                    case SpellType.STEELSKIN:

                    case SpellType.HAUNT:
                    case SpellType.SUMMONBOAT:
                    case SpellType.VIEWARTIFACTS:
                    case SpellType.VISIONS:
                        return 2;

                    case SpellType.ANIMATEDEAD:
                    case SpellType.ANTIMAGIC:
                    case SpellType.COLDRING:
                    case SpellType.DEATHWAVE:
                    case SpellType.EARTHQUAKE:
                    case SpellType.FIREBALL:
                    case SpellType.HOLYWORD:
                    case SpellType.MASSBLESS:
                    case SpellType.MASSCURSE:
                    case SpellType.MASSDISPEL:
                    case SpellType.MASSHASTE:
                    case SpellType.PARALYZE:
                    case SpellType.TELEPORT:

                    case SpellType.IDENTIFYHERO:
                    case SpellType.VIEWHEROES:
                    case SpellType.VIEWTOWNS:
                        return 3;

                    case SpellType.BERSERKER:
                    case SpellType.CHAINLIGHTNING:
                    case SpellType.ELEMENTALSTORM:
                    case SpellType.FIREBLAST:
                    case SpellType.HOLYSHOUT:
                    case SpellType.MASSCURE:
                    case SpellType.MASSSHIELD:
                    case SpellType.MASSSLOW:
                    case SpellType.METEORSHOWER:
                    case SpellType.RESURRECT:

                    case SpellType.SETEGUARDIAN:
                    case SpellType.SETAGUARDIAN:
                    case SpellType.SETFGUARDIAN:
                    case SpellType.SETWGUARDIAN:
                    case SpellType.TOWNGATE:
                    case SpellType.VIEWALL:
                        return 4;

                    case SpellType.ARMAGEDDON:
                    case SpellType.HYPNOTIZE:
                    case SpellType.MIRRORIMAGE:
                    case SpellType.RESURRECTTRUE:
                    case SpellType.SUMMONEELEMENT:
                    case SpellType.SUMMONAELEMENT:
                    case SpellType.SUMMONFELEMENT:
                    case SpellType.SUMMONWELEMENT:

                    case SpellType.DIMENSIONDOOR:
                    case SpellType.TOWNPORTAL:
                        return 5;
                }

                return 0;
            }
        }

        public bool isCombat
        {
            get
            {
                switch (Id)
                {
                    case SpellType.NONE:
                    case SpellType.VIEWMINES:
                    case SpellType.VIEWRESOURCES:
                    case SpellType.VIEWARTIFACTS:
                    case SpellType.VIEWTOWNS:
                    case SpellType.VIEWHEROES:
                    case SpellType.VIEWALL:
                    case SpellType.IDENTIFYHERO:
                    case SpellType.SUMMONBOAT:
                    case SpellType.DIMENSIONDOOR:
                    case SpellType.TOWNGATE:
                    case SpellType.TOWNPORTAL:
                    case SpellType.VISIONS:
                    case SpellType.HAUNT:
                    case SpellType.SETEGUARDIAN:
                    case SpellType.SETAGUARDIAN:
                    case SpellType.SETFGUARDIAN:
                    case SpellType.SETWGUARDIAN:
                        return false;
                }

                return true;
            }
        }

        public uint Damage
        {
            get
            {
                switch (Id)
                {
                    case SpellType.ARROW:
                    case SpellType.FIREBALL:
                    case SpellType.FIREBLAST:
                    case SpellType.LIGHTNINGBOLT:
                    case SpellType.COLDRING:
                    case SpellType.DEATHWAVE:
                    case SpellType.HOLYWORD:
                    case SpellType.CHAINLIGHTNING:
                    case SpellType.ARMAGEDDON:
                    case SpellType.ELEMENTALSTORM:
                    case SpellType.METEORSHOWER:
                    case SpellType.COLDRAY:
                    case SpellType.HOLYSHOUT:
                    case SpellType.DEATHRIPPLE:
                        return spells[(int) Id].extra;
                }

                return 0;
            }
        }

        public uint InlIndexSprite
        {
            get
            {
                switch (Id)
                {
                    case SpellType.HASTE:
                    case SpellType.MASSHASTE:
                        return 0;
                    case SpellType.SLOW:
                    case SpellType.MASSSLOW:
                        return 1;
                    case SpellType.BLIND:
                        return 2;
                    case SpellType.BLESS:
                    case SpellType.MASSBLESS:
                        return 3;
                    case SpellType.CURSE:
                    case SpellType.MASSCURSE:
                        return 4;
                    case SpellType.BERSERKER:
                        return 5;
                    case SpellType.PARALYZE:
                        return 6;
                    case SpellType.HYPNOTIZE:
                        return 7;
                    case SpellType.DRAGONSLAYER:
                        return 8;
                    case SpellType.BLOODLUST:
                        return 9;
                    case SpellType.SHIELD:
                    case SpellType.MASSSHIELD:
                        return 10;
                    case SpellType.STONE:
                        return 11;
                    case SpellType.ANTIMAGIC:
                        return 12;
                    case SpellType.STONESKIN:
                        return 13;
                    case SpellType.STEELSKIN:
                        return 14;
                }

                return 0;
            }
        }

        public uint Restore
        {
            get
            {
                switch (Id)
                {
                    case SpellType.CURE:
                    case SpellType.MASSCURE:
                        return spells[(int) Id].extra;
                }

                return Resurrect;
            }
        }

        public uint Resurrect
        {
            get
            {
                switch (Id)
                {
                    case SpellType.ANIMATEDEAD:
                    case SpellType.RESURRECT:
                    case SpellType.RESURRECTTRUE:
                        return spells[(int) Id].extra;
                }

                return 0;
            }
        }

        public bool isRestore
            => Restore != 0;

        public bool isResurrect
            => Resurrect != 0;

        public bool isUndeadOnly
        {
            get
            {
                switch (Id)
                {
                    case SpellType.ANIMATEDEAD:
                    case SpellType.HOLYWORD:
                    case SpellType.HOLYSHOUT:
                        return true;
                }

                return false;
            }
        }

        public bool isALiveOnly
        {
            get
            {
                switch (Id)
                {
                    case SpellType.BLESS:
                    case SpellType.MASSBLESS:
                    case SpellType.CURSE:
                    case SpellType.MASSCURSE:
                    case SpellType.DEATHRIPPLE:
                    case SpellType.DEATHWAVE:
                    case SpellType.RESURRECT:
                    case SpellType.RESURRECTTRUE:
                        return true;
                }

                return false;
            }
        }

        public bool isSummon
        {
            get
            {
                switch (Id)
                {
                    case SpellType.SUMMONEELEMENT:
                    case SpellType.SUMMONAELEMENT:
                    case SpellType.SUMMONFELEMENT:
                    case SpellType.SUMMONWELEMENT:
                        return true;

                    default:
                        return false;
                }
            }
        }

        public bool isApplyToFriends
        {
            get
            {
                switch (Id)
                {
                    case SpellType.BLESS:
                    case SpellType.BLOODLUST:
                    case SpellType.CURE:
                    case SpellType.HASTE:
                    case SpellType.SHIELD:
                    case SpellType.STONESKIN:
                    case SpellType.DRAGONSLAYER:
                    case SpellType.STEELSKIN:
                    case SpellType.ANIMATEDEAD:
                    case SpellType.ANTIMAGIC:
                    case SpellType.TELEPORT:
                    case SpellType.RESURRECT:
                    case SpellType.MIRRORIMAGE:
                    case SpellType.RESURRECTTRUE:

                    case SpellType.MASSBLESS:
                    case SpellType.MASSCURE:
                    case SpellType.MASSHASTE:
                    case SpellType.MASSSHIELD:
                        return true;

                    default:
                        return false;
                }
            }
        }

        public bool isMassActions
        {
            get
            {
                switch (Id)
                {
                    case SpellType.MASSCURE:
                    case SpellType.MASSHASTE:
                    case SpellType.MASSSLOW:
                    case SpellType.MASSBLESS:
                    case SpellType.MASSCURSE:
                    case SpellType.MASSDISPEL:
                    case SpellType.MASSSHIELD:
                        return true;
                }

                return false;
            }
        }

        public bool isApplyToEnemies
        {
            get
            {
                switch (Id)
                {
                    case SpellType.MASSSLOW:
                    case SpellType.MASSCURSE:

                    case SpellType.CURSE:
                    case SpellType.ARROW:
                    case SpellType.SLOW:
                    case SpellType.BLIND:
                    case SpellType.COLDRAY:
                    case SpellType.DISRUPTINGRAY:
                    case SpellType.LIGHTNINGBOLT:
                    case SpellType.CHAINLIGHTNING:
                    case SpellType.PARALYZE:
                    case SpellType.BERSERKER:
                    case SpellType.HYPNOTIZE:
                        return true;

                    default:
                        return false;
                }
            }
        }

        public bool isRaceCompatible(RaceType race)
        {
            switch (Id)

            {
                case SpellType.MASSCURE:
                case SpellType.MASSBLESS:
                case SpellType.HOLYSHOUT:
                case SpellType.HOLYWORD:
                case SpellType.BLESS:
                case SpellType.CURE:
                    if (RaceType.NECR == race) return false;
                    break;

                case SpellType.DEATHWAVE:
                case SpellType.DEATHRIPPLE:
                case SpellType.ANIMATEDEAD:
                    if (RaceType.NECR != race) return false;
                    break;
            }

            return true;
        }
    }
}