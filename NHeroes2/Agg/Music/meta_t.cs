using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NHeroes2.Agg.Music
{

    internal class MetaTComparer : IComparer<meta_t>
    {
        public int Compare(meta_t x, meta_t y)
        {
            Debug.Assert(x != null, nameof(x) + " != null");
            Debug.Assert(y != null, nameof(y) + " != null");
            return (int) x.duration - (int) y.duration;
        }
    }
    
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