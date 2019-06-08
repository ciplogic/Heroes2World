using System;
using NHeroes2.Engine;
using NHeroes2.KingdomNs;

namespace NHeroes2.MapsNs
{
    internal class MapsStatic
    {
        public static int GetIndexFromAbsPoint(int px, int py)
        {
            var res = py * World.Instance.w() + px;

            if (px < 0 || py < 0) return -1;

            return res;
        }

        public static H2Point GetPoint(int index)
        {
            var world = World.Instance;
            return new H2Point(index % world.W, index / world.W);
        }

        public static void MinimizeAreaForCastle(H2Point getCenter)
        {
            throw new NotImplementedException();
        }

        public static void UpdateRNDSpriteForCastle(H2Point getCenter, RaceType getRace, bool isCastle)
        {
            throw new NotImplementedException();
        }
    }
}