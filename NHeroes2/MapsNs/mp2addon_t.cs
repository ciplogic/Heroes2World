using System;

namespace NHeroes2.MapsNs
{
    public class mp2addon_t
    {
        public UInt16 indexAddon; // zero or next addons_t
        public byte objectNameN1; // level 1.N
        public byte indexNameN1; // level 1.N or 0xFF
        public byte quantityN; //
        public byte objectNameN2; // level 2.N
        public byte indexNameN2; // level 1.N or 0xFF
        public UInt32 uniqNumberN1; // level 1.N
        public UInt32 uniqNumberN2; // level 2.N
    }
}