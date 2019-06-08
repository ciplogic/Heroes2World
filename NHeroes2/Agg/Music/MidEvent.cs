using System.Collections.Generic;
using NHeroes2.Serialize;

namespace NHeroes2.Agg.Music
{
    internal class MidEvent
    {
        private readonly byte[] data = new byte[4];
        private readonly byte[] pack;

        static MidEvent()
        {
            ByteVectorReflect.AddTypeWriter((ByteVectorWriter sb, MidEvent st) =>
            {
                foreach (var it in st.pack) sb.put8(it);
                sb.put8(st.data[0]);
                if (2 == st.data[3])
                    sb.put8(st.data[1]).put8(st.data[2]);
                else if (1 == st.data[3])
                    sb.put8(st.data[1]);
            });
        }

        public MidEvent(uint delta, byte st, byte d1, byte d2)
        {
            data[0] = st;
            data[1] = d1;
            data[2] = d2;
            data[3] = 2;
            pack = packValue(delta);
        }

        public MidEvent(uint delta, byte st, byte d1)
        {
            data[0] = st;
            data[1] = d1;
            data[2] = 0;
            data[3] = 1;
            pack = packValue(delta);
        }

        private byte[] packValue(uint delta)
        {
            var c1 = (byte) (delta & 0x0000007F);
            var c2 = (byte) ((delta & 0x00003F80) >> 7);
            var c3 = (byte) ((delta & 0x001FC000) >> 14);
            var c4 = (byte) ((delta & 0x0FE00000) >> 21);

            var res = new List<byte>(4);

            if (c4 != 0)
            {
                res.Add((byte) (c4 | 0x80));
                res.Add((byte) (c3 | 0x80));
                res.Add((byte) (c2 | 0x80));
                res.Add(c1);
            }
            else if (c3 != 0)
            {
                res.Add((byte) (c3 | 0x80));
                res.Add((byte) (c2 | 0x80));
                res.Add(c1);
            }
            else if (c2 != 0)
            {
                res.Add((byte) (c2 | 0x80));
                res.Add(c1);
            }
            else
            {
                res.Add(c1);
            }

            return res.ToArray();
        }

        public int size()
        {
            return pack.Length + data[3] + 1;
        }
    }
}