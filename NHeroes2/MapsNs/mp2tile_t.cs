namespace NHeroes2.MapsNs
{
    public class mp2tile_t
    {
        public byte generalObject; // zero or object
        public ushort indexAddon; // zero or index addons_t
        public byte indexName1; // index level 1.0 or 0xFF
        public byte indexName2; // index level 2.0 or 0xFF
        public byte objectName1; // level 1.0
        public byte objectName2; // level 2.0
        public byte quantity1; // count
        public byte quantity2; // count
        public byte shape; // shape reflect % 4, 0 none, 1 vertical, 2 horizontal, 3 any
        public ushort tileIndex; // tile (ocean, grass, snow, swamp, lava, desert, dirt, wasteland, beach)
        public uint uniqNumber1; // level 1.0
        public uint uniqNumber2; // level 2.0
    }
}