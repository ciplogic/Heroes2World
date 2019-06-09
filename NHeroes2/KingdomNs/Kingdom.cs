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
        private readonly KingdomCastles castles = new KingdomCastles();
        private int color;
        private KingdomHeroes heroes = new KingdomHeroes();

        private KingdomHeroes heroes_cond_loss = new KingdomHeroes();
        private LastLoseHero lost_hero = new LastLoseHero();

        private uint lost_town_days;

        private Puzzle puzzle_maps = new Puzzle();

        private Recruits recruits = new Recruits();
        private Funds resource = new Funds();

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
            return castles;
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