using System;
using NHeroes2.CastleNs;
using NHeroes2.HeroesNs;

namespace NHeroes2.KingdomNs
{
    class Kingdoms
    {
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
            throw new NotImplementedException();
        }

        public void AddCondLossHeroes(AllHeroes vecHeroes)
        {
            throw new NotImplementedException();
        }
    }
}
