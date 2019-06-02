namespace NHeroes2.KingdomNs
{
    class H2Color
    {
        public static ColorKind GetFirst(int colors)
        {
            if ((colors & (int) ColorKind.BLUE)!=0) return ColorKind.BLUE;
            if ((colors & (int) ColorKind.GREEN) != 0) return ColorKind.GREEN;
            if ((colors & (int) ColorKind.RED) != 0) return ColorKind.RED;
            if ((colors & (int) ColorKind.YELLOW) != 0) return ColorKind.YELLOW;
            if ((colors & (int) ColorKind.ORANGE) != 0) return ColorKind.ORANGE;
            if ((colors & (int)ColorKind.PURPLE) != 0) return ColorKind.PURPLE;

            return ColorKind.NONE;
        }
    }
}