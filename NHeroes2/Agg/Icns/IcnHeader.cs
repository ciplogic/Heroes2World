using System;

namespace NHeroes2.Agg.Icns
{
    public class IcnHeader
    {
        public UInt16 offsetX;
        public UInt16 offsetY;
        public UInt16 width;
        public UInt16 height;
        public byte type;
        public UInt32 offsetData;

    }
}