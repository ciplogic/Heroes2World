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
        private static readonly World world = World.Instance;
        public Addons addons_level1 = new Addons();
        public Addons addons_level2 = new Addons(); // 16

        public byte fog_colors = 0;

        public ColorKind FogColorsKind = 0;

        public uint maps_index;
        public byte mp2_object;
        public ushort pack_sprite_index;
        public byte quantity1;
        public byte quantity2;
        public byte quantity3;
        public DirectionType tile_passable = 0;

        public void Init(int index, mp2tile_t mp2)
        {
            tile_passable = DirectionType.DIRECTION_ALL;
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
            return (ushort) ((shape << 14) | (0x3FFF & index));
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
            addons_level1._items.Sort((ta1, ta2) => ta1.level % 4 > ta2.level % 4 ? 1 : -1);
            addons_level2._items.Sort((ta1, ta2) => ta1.level % 4 > ta2.level % 4 ? 1 : -1);
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
            return (ObjKind) mp2_object;
        }

        public int GetIndex()
        {
            return (int) maps_index;
        }

        public TilesAddon FindObjectConst(ObjKind objHeroes)
        {
            throw new NotImplementedException();
        }

        public static void FixedPreload(Tiles tile)
        {
            // fix skeleton: left position
            var it = tile.addons_level1._items.FirstOrDefault(addon => TilesAddon.isSkeletonFix(addon));

            if (it != null) tile.SetObject((byte) ObjKind.OBJN_SKELETON);

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
            if (hero != null)
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
                {
                    SetObject((byte) ObjKind.OBJ_ZERO);
                }

                SetQuantity3(0);
            }
        }

        public bool isObject(ObjKind obj)
        {
            return obj == (ObjKind) mp2_object;
        }

        public uint TileSpriteIndex()
        {
            return (uint) (pack_sprite_index & 0x3FFF);
        }

        public uint TileSpriteShape()
        {
            return (uint) (pack_sprite_index >> 14);
        }

        public bool GoodForUltimateArtifact()
        {
            if (isWater())
                return false;

            throw new NotImplementedException();
        }

        private bool isWater()
        {
            return 30 > TileSpriteIndex();
        }

        public H2Point GetCenter()
        {
            throw new NotImplementedException();
        }

        public void UpdatePassable()
        {
        }

        internal Heroes GetHeroes()
        {
            var world = World.Instance;
            return ObjKind.OBJ_HEROES == (ObjKind) mp2_object && GetQuantity3() != 0
                ? world.GetHeroes(GetQuantity3() - 1)
                : null;
        }

        public bool isPassable(Heroes hero, DirectionType direct, bool skipfog)
        {
            if (!skipfog && isFog(H2Settings.Get().CurrentColor()))
                return false;

            return !(hero != null && !isPassable(hero)) && (direct & tile_passable) != 0;
        }

        private bool isPassable(Heroes hero)
        {
            if (hero.isShipMaster()) return isWater() && ObjKind.OBJ_BOAT != GetObject();
            if (!isWater())
                return true;
            switch (GetObject())
            {
                // fix shipwreck: place on water
                case ObjKind.OBJ_SHIPWRECK:
                    // check later
                    break;

                // for: meetings/attack hero
                case ObjKind.OBJ_HEROES:
                {
                    // scan ground
                    var v = new MapsIndexes();
                    GetAroundIndexes(GetIndex(), v);
                    if (v.Any(it => { return TileIsGround(it, GroundType.WATER); }))
                        return false;
                }
                    break;

                default:
                    // ! hero->isShipMaster() && isWater()
                    return false;
            }

            return true;
        }

        private bool TileIsGround(int index, GroundType ground)
        {
            return ground == world.GetTiles(index).GetGround();
        }

        private GroundType GetGround()
        {
            var index = TileSpriteIndex();

            // list grounds from GROUND32.TIL
            if (30 > index)
                return GroundType.WATER;
            if (92 > index)
                return GroundType.GRASS;
            if (146 > index)
                return GroundType.SNOW;
            if (208 > index)
                return GroundType.SWAMP;
            if (262 > index)
                return GroundType.LAVA;
            if (321 > index)
                return GroundType.DESERT;
            if (361 > index)
                return GroundType.DIRT;
            if (415 > index)
                return GroundType.WASTELAND;

            //else if(432 > pack_sprite_index)

            return GroundType.BEACH;
        }

        private void GetAroundIndexes(int center, MapsIndexes result)
        {
            result.Clear();
            if (!isValidAbsIndex(center)) return;

            var directions = Direction.All();

            var world = World.Instance;
            var wSize = new H2Size(world.w(), world.h());
            foreach (var direction in directions)
                if (isValidDirection(center, direction, wSize))
                    result.Add(GetDirectionIndex(center, direction));
        }

        private int GetDirectionIndex(int from, DirectionType vector)
        {
            switch (vector)
            {
                case DirectionType.TOP:
                    return from - world.w();
                case DirectionType.TOP_RIGHT:
                    return from - world.w() + 1;
                case DirectionType.RIGHT:
                    return from + 1;
                case DirectionType.BOTTOM_RIGHT:
                    return from + world.w() + 1;
                case DirectionType.BOTTOM:
                    return from + world.w();
                case DirectionType.BOTTOM_LEFT:
                    return from + world.w() - 1;
                case DirectionType.LEFT:
                    return from - 1;
                case DirectionType.TOP_LEFT:
                    return from - world.w() - 1;
            }

            return -1;
        }

        private bool isValidDirection(int from, DirectionType vector, H2Size world)
        {
            switch (vector)
            {
                case DirectionType.TOP:
                    return from >= world.W;
                case DirectionType.RIGHT:
                    return from % world.W < world.W - 1;
                case DirectionType.BOTTOM:
                    return from < world.W * (world.H - 1);
                case DirectionType.LEFT:
                    return from % world.W != 0;

                case DirectionType.TOP_RIGHT:
                    return from >= world.W && from % world.W < world.W - 1;

                case DirectionType.BOTTOM_RIGHT:
                    return from < world.W * (world.H - 1) && from % world.W < world.W - 1;

                case DirectionType.BOTTOM_LEFT:
                    return from < world.W * (world.H - 1) && from % world.W != 0;

                case DirectionType.TOP_LEFT:
                    return from >= world.W && from % world.W != 0;
            }

            return false;
        }

        private bool isValidAbsIndex(int ii)
        {
            return 0 <= ii && ii < world.w() * world.h();
        }

        private bool isFog(int colors)
        {
            // colors may be the union friends
            return (fog_colors & colors) == colors;
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