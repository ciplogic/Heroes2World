using NHeroes2.ArmyNs;
using NHeroes2.MapsNs;

namespace NHeroes2.KingdomNs
{
    internal class CapturedObject
    {
        public ObjectColor objcol = new ObjectColor();
        public Troop guardians;
        public int split = 1;
        int GetSplit() 
        {
            return split;
        }

        public ObjKind GetObject() 
        {
            return objcol.Obj;
        }

        public ColorKind GetColor() 
        {
            return objcol.ColorKind;
        }

        Troop GetTroop()
        {
            return guardians;
        }

        public void Set(ObjKind obj, ColorKind col)
        {
            objcol.Obj = obj;
            objcol.ColorKind = col;
        }

        public void SetColor(ColorKind col)
        {
            objcol.ColorKind = col;
        }

        void SetSplit(int spl)
        {
            split = spl;
        }

        bool GuardiansProtected() 
        {
            return guardians.IsValid();
        }
    }
}