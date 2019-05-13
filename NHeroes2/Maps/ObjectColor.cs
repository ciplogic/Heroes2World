using NHeroes2.KingdomNs;

namespace NHeroes2.Maps
{
    class ObjectColor
    {
        public ObjectColor()
        {
            Obj = ObjKind.OBJ_ZERO;
            Color = H2Color.NONE;
        }

        public ObjectColor(ObjKind obj, H2Color color)
        {
            Obj = obj;
            Color = color;
        }

        public ObjKind Obj { get; set; }
        public H2Color Color { get; set; }


        public bool isObject(ObjKind obj) 
        {
            return obj == Obj;
        }

        public bool isColor(H2Color colors)
        {
            return colors == Color;
        }
    }
}
