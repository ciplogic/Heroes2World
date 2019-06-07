namespace NHeroes2.SystemNs
{
    internal class BitModes
    {
        public uint modes;
        public bool Modes(uint f)
        {
            return (modes & f) != 0;
        }
        public void SetModes(uint f)
        {
            modes |= f;
        }

        public void ResetModes(uint f)
        {
            modes &= ~f;
        }

        void ToggleModes(uint f)
        {
            modes ^= f;
        }

    }
}