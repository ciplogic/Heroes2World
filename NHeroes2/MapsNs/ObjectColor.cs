using NHeroes2.KingdomNs;

namespace NHeroes2.MapsNs
{
    internal class ObjectColor
    {
        public ObjectColor()
        {
            Obj = ObjKind.OBJ_ZERO;
            ColorKind = ColorKind.NONE;
        }

        public ObjectColor(ObjKind obj, ColorKind colorKind)
        {
            Obj = obj;
            ColorKind = colorKind;
        }

        public ObjKind Obj { get; set; }
        public ColorKind ColorKind { get; set; }


        public bool isObject(ObjKind obj)
        {
            return obj == Obj;
        }

        public bool isColor(ColorKind colorsKind)
        {
            return colorsKind == ColorKind;
        }
    }
}