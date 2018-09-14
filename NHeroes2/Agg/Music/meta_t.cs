using System;

namespace NHeroes2.Agg.Music
{
    class meta_t
    {
        public meta_t()
        {
        }

        public meta_t(byte c, byte q, UInt32 d)
        {
            command = c;
            quantity = q;
            duration = d;

        }

        public bool LessThan(meta_t m) 
        {
            return duration < m.duration;
        }

        public void decrease_duration(UInt32 delta)
        {
            duration -= delta;
        }

        public byte command = 0;
        public byte  quantity = 0;
        public UInt32 duration = 0;
    };
}