using System;

namespace NHeroes2.Maps
{
    public class mp2tile_t
    {
        public UInt16 tileIndex; // tile (ocean, grass, snow, swamp, lava, desert, dirt, wasteland, beach)
        public byte objectName1; // level 1.0
        public byte indexName1; // index level 1.0 or 0xFF
        public byte quantity1; // count
        public byte quantity2; // count
        public byte objectName2; // level 2.0
        public byte indexName2; // index level 2.0 or 0xFF
        public byte shape; // shape reflect % 4, 0 none, 1 vertical, 2 horizontal, 3 any
        public byte generalObject; // zero or object
        public UInt16 indexAddon; // zero or index addons_t
        public UInt32 uniqNumber1; // level 1.0
        public UInt32 uniqNumber2; // level 2.0
    };
}