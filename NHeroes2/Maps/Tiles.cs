using System;
using NHeroes2.HeroesNs;
using NHeroes2.KingdomNs;

namespace NHeroes2.Maps
{
    public class Tiles
    {
        public Addons addons_level1 = new Addons();
        public Addons addons_level2 = new Addons(); // 16

        public UInt32 maps_index = 0;
        public UInt16 pack_sprite_index = 0;
        public DirectionTypes tile_passable = 0;
        public byte mp2_object = 0;
        public H2Color fog_colors = 0;
        public byte quantity1 = 0;
        public byte quantity2 = 0;
        public byte quantity3 = 0;

        public void Init(int index, mp2tile_t mp2)
        {
            tile_passable = DirectionTypes.DIRECTION_ALL;
            quantity1 = mp2.quantity1;
            quantity2 = mp2.quantity2;
            quantity3 = 0;
            fog_colors = H2Color.ALL;

            SetTile(mp2.tileIndex, mp2.shape);
            SetIndex(index);
            SetObject(mp2.generalObject);

            addons_level1._items.Clear();
            addons_level2._items.Clear();

            AddonsPushLevel1(mp2);
            AddonsPushLevel2(mp2);
        }

        private void SetObject(byte mp2GeneralObject)
        {
            mp2_object = mp2GeneralObject;
        }

        private void SetIndex(int index)
        {
            maps_index = (uint) index;
        }

        private void SetTile(ushort mp2TileIndex, byte mp2Shape)
        {
            pack_sprite_index = PackTileSpriteIndex(mp2TileIndex, mp2Shape);
        }

        private ushort PackTileSpriteIndex(int index, int shape)
        {
            return (ushort) (shape << 14 | 0x3FFF & index);
        }

        public void AddonsPushLevel1(mp2tile_t mt)
        {
            if (mt.objectName1 != 0 && mt.indexName1 < 0xFF)
                AddonsPushLevel1(new TilesAddon(0, mt.uniqNumber1, mt.objectName1, mt.indexName1));
        }

        public void AddonsPushLevel1(TilesAddon ta)
        {
            if (TilesAddon.ForceLevel2(ta))
                addons_level2._items.Add(ta);
            else
                addons_level1._items.Add(ta);
        }

        public void AddonsPushLevel1(mp2addon_t ma)
        {
            if (ma.objectNameN1 != 0 && ma.objectNameN1 < 0xFF)
                AddonsPushLevel2(new TilesAddon(ma.quantityN, ma.uniqNumberN1, ma.objectNameN1, ma.indexNameN1));
        }

        public void AddonsPushLevel2(mp2tile_t mt)
        {
            if (mt.objectName2 != 0 && mt.indexName2 < 0xFF)
                AddonsPushLevel2(new TilesAddon(0, mt.uniqNumber2, mt.objectName2, mt.indexName2));
        }

        private void AddonsPushLevel2(TilesAddon ta)
        {
            if (TilesAddon.ForceLevel2(ta))
                addons_level2._items.Add(ta);
            else
                addons_level1._items.Add(ta);
        }

        public void AddonsPushLevel2(mp2addon_t ma)
        {
            if (ma.objectNameN2 != 0 && ma.indexNameN2 < 0xFF)
                AddonsPushLevel2(new TilesAddon(ma.quantityN, ma.uniqNumberN2, ma.objectNameN2, ma.indexNameN2));
        }

        public void AddonsSort()
        {
            addons_level1._items.Sort((ta1, ta2) => (ta1.level % 4) > (ta2.level % 4) ? 1 : -1);
            addons_level2._items.Sort((ta1, ta2) => (ta1.level % 4) > (ta2.level % 4) ? 1 : -1);
        }

        public int GetQuantity2()
        {
            throw new System.NotImplementedException();
        }

        public int GetQuantity1()
        {
            throw new System.NotImplementedException();
        }

        public ObjKind GetObject()
        {
            throw new System.NotImplementedException();
        }

        public int GetIndex()
        {
            throw new System.NotImplementedException();
        }

        public TilesAddon FindObjectConst(ObjKind objHeroes)
        {
            throw new System.NotImplementedException();
        }
    }
}