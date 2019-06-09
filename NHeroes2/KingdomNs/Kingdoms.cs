using System;
using System.Collections.Generic;
using NHeroes2.CastleNs;
using NHeroes2.HeroesNs;
using NHeroes2.MapsNs;
using NHeroes2.ResourceNs;
using NHeroes2.SystemNs;
using NHeroes2.Utilities;

namespace NHeroes2.KingdomNs
{
    internal class Kingdoms
    {
        private KingdomCastles castles;

        private int color;
        private KingdomHeroes heroes;

        private KingdomHeroes heroes_cond_loss;

        public List<Kingdom> kingdoms = new List<Kingdom>();
        private LastLoseHero lost_hero;

        private uint lost_town_days;

        private Puzzle puzzle_maps;

        private Recruits recruits;
        private Funds resource;

        private List<IndexObject> visit_object = new List<IndexObject>();
        private uint visited_tents_colors;

        public Kingdoms()
        {
            kingdoms.SetSize(H2Consts.KINGDOMMAX + 1);
        }

        public void AddHeroes(AllHeroes heroes)
        {
            heroes.ForEach(heroe =>
            {
                if (heroe.GetColor() != 0) GetKingdom((ColorKind) heroe.GetColor()).AddHeroes(heroe);
            });
            // skip gray color
        }

        public Kingdom GetKingdom(ColorKind color)
        {
            switch (color)
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
            }

            return kingdoms[6];
        }

        public void AddCastles(AllCastles castles)
        {
            castles._items.ForEach(castle =>
            {
                // skip gray color
                if (castle.GetColor() != 0)
                    GetKingdom(castle.GetColor()).AddCastle(castle);
            });
        }

        public void ApplyPlayWithStartingHero()
        {
            var world = World.Instance;
            if (isPlay() && !castles._items.empty())
            {
                // get first castle
                var first = castles.GetFirstCastle();
                if (null == first) first = castles._items.front();

                // check manual set hero (castle position + point(0, 1))?
                var cp = first.Position.center;
                var hero = world.GetTiles(cp.x, cp.y + 1).GetHeroes();

                // and move manual set hero to castle
                if (hero != null && hero.GetColor() == GetColor())
                {
                    var patrol = hero.Modes(HeroesFlags.PATROL);
                    hero.SetFreeman(0);
                    hero.Recruit(first);

                    if (patrol)
                    {
                        hero.SetModes(HeroesFlags.PATROL);
                        hero.SetCenterPatrol(cp);
                    }
                }
                else if (H2Settings.Instance.GameStartWithHeroes())
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
            return Players.GetPlayerInGame(color);
        }

        public void AddCondLossHeroes(AllHeroes vecHeroes)
        {
            throw new NotImplementedException();
        }
    }
}