using System.Collections.Generic;

namespace NHeroes2.HeroesNs
{
    internal class Directions : List<DirectionType>
    {
        public Directions(List<DirectionType> directs)
        {
            Clear();
            AddRange(directs);
        }
    }
}