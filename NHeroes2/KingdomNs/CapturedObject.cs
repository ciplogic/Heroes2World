using NHeroes2.ArmyNs;
using NHeroes2.Maps;

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

        public H2Color GetColor() 
        {
            return objcol.Color;
        }

        Troop GetTroop()
        {
            return guardians;
        }

        public void Set(ObjKind obj, H2Color col)
        {
            objcol.Obj = obj;
            objcol.Color = col;
        }

        public void SetColor(H2Color col)
        {
            objcol.Color = col;
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