namespace NHeroes2.KingdomNs
{
    internal class H2Color
    {
        public static ColorKind GetFirst(int colors)
        {
            if ((colors & (int) ColorKind.BLUE) != 0) return ColorKind.BLUE;
            if ((colors & (int) ColorKind.GREEN) != 0) return ColorKind.GREEN;
            if ((colors & (int) ColorKind.RED) != 0) return ColorKind.RED;
            if ((colors & (int) ColorKind.YELLOW) != 0) return ColorKind.YELLOW;
            if ((colors & (int) ColorKind.ORANGE) != 0) return ColorKind.ORANGE;
            if ((colors & (int) ColorKind.PURPLE) != 0) return ColorKind.PURPLE;

            return ColorKind.NONE;
        }

        public static int GetIndex(int color)
        {
            switch ((ColorKind) color)
            {
                case ColorKind.BLUE:
                    return 0;
                case ColorKind.GREEN:
                    return 1;
                case ColorKind.RED:
                    return 2;
                case ColorKind.YELLOW:
                    return 3;
                case ColorKind.ORANGE:
                    return 4;
                case ColorKind.PURPLE:
                    return 5;
            }

            // NONE
            return 6;
        }
    }
}