using System;
using System.Collections.Generic;
using NHeroes2.CastleNs;
using NHeroes2.HeroesNs;
using NHeroes2.MapsNs;
using NHeroes2.ResourceNs;

namespace NHeroes2.KingdomNs
{
    internal class Kingdom
    {
        private KingdomCastles castles;
        private int color;
        private KingdomHeroes heroes;

        private KingdomHeroes heroes_cond_loss;
        private LastLoseHero lost_hero;

        private uint lost_town_days;

        private Puzzle puzzle_maps;

        private Recruits recruits;
        private Funds resource;

        private List<IndexObject> visit_object = new List<IndexObject>();
        private uint visited_tents_colors;

        public RaceType GetRace()
        {
            throw new NotImplementedException();
        }

        public bool AllowRecruitHero(bool b, int i)
        {
            throw new NotImplementedException();
        }

        public KingdomCastles GetCastles()
        {
            throw new NotImplementedException();
        }

        public void AddHeroes(Heroes heroe)
        {
            throw new NotImplementedException();
        }

        public void AddCastle(Castle castle)
        {
            throw new NotImplementedException();
        }
    }
}