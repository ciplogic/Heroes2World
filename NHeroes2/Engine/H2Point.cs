﻿namespace NHeroes2.Engine
{
    public struct H2Point
    {
        public short x, y;

        public H2Point(int cx, int cy)
        {
            x = (short) cx;
            y = (short) cy;
        }
    }
}
