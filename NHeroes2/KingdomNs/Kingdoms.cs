using System;
using System.Collections.Generic;
using NHeroes2.CastleNs;
using NHeroes2.Engine;
using NHeroes2.HeroesNs;
using NHeroes2.MapsNs;
using NHeroes2.ResourceNs;
using NHeroes2.Utilities;

namespace NHeroes2.KingdomNs
{
    class Kingdoms
    {
        
        int color;
        Funds resource;

        uint lost_town_days;

        KingdomCastles castles;
        KingdomHeroes heroes;

        Recruits recruits;
        LastLoseHero lost_hero;

        List<IndexObject>visit_object = new List<IndexObject>();

        Puzzle puzzle_maps;
        uint visited_tents_colors;

        KingdomHeroes heroes_cond_loss;
        public const int KINGDOMMAX = 6;

        public Kingdom[] kingdoms = new Kingdom[KINGDOMMAX + 1];

        public void AddHeroes(AllHeroes heroes)
        {
            heroes.ForEach(heroe =>
            {
                if (heroe.GetColor()!=0) GetKingdom((ColorKind) heroe.GetColor()).AddHeroes(heroe);
            });
            // skip gray color
            
        }

        Kingdom GetKingdom(ColorKind color)
        {
            switch ((ColorKind)color)
            {
                case ColorKind.BLUE:
                    return kingdoms[0];
                case ColorKind.GREEN:
                    return kingdoms[1];
                case ColorKind.RED:
                    return kingdoms[2];
                case ColorKind.YELLOW:
                    return kingdoms[3];
                case ColorKind.ORANGE:
                    return kingdoms[4];
                case ColorKind.PURPLE:
                    return kingdoms[5];
                default:
                    break;
            }

            return kingdoms[6];
        }

        public void AddCastles(AllCastles castles)
        {
            castles._items.ForEach(castle =>
            {
                // skip gray color
                if (castle.GetColor()!=0)
                    GetKingdom(castle.GetColor()).AddCastle(castle);
            });
        }

        public void ApplyPlayWithStartingHero()
        {
            var world = World.Instance;
            if (isPlay() && !castles._items.empty())
            {
                // get first castle
                Castle first = castles.GetFirstCastle();
                if (null == first) first = castles._items.front();

                // check manual set hero (castle position + point(0, 1))?
                var cp = first.Position.center;
                var hero = world.GetTiles(cp.x, cp.y + 1).GetHeroes();

                // and move manual set hero to castle
                if (hero != null && hero.GetColor() == GetColor())
                {
                    bool patrol = hero.Modes(HeroesFlags.PATROL);
                    hero.SetFreeman(0);
                    hero.Recruit(first);

                    if (patrol)
                    {
                        hero.SetModes(KingdomNs.HeroesFlags.PATROL);
                        hero.SetCenterPatrol(cp);
                    }
                }
                else if (SystemNs.H2Settings.Instance.GameStartWithHeroes())
                {
                    hero = world.GetFreemanHeroes(first.GetRace());
                    if (hero != null && AllowRecruitHero(false, 0)) hero.Recruit(first);
                }
            }
        }

        private bool AllowRecruitHero(bool b, int i)
        {
            throw new NotImplementedException();
        }

        private int GetColor()
        {
            throw new NotImplementedException();
        }

        private bool isPlay()
        {
            throw new NotImplementedException();
        }

        public void AddCondLossHeroes(AllHeroes vecHeroes)
        {
            throw new NotImplementedException();
        }
    }
}
