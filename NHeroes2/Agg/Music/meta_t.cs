using System.Collections.Generic;
using System.Diagnostics;
using NHeroes2.Utilities;

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

    internal class meta_t
    {
        public byte command;
        public uint duration;
        public byte quantity;

        public meta_t()
        {
        }

        public meta_t(byte c, byte q, uint d)
        {
            command = c;
            quantity = q;
            duration = d;
        }

        public bool LessThan(meta_t m)
        {
            return duration < m.duration;
        }

        public void decrease_duration(uint delta)
        {
            duration -= delta;
        }

        public override string ToString()
        {
            return this.SerializeToJsonString();
        }
    }
}