using NHeroes2.ArmyNs;
using NHeroes2.MapsNs;

namespace NHeroes2.KingdomNs
{
    internal class CapturedObject
    {
        public Troop guardians;
        public ObjectColor objcol = new ObjectColor();
        public int split = 1;

        private int GetSplit()
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

        private Troop GetTroop()
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

        private void SetSplit(int spl)
        {
            split = spl;
        }

        private bool GuardiansProtected()
        {
            return guardians.IsValid();
        }
    }
}