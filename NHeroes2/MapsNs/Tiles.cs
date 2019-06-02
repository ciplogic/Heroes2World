using System;
using System.Linq;
using NHeroes2.Agg.Icns;
using NHeroes2.Engine;
using NHeroes2.HeroesNs;
using NHeroes2.KingdomNs;
using NHeroes2.SystemNs;

namespace NHeroes2.MapsNs
{
    public class Tiles
    {
        public Addons addons_level1 = new Addons();
        public Addons addons_level2 = new Addons(); // 16

        public UInt32 maps_index = 0;
        public UInt16 pack_sprite_index = 0;
        public DirectionTypes tile_passable = 0;
        public byte mp2_object = 0;
        public ColorKind FogColorsKind = 0;
        public byte quantity1 = 0;
        public byte quantity2 = 0;
        public byte quantity3 = 0;

        public void Init(int index, mp2tile_t mp2)
        {
            tile_passable = DirectionTypes.DIRECTION_ALL;
            quantity1 = mp2.quantity1;
            quantity2 = mp2.quantity2;
            quantity3 = 0;
            FogColorsKind = ColorKind.ALL;

            SetTile(mp2.tileIndex, mp2.shape);
            SetIndex(index);
            SetObject(mp2.generalObject);

            addons_level1._items.Clear();
            addons_level2._items.Clear();

            AddonsPushLevel1(mp2);
            AddonsPushLevel2(mp2);
        }

        public void SetObject(byte mp2GeneralObject)
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
            return quantity2;
        }

        public int GetQuantity1()
        {
            return quantity1;
        }

        public ObjKind GetObject()
        {
            return (ObjKind) this.mp2_object;
        }

        public int GetIndex()
        {
            throw new System.NotImplementedException();
        }

        public TilesAddon FindObjectConst(ObjKind objHeroes)
        {
            throw new System.NotImplementedException();
        }

        public static void FixedPreload(Tiles tile)
        {
    // fix skeleton: left position
    var it = tile.addons_level1._items.FirstOrDefault(addon => TilesAddon.isSkeletonFix(addon));

    if (it != null)
    {
        tile.SetObject((byte) ObjKind.OBJN_SKELETON);
    }

    // fix price loyalty objects.
    if (!H2Settings.Get().PriceLoyaltyVersion())
        return;
    switch (tile.GetObject())
    {
    case ObjKind.OBJ_UNKNW_79:
    case ObjKind.OBJ_UNKNW_7A:
    case ObjKind.OBJ_UNKNW_F9:
    case ObjKind.OBJ_UNKNW_FA:
        {
            var newobj = ObjKind.OBJ_ZERO;
            it = tile.addons_level1._items.FirstOrDefault(TilesAddon.isX_LOC123);
            if (it != null)
            {
                newobj = TilesAddon.GetLoyaltyObject(it);
            }
            else
            {
                it = tile.addons_level2._items.FirstOrDefault(TilesAddon.isX_LOC123);
                if (it != null)
                    newobj = TilesAddon.GetLoyaltyObject(it);
            }

            if (ObjKind.OBJ_ZERO != newobj)
                tile.SetObject((byte) newobj);
        }
        break;

    default:
        break;
    }
        }

        public void QuantityUpdate()
        {
            //TODO Finish
            
            
        }

        public void QuantityReset()
        {
            //TODO Finish
        }

        public TilesAddon FindAddonICN1(IcnKind minihero)
        {
            //TODO Finish
            return null;
        }

        public void Remove(uint addonUniq)
        {
            throw new NotImplementedException();
        }

        public void SetHeroes(Heroes hero)
        {
            if (hero!=null)
            {
                hero.SetMapsObject((ObjKind) mp2_object);
                SetQuantity3(hero.GetID() + 1);
                SetObject((byte) ObjKind.OBJ_HEROES);
            }
            else
            {
                hero = GetHeroes();

                if (hero != null)
                {
                    SetObject(hero.GetMapsObject());
                    hero.SetMapsObject(ObjKind.OBJ_ZERO);
                }
                else
                    SetObject((byte) ObjKind.OBJ_ZERO);

                SetQuantity3(0);
            }
        }

        public bool isObject(ObjKind objRndultimateartifact)
        {
            throw new NotImplementedException();
        }

        public bool GoodForUltimateArtifact()
        {
            throw new NotImplementedException();
        }

        public H2Point GetCenter()
        {
            throw new NotImplementedException();
        }

        public void UpdatePassable()
        { 
        }

        private Heroes GetHeroes()
        {
            var world = World.Instance;
            return MapsNs.ObjKind.OBJ_HEROES == (ObjKind) mp2_object && GetQuantity3()!=0 
                ? world.GetHeroes(GetQuantity3() - 1) 
                : null;
        }

        private int GetQuantity3()
        {
            return quantity3;
        }

        private void SetQuantity3(int p0)
        {
        }
    }
}