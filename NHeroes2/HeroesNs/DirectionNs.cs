using System.Collections.Generic;

namespace NHeroes2.HeroesNs
{
    internal static class Direction
    {
        private static readonly List<DirectionType> directs = new List<DirectionType>
        {
            DirectionType.TOP_LEFT, DirectionType.TOP, DirectionType.TOP_RIGHT, DirectionType.RIGHT,
            DirectionType.BOTTOM_RIGHT, DirectionType.BOTTOM, DirectionType.BOTTOM_LEFT, DirectionType.LEFT
        };

        public static Directions All()
        {
            return new Directions(directs);
        }
    }
}