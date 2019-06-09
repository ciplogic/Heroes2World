namespace NHeroes2.Engine
{
    public class H2Size
    {
        public ushort W, H;

        public H2Size()
        {
        }

        public H2Size(int w, int h)
        {
            W = (ushort) w;
            H = (ushort) h;
        }

        public int w()
        {
            return W;
        }

        public int h()
        {
            return H;
        }
    }
}