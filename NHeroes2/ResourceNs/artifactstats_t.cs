namespace NHeroes2.ResourceNs
{
    /*TYPE0: unique, TYPE1: morale/luck, TYPE2: resource, TYPE3: primary/mp/sp, TYPE4: secskills */


    internal class artifactstats_t
    {
        public byte bits;
        public string description;
        public byte extra;
        public string name;
        public byte type;

        public artifactstats_t(byte bits, byte extra, ArtifactType type, string name, string description)
        {
            this.bits = bits;
            this.extra = extra;
            this.type = (byte) type;
            this.name = name;
            this.description = description;
        }
    }
}