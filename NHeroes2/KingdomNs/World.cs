using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HeroesWorld.Engine.Graphical;
using NHeroes2.CastleNs;
using NHeroes2.Engine;
using NHeroes2.Game;
using NHeroes2.HeroesNs;
using NHeroes2.Kingdom;
using NHeroes2.Maps;
using NHeroes2.Serialize;
using NHeroes2.Utilities;

namespace NHeroes2.KingdomNs
{
    class World : H2Size
    {
        MapsTiles vec_tiles = new MapsTiles();
        AllCastles vec_castles = new AllCastles();

        AllHeroes vec_heroes = new AllHeroes();
        CapturedObjects map_captureobj = new CapturedObjects();


        MapObjects map_objects = new MapObjects();
        MapActions map_actions = new MapActions();
        EventsDate vec_eventsday = new EventsDate();
        Rumors vec_rumors = new Rumors();

        private Castle GetCastle(H2Point getPoint)
        {
            throw new NotImplementedException();
        }



        private KingdomNs.Kingdom GetKingdom(H2Color color)
        {
            throw new NotImplementedException();
        }

        private Heroes GetFreemanHeroes(RaceType race)
        {
            throw new NotImplementedException();
        }

        private void PostLoad()
        {
            throw new NotImplementedException();
        }

        private static void Defaults()
        {
            throw new NotImplementedException();
        }

        private static void Reset()
        {
            throw new NotImplementedException();
        }

        public bool LoadMapMP2(string filename)
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


            // after addons
            fs.seek(endof_addons);

            // cood castles
            // 72 x 3 byte (cx, cy, id)
            for (UInt32 ii = 0; ii < 72; ++ii)
            {
                int cx = fs.get();
               int cy = fs.get();
                int id = fs.get();

                // empty block
                if (0xFF == cx && 0xFF == cy) continue;

                switch (id)
            {
                case 0x00: // tower: knight
                case 0x80: // castle: knight
                    vec_castles._items.Add(new Castle(cx, cy, RaceType.KNGT));
                    break;

                case 0x01: // tower: barbarian
                case 0x81: // castle: barbarian
                    vec_castles._items.Add(new Castle(cx, cy, RaceType.BARB));
                    break;

                case 0x02: // tower: sorceress
                case 0x82: // castle: sorceress
                    vec_castles._items.Add(new Castle(cx, cy, RaceType.SORC));
                    break;

                case 0x03: // tower: warlock
                case 0x83: // castle: warlock
                    vec_castles._items.Add(new Castle(cx, cy, RaceType.WRLK));
                    break;

                case 0x04: // tower: wizard
                case 0x84: // castle: wizard
                    vec_castles._items.Add(new Castle(cx, cy, RaceType.WZRD));
                    break;

                case 0x05: // tower: necromancer
                case 0x85: // castle: necromancer
                    vec_castles._items.Add(new Castle(cx, cy, RaceType.NECR));
                    break;

                case 0x06: // tower: random
                case 0x86: // castle: random
                    vec_castles._items.Add(new Castle(cx, cy, RaceType.NONE));
                    break;

                default:
                    break;
            }
            // preload in to capture objects cache
            map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), Mp2Obj.OBJ_CASTLE, H2Color.NONE);
        }

        fs.seek(endof_addons + 72 * 3);

    // cood resource kingdoms
    // 144 x 3 byte (cx, cy, id)
    for (UInt32 ii = 0; ii< 144; ++ii)
    {
        int cx = fs.get();
        int cy = fs.get();
        int id = fs.get();

        // empty block
        if (0xFF == cx &&  0xFF == cy) continue;

        switch (id)
        {
            // mines: wood
        case 0x00:
            map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), Mp2Obj.OBJ_SAWMILL, H2Color.NONE);
            break;
            // mines: mercury
        case 0x01:
            map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), Mp2Obj.OBJ_ALCHEMYLAB, H2Color.NONE);
            break;
            // mines: ore
        case 0x02:
            // mines: sulfur
        case 0x03:
            // mines: crystal
        case 0x04:
            // mines: gems
        case 0x05:
            // mines: gold
        case 0x06:
            map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), Mp2Obj.OBJ_MINES, H2Color.NONE);
            break;
            // lighthouse
        case 0x64:
            map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), Mp2Obj.OBJ_LIGHTHOUSE, H2Color.NONE);
            break;
            // dragon city
        case 0x65:
            map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), Mp2Obj.OBJ_DRAGONCITY, H2Color.NONE);
            break;
            // abandoned mines
        case 0x67:
            map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), Mp2Obj.OBJ_ABANDONEDMINE, H2Color.NONE);
            break;
        default:
            break;
        }
}

fs.seek(endof_addons + 72 * 3 + 144 * 3);

    // byte: num obelisks (01 default)
    fs.skip(1);

    // count final mp2 blocks
    UInt32 countblock = 0;
    while (true)
    {
        int l = fs.get();
        int h = fs.get();

        if (0 == h && 0 == l) break;
        countblock = (uint) (256 * h + l - 1);
    }

    // castle or heroes or (events, rumors, etc)
    for (UInt32 ii = 0; ii<countblock; ++ii)
    {
        int findobject = -1;

        // read block
        var sizeblock = fs.getLE16();
        var pblock = fs.getRaw(sizeblock);

        for (var it_index = 0; it_index != vec_object.Count && findobject < 0; ++it_index)
        {
            Maps.Tiles tile = vec_tiles[it_index];

            // orders(quantity2, quantity1)
            int orders = tile.GetQuantity2() != 0 ? tile.GetQuantity2() : 0;
            orders <<= 8;
            orders |= tile.GetQuantity1();


            if (orders != 0 && (orders % 0x08 == 0) && (ii + 1 == orders / 0x08))
                findobject = it_index;
        }

        if (0 <= findobject)
        {
            Maps.Tiles tile = vec_tiles[findobject];
            TilesAddon addon = null;

            switch (tile.GetObject())
            {
            case Mp2Obj.OBJ_CASTLE:
                // add castle
                if (Mp2Consts. SIZEOFMP2CASTLE != pblock.Length)
                {
                }
                else
                {
                    Castle castle = GetCastle(MapsStatic.GetPoint(findobject));
                    if (castle != null)
                    {
                        ByteVectorReader bvr = new ByteVectorReader(pblock);
                        castle.LoadFromMP2(bvr);
                        MapsStatic.MinimizeAreaForCastle(castle.GetCenter());
                        map_captureobj.SetColor(tile.GetIndex(), castle.GetColor());
                    }
                }

                break;
            case Mp2Obj.OBJ_RNDTOWN:
            case Mp2Obj.OBJ_RNDCASTLE:
                            // add rnd castle
                            if (Mp2Consts.SIZEOFMP2CASTLE != pblock.Length)
                            {}
                            else
                            {
                                Castle castle = GetCastle(MapsStatic.GetPoint(findobject));
                                if (castle != null)
                                {
                                    ByteVectorReader bvr = new ByteVectorReader(pblock);
                                    castle.LoadFromMP2(bvr);
                                    MapsStatic.UpdateRNDSpriteForCastle(castle.GetCenter(), castle.GetRace(),
                                        castle.isCastle());
                                    MapsStatic.MinimizeAreaForCastle(castle.GetCenter());
                                    map_captureobj.SetColor(tile.GetIndex(), castle.GetColor());
                                }
                                else
                                {
                                }
                            }

                            break;
            case Mp2Obj.OBJ_JAIL:
                // add jail
                if (Mp2Consts.SIZEOFMP2HEROES != pblock.Length)
                {
                }
                else
                {
                    RaceType race = RaceType.KNGT;
                    switch (pblock[0x3c])
                    {
                    case 1:
                        race = RaceType.BARB;
                        break;
                    case 2:
                        race = RaceType.SORC;
                        break;
                    case 3:
                        race = RaceType.WRLK;
                        break;
                    case 4:
                        race = RaceType.WZRD;
                        break;
                    case 5:
                        race = RaceType.NECR;
                        break;
                    default:
                        break;
                    }

                    Heroes hero = GetFreemanHeroes(race);

                    if (hero!=null)
                    {

                        ByteVectorReader bvr = new ByteVectorReader(pblock);
                        hero.LoadFromMP2(findobject, H2Color.NONE, hero.GetRace(), bvr);
                        hero.SetModes(HeroesFlags.JAIL);
                    }
                }
                break;
            case Mp2Obj.OBJ_HEROES:
                // add heroes
                if (Mp2Consts.SIZEOFMP2HEROES != pblock.Length)
                {
                }
                else if (null!= (addon = tile.FindObjectConst(Mp2Obj.OBJ_HEROES)))
                {
                    var colorRace = Maps.TilesAddon.ColorRaceFromHeroSprite(addon);
KingdomNs.Kingdom kingdom = GetKingdom(colorRace.Item1);

if (colorRace.Item2 == RaceType.RAND &&
    colorRace.Item1 != H2Color.NONE)
                                    colorRace.Item2 = kingdom.GetRace();

                    // check heroes max count
                    if (kingdom.AllowRecruitHero(false, 0))
                    {
                        Heroes hero = null;


                        if (pblock[17]!=0 &&
                            pblock[18] < (int) HeroKinds.BAX)
                            hero = vec_heroes.Get(pblock[18]);

                        if (hero ==null || !hero.isFreeman())
                            hero = vec_heroes.GetFreeman(colorRace.Item2);

                                    if (hero!=null)
                        {
                            ByteVectorReader bvr = new ByteVectorReader(pblock);
                            hero.LoadFromMP2(findobject, colorRace.Item1, colorRace.Item2, bvr);
                        }
                    }
                }
                break;
            case Mp2Obj.OBJ_SIGN:
            case Mp2Obj.OBJ_BOTTLE:
                // add sign or buttle
                if (Mp2Consts.SIZEOFMP2SIGN - 1 < pblock.Length && 0x01 == pblock[0])
                {
                    var obj = new MapSign();
                    ByteVectorReader bvr = new ByteVectorReader(pblock);
                 obj.LoadFromMP2(findobject, bvr);
                    map_objects.add(obj);
                }
                break;
            case Mp2Obj.OBJ_EVENT:
                // add event maps
                if (Mp2Consts.SIZEOFMP2EVENT - 1 < pblock.Length && 0x01 == pblock[0])
                {
                    var obj = new MapEvent();
                    ByteVectorReader bvr = new ByteVectorReader(pblock);
    obj.LoadFromMP2(findobject, bvr);
                    map_objects.add(obj);
                }
                break;
            case Mp2Obj.OBJ_SPHINX:
                // add riddle sphinx
                if (Mp2Consts.SIZEOFMP2RIDDLE - 1 < pblock.Length &&  0x00 == pblock[0])
                {
                    var obj = new MapSphinx();
                    ByteVectorReader bvr = new ByteVectorReader(pblock);
obj.LoadFromMP2(findobject, bvr);
                    map_objects.add(obj);
                }
                break;
            default:
                break;
            }
        }
            // other events
        else if (0x00 == pblock[0])
        {
            // add event day
            if (Mp2Consts.SIZEOFMP2EVENT - 1 < pblock.Length &&  1 == pblock[42])
            {
                vec_eventsday.Add(new EventDate());
                ByteVectorReader bvr = new ByteVectorReader(pblock);
                vec_eventsday.Last().LoadFromMP2(bvr);
            }
                // add rumors
            else if (Mp2Consts.SIZEOFMP2RUMOR - 1 < pblock.Length)
            {
                if (pblock[8]!=0)
                {
                    List<byte> subBlock = new List<byte>();
                    //(pblock.begin() + 8, pblock.end());

                    ByteVectorReader bvr = new ByteVectorReader(pblock);
                    string valueRumor = bvr.toString(subBlock.Count);
                    vec_rumors.Add(GameStatic.GetEncodeString(valueRumor));
                }
            }
        }
            // debug
        else
        {
        }
    }

    PostLoad();
            
            
            return true;
        }
    }

    public class EventsDate : List<EventDate>
    {

    }

    public class EventDate
    {
        public void LoadFromMP2(ByteVectorReader bvr)
        {
            throw new NotImplementedException();
        }
    }
}