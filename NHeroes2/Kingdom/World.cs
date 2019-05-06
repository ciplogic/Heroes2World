using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHeroes2.Engine;
using NHeroes2.Game;
using NHeroes2.Serialize;
using NHeroes2.Maps;
using NHeroes2.Utilities;

namespace NHeroes2.Kingdom
{
    class MapsTiles : List<Maps.Tiles>
    {
        
    }
    class World : Size
    {
        MapsTiles vec_tiles = new MapsTiles();
        bool LoadMapMP2(string filename)
        {
            Reset();
            Defaults();
            if (!File.Exists(filename))
            {
                throw new Exception("load maps");
            }
            var vectorBytes = File.ReadAllBytes(filename);
            var fs = new ByteVectorReader(vectorBytes);

            var vec_object = new MapsIndexes(); // index maps for OBJ_CASTLE, OBJ_HEROES, OBJ_SIGN, OBJ_BOTTLE, OBJ_EVENT
            
            // check (mp2, mx2) ID
            if (fs.getBE32() != 0x5C000000)
                return false;

            // endof
            var endof_mp2 = fs.size();
            fs.seek(endof_mp2 - 4);

            // read uniq
            GameStatic.uniq = (uint) fs.getLE32();

            // offset data
            fs.seek(Mp2Consts.MP2OFFSETDATA - 2 * 4);

            // width
            switch ((mapsize_t)(fs.getLE32()))
            {
                case mapsize_t.SMALL:
                    W = (ushort) (mapsize_t.SMALL);
                    break;
                case mapsize_t.MEDIUM:
                    W = (ushort) (mapsize_t.MEDIUM);
                    break;
                case mapsize_t.LARGE:
                    W = (ushort) (mapsize_t.LARGE);
                    break;
                case mapsize_t.XLARGE:
                    W = (ushort) (mapsize_t.XLARGE);
                    break;
                default:
                    W = 0;
                    break;
            }

            // height
            switch ((mapsize_t)(fs.getLE32()))
            {
                case mapsize_t.SMALL:
                    H = (ushort)(mapsize_t.SMALL);
                    break;
                case mapsize_t.MEDIUM:
                    H = (ushort) (mapsize_t.MEDIUM);
                    break;
                case mapsize_t.LARGE:
                    H = (ushort)(mapsize_t.LARGE);
                    break;
                case mapsize_t.XLARGE:
                    H = (ushort)(mapsize_t.XLARGE);
                    break;
                default:
                    H = 0;
                    break;
            }

            if (W == 0 || H == 0 || W != H)
            {
                return false;
            }

            // seek to ADDONS block
            fs.skip(w() * h() * Mp2Consts.SIZEOFMP2TILE);

            // read all addons
            var vec_mp2addons = new List<mp2addon_t>(fs.getLE32() /* count mp2addon_t */);

            foreach (var mp2addon in vec_mp2addons)
            {
                mp2addon.indexAddon = (ushort) fs.getLE16();
                mp2addon.objectNameN1 = (byte) (fs.get() * 2);
                mp2addon.indexNameN1 = (byte) fs.get();
                mp2addon.quantityN = (byte) fs.get();
                mp2addon.objectNameN2 = (byte) fs.get();
                mp2addon.indexNameN2 = (byte) fs.get();

                mp2addon.uniqNumberN1 = (uint) fs.getLE32();
                mp2addon.uniqNumberN2 = (uint) fs.getLE32();
            }

            var endof_addons = fs.tell();
            // offset data
            fs.seek(Mp2Consts.MP2OFFSETDATA);

            vec_tiles.SetSize(w() * h());

            // read all tiles
            int index = -1;
            foreach (var tile in vec_tiles)
            {
                ++index;
                var mp2tile = new mp2tile_t();

                mp2tile.tileIndex = (ushort) fs.getLE16();
                mp2tile.objectName1 = (byte) fs.get();
                mp2tile.indexName1 = (byte) fs.get();
                mp2tile.quantity1 = (byte) fs.get();
                mp2tile.quantity2 = (byte) fs.get();
                mp2tile.objectName2 = (byte) fs.get();
                mp2tile.indexName2 = (byte) fs.get();
                mp2tile.shape = (byte) fs.get();
                mp2tile.generalObject = (byte) fs.get();

                switch ((Mp2Obj)mp2tile.generalObject)
                {
                    case Mp2Obj.OBJ_RNDTOWN:
                    case Mp2Obj.OBJ_RNDCASTLE:
                    case Mp2Obj.OBJ_CASTLE:
                    case Mp2Obj.OBJ_HEROES:
                    case Mp2Obj.OBJ_SIGN:
                    case Mp2Obj.OBJ_BOTTLE:
                    case Mp2Obj.OBJ_EVENT:
                    case Mp2Obj.OBJ_SPHINX:
                    case Mp2Obj.OBJ_JAIL:
                        vec_object.Add(index);
                        break;
                    default:
                        break;
                }

                // offset first addon
                var offsetAddonsBlock = fs.getLE16();

                mp2tile.uniqNumber1 = (uint) fs.getLE32();
                mp2tile.uniqNumber2 = (uint) fs.getLE32();

                tile.Init(index, mp2tile);

                // load all addon for current tils
                while (offsetAddonsBlock!=0)
                {
                    if (vec_mp2addons.Count <= offsetAddonsBlock)
                    {
                        break;
                    }
                    tile.AddonsPushLevel1(vec_mp2addons[offsetAddonsBlock]);
                    tile.AddonsPushLevel2(vec_mp2addons[offsetAddonsBlock]);
                    offsetAddonsBlock = vec_mp2addons[offsetAddonsBlock].indexAddon;
                }

                tile.AddonsSort();
            }
            
            
            
            return false;
        }

        private static void Defaults()
        {
            throw new NotImplementedException();
        }

        private static void Reset()
        {
            throw new NotImplementedException();
        }
    }

    
}

namespace NHeroes2.Game
{
}
