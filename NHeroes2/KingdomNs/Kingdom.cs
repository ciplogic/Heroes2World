using System.Collections.Generic;
using NHeroes2.CastleNs;
using NHeroes2.HeroesNs;
using NHeroes2.MapsNs;
using NHeroes2.ResourceNs;

namespace NHeroes2.KingdomNs
{
    class Kingdom
    {
        int color;
        Funds resource;

        uint lost_town_days;

        KingdomCastles castles;
        KingdomHeroes heroes;

        Recruits recruits;
        LastLoseHero lost_hero;

        List<IndexObject> visit_object = new List<IndexObject>();

        Puzzle puzzle_maps;
        uint visited_tents_colors;

        KingdomHeroes heroes_cond_loss;
        public RaceType GetRace()
        {
            throw new System.NotImplementedException();
        }

        public bool AllowRecruitHero(bool b, int i)
        {
            throw new System.NotImplementedException();
        }

        public KingdomCastles GetCastles()
        {
            throw new System.NotImplementedException();
        }

        public void AddHeroes(Heroes heroe)
        {
            throw new System.NotImplementedException();
        }

        public void AddCastle(Castle castle)
        {
            throw new System.NotImplementedException();
        }
    }
}