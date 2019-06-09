using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NHeroes2.Agg.Icns;
using NHeroes2.CastleNs;
using NHeroes2.Engine;
using NHeroes2.Game;
using NHeroes2.GameNs;
using NHeroes2.HeroesNs;
using NHeroes2.MapsNs;
using NHeroes2.ResourceNs;
using NHeroes2.Serialize;
using NHeroes2.SystemNs;
using NHeroes2.Utilities;
using static NHeroes2.SystemNs.Translation;

namespace NHeroes2.KingdomNs
{
    public class World : H2Size
    {
        private readonly CapturedObjects map_captureobj = new CapturedObjects();


        private readonly MapObjects map_objects = new MapObjects();
        private readonly AllCastles vec_castles = new AllCastles();
        private readonly EventsDate vec_eventsday = new EventsDate();

        private readonly AllHeroes vec_heroes = new AllHeroes();
        private readonly Kingdoms vec_kingdoms = new Kingdoms();
        private readonly Rumors vec_rumors = new Rumors();
        private readonly MapsTiles vec_tiles = new MapsTiles();
        private int day, week, month;
        private int heroes_cond_loss;


        private int heroes_cond_wins;
        private MapActions map_actions = new MapActions();
        private readonly UltimateArtifact ultimate_artifact = new UltimateArtifact((int) ArtifactKind.UNKNOWN);

        private Week week_current;
        private Week week_next;


        private World()
        {
        }

        public static World Instance { get; } = new World();

        private Castle GetCastle(H2Point getPoint)
        {
            throw new NotImplementedException();
        }


        private Kingdom GetKingdom(ColorKind color)
        {
            return vec_kingdoms.GetKingdom(color);
        }

        public Heroes GetFreemanHeroes(RaceType race)
        {
            throw new NotImplementedException();
        }

        private void PostLoad()
        {
            // modify other objects
            for (var ii = 0; ii < vec_tiles.Count; ++ii)
            {
                var tile = vec_tiles[ii];

                Tiles.FixedPreload(tile);

                //
                switch (tile.GetObject())
                {
                    case ObjKind.OBJ_WITCHSHUT:
                    case ObjKind.OBJ_SHRINE1:
                    case ObjKind.OBJ_SHRINE2:
                    case ObjKind.OBJ_SHRINE3:
                    case ObjKind.OBJ_STONELIGHTS:
                    case ObjKind.OBJ_FOUNTAIN:
                    case ObjKind.OBJ_EVENT:
                    case ObjKind.OBJ_BOAT:
                    case ObjKind.OBJ_RNDARTIFACT:
                    case ObjKind.OBJ_RNDARTIFACT1:
                    case ObjKind.OBJ_RNDARTIFACT2:
                    case ObjKind.OBJ_RNDARTIFACT3:
                    case ObjKind.OBJ_RNDRESOURCE:
                    case ObjKind.OBJ_WATERCHEST:
                    case ObjKind.OBJ_TREASURECHEST:
                    case ObjKind.OBJ_ARTIFACT:
                    case ObjKind.OBJ_RESOURCE:
                    case ObjKind.OBJ_MAGICGARDEN:
                    case ObjKind.OBJ_WATERWHEEL:
                    case ObjKind.OBJ_WINDMILL:
                    case ObjKind.OBJ_WAGON:
                    case ObjKind.OBJ_SKELETON:
                    case ObjKind.OBJ_LEANTO:
                    case ObjKind.OBJ_CAMPFIRE:
                    case ObjKind.OBJ_FLOTSAM:
                    case ObjKind.OBJ_SHIPWRECKSURVIROR:
                    case ObjKind.OBJ_DERELICTSHIP:
                    case ObjKind.OBJ_SHIPWRECK:
                    case ObjKind.OBJ_GRAVEYARD:
                    case ObjKind.OBJ_PYRAMID:
                    case ObjKind.OBJ_DAEMONCAVE:
                    case ObjKind.OBJ_ABANDONEDMINE:
                    case ObjKind.OBJ_ALCHEMYLAB:
                    case ObjKind.OBJ_SAWMILL:
                    case ObjKind.OBJ_MINES:
                    case ObjKind.OBJ_TREEKNOWLEDGE:
                    case ObjKind.OBJ_BARRIER:
                    case ObjKind.OBJ_TRAVELLERTENT:
                    case ObjKind.OBJ_MONSTER:
                    case ObjKind.OBJ_RNDMONSTER:
                    case ObjKind.OBJ_RNDMONSTER1:
                    case ObjKind.OBJ_RNDMONSTER2:
                    case ObjKind.OBJ_RNDMONSTER3:
                    case ObjKind.OBJ_RNDMONSTER4:
                    case ObjKind.OBJ_ANCIENTLAMP:
                    case ObjKind.OBJ_WATCHTOWER:
                    case ObjKind.OBJ_EXCAVATION:
                    case ObjKind.OBJ_CAVE:
                    case ObjKind.OBJ_TREEHOUSE:
                    case ObjKind.OBJ_ARCHERHOUSE:
                    case ObjKind.OBJ_GOBLINHUT:
                    case ObjKind.OBJ_DWARFCOTT:
                    case ObjKind.OBJ_HALFLINGHOLE:
                    case ObjKind.OBJ_PEASANTHUT:
                    case ObjKind.OBJ_THATCHEDHUT:
                    case ObjKind.OBJ_RUINS:
                    case ObjKind.OBJ_TREECITY:
                    case ObjKind.OBJ_WAGONCAMP:
                    case ObjKind.OBJ_DESERTTENT:
                    case ObjKind.OBJ_TROLLBRIDGE:
                    case ObjKind.OBJ_DRAGONCITY:
                    case ObjKind.OBJ_CITYDEAD:
                        tile.QuantityUpdate();
                        break;

                    case ObjKind.OBJ_WATERALTAR:
                    case ObjKind.OBJ_AIRALTAR:
                    case ObjKind.OBJ_FIREALTAR:
                    case ObjKind.OBJ_EARTHALTAR:
                    case ObjKind.OBJ_BARROWMOUNDS:
                        tile.QuantityReset();
                        tile.QuantityUpdate();
                        break;

                    case ObjKind.OBJ_HEROES:
                    {
                        var addon = tile.FindAddonICN1(IcnKind.MINIHERO);
                        // remove event sprite
                        if (addon != null) tile.Remove(addon.uniq);

                        tile.SetHeroes(GetHeroes(MapsStatic.GetPoint(ii)));
                    }
                        break;
                }
            }

            // add heroes to kingdoms
            vec_kingdoms.AddHeroes(vec_heroes);

            // add castles to kingdoms
            vec_kingdoms.AddCastles(vec_castles);

            // update wins, loss conditions
            if ((GameOverCondition.WINS_HERO & H2Settings.Get().ConditionWins()) != 0)
            {
                var hero = GetHeroes(H2Settings.Get().WinsMapsPositionObject());
                heroes_cond_wins = hero != null ? hero.GetID() : (int) HeroesKind.UNKNOWN;
            }

            if ((GameOverCondition.LOSS_HERO & H2Settings.Get().ConditionLoss()) != 0)
            {
                var hero = GetHeroes(H2Settings.Get().LossMapsPositionObject());
                if (hero != null)
                {
                    heroes_cond_loss = hero.GetID();
                    hero.SetModes(HeroesFlags.NOTDISMISS | HeroesFlags.NOTDEFAULTS);
                }
            }

            // update tile passable
            vec_tiles.ForEach(tile => { tile.UpdatePassable(); });

            // play with hero
            vec_kingdoms.ApplyPlayWithStartingHero();

            if (H2Settings.Get().ExtWorldStartHeroLossCond4Humans())
                vec_kingdoms.AddCondLossHeroes(vec_heroes);

            // play with debug hero
            if (H2Settings.IS_DEVEL())
            {
                // get first castle position
                var kingdom = GetKingdom(H2Color.GetFirst(Players.HumanColors()));

                if (!kingdom.GetCastles()._items.empty())
                {
                    var castle = kingdom.GetCastles()._items[0];
                    var hero = vec_heroes.Get((int) HeroesKind.SANDYSANDY);

                    if (hero != null)
                    {
                        var cp = castle.GetCenter();
                        hero.Recruit(castle.GetColor(), new H2Point(cp.x, cp.y + 1));
                    }
                }
            }

            // set ultimate
            var it = vec_tiles.FirstOrDefault(tile => tile.isObject(ObjKind.OBJ_RNDULTIMATEARTIFACT));


            var ultimate_pos = new H2Point();

            // not found
            if (it == null)
            {
                // generate position for ultimate
                var pools = new MapsIndexes();

                foreach (var tile in vec_tiles)
                {
                    var x = tile.GetIndex() % w();
                    var y = tile.GetIndex() / w();
                    if (tile.GoodForUltimateArtifact() &&
                        x > 5 && x < w() - 5 && y > 5 && y < h() - 5)
                        pools.Add(tile.GetIndex());
                }

                if (!pools.empty())
                {
                    var pos = Rand.Get(pools);
                    ultimate_artifact.Set(pos, new Artifact(Artifact.Rand(ArtifactLevel.ART_ULTIMATE)));
                    ultimate_pos = MapsStatic.GetPoint(pos);
                }
            }
            else
            {
                var addon = it.FindObjectConst(ObjKind.OBJ_RNDULTIMATEARTIFACT);

                // remove ultimate artifact sprite
                if (addon != null)
                {
                    ultimate_artifact.Set(it.GetIndex(), Artifact.FromMP2IndexSprite(addon.index));
                    it.Remove(addon.uniq);
                    it.SetObject((byte) ObjKind.OBJ_ZERO);
                    ultimate_pos = it.GetCenter();
                }
            }

            var rumor = _("The ultimate artifact is really the %{name}");
            StringReplace(ref rumor, "%{name}", ultimate_artifact.GetName());
            vec_rumors.Add(rumor);

            rumor = _("The ultimate artifact may be found in the %{name} regions of the world.");
            var world = Instance;
            if (world.h() / 3 > ultimate_pos.y)
            {
                if (world.w() / 3 > ultimate_pos.x)
                    StringReplace(ref rumor, "%{name}", _("north-west"));
                else if (2 * world.w() / 3 > ultimate_pos.x)
                    StringReplace(ref rumor, "%{name}", _("north"));
                else
                    StringReplace(ref rumor, "%{name}", _("north-east"));
            }
            else if (2 * world.h() / 3 > ultimate_pos.y)
            {
                if (world.w() / 3 > ultimate_pos.x)
                    StringReplace(ref rumor, "%{name}", _("west"));
                else if (2 * world.w() / 3 > ultimate_pos.x)
                    StringReplace(ref rumor, "%{name}", _("center"));
                else
                    StringReplace(ref rumor, "%{name}", _("east"));
            }
            else
            {
                if (world.w() / 3 > ultimate_pos.x)
                    StringReplace(ref rumor, "%{name}", _("south-west"));
                else if (2 * world.w() / 3 > ultimate_pos.x)
                    StringReplace(ref rumor, "%{name}", _("south"));
                else
                    StringReplace(ref rumor, "%{name}", _("south-east"));
            }

            vec_rumors.Add(rumor);

            vec_rumors.Add(_("The truth is out there."));
            vec_rumors.Add(_("The dark side is stronger."));
            vec_rumors.Add(_("The end of the world is near."));
            vec_rumors.Add(_("The bones of Lord Slayer are buried in the foundation of the arena."));
            vec_rumors.Add(_("A Black Dragon will take out a Titan any day of the week."));
            vec_rumors.Add(_("He told her: Yada yada yada...  and then she said: Blah, blah, blah..."));

            vec_rumors.Add(
                _("You can load the newest version of game from a site:\n http://sf.net/projects/fheroes2"));
            vec_rumors.Add(_("This game is now in beta development version. ;)"));
        }

        public Heroes GetHeroes(H2Point center)
        {
            foreach (var hero in vec_heroes)
                if (hero.isPosition(center))
                    return hero;

            return null;
        }

        public Heroes GetHeroes(int hid)
        {
            return vec_heroes.Get(hid);
        }

        private static void Defaults()
        {
        }

        private void Reset()
        {
            // maps tiles
            vec_tiles.Clear();

            // kingdoms
//            vec_kingdoms.clear();

            // event day
            vec_eventsday.Clear();

            // rumors
            vec_rumors.Clear();

            // castles
            vec_castles._items.Clear();

            // heroes
            vec_heroes.Clear();

            // extra
            map_captureobj.Items.Clear();

//            ultimate_artifact.Reset();

            day = 0;
            week = 0;
            month = 0;
            /*
            week_current = Week::TORTOISE;
            week_next = Week::WeekRand();

            heroes_cond_wins = Heroes::UNKNOWN;
            heroes_cond_loss = Heroes::UNKNOWN;
            */
        }

        public bool LoadMapMP2(string filename)
        {
            Reset();
            Defaults();
            if (!File.Exists(filename)) throw new Exception("load maps");

            var vectorBytes = File.ReadAllBytes(filename);
            var fs = new ByteVectorReader(vectorBytes);

            var vec_object =
                new MapsIndexes(); // index maps for OBJ_CASTLE, OBJ_HEROES, OBJ_SIGN, OBJ_BOTTLE, OBJ_EVENT

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
            switch ((mapsize_t) fs.getLE32())
            {
                case mapsize_t.SMALL:
                    W = (ushort) mapsize_t.SMALL;
                    break;
                case mapsize_t.MEDIUM:
                    W = (ushort) mapsize_t.MEDIUM;
                    break;
                case mapsize_t.LARGE:
                    W = (ushort) mapsize_t.LARGE;
                    break;
                case mapsize_t.XLARGE:
                    W = (ushort) mapsize_t.XLARGE;
                    break;
                default:
                    W = 0;
                    break;
            }

            // height
            switch ((mapsize_t) fs.getLE32())
            {
                case mapsize_t.SMALL:
                    H = (ushort) mapsize_t.SMALL;
                    break;
                case mapsize_t.MEDIUM:
                    H = (ushort) mapsize_t.MEDIUM;
                    break;
                case mapsize_t.LARGE:
                    H = (ushort) mapsize_t.LARGE;
                    break;
                case mapsize_t.XLARGE:
                    H = (ushort) mapsize_t.XLARGE;
                    break;
                default:
                    H = 0;
                    break;
            }

            if (W == 0 || H == 0 || W != H) return false;

            // seek to ADDONS block
            fs.skip(w() * h() * Mp2Consts.SIZEOFMP2TILE);

            // read all addons
            var addonsSize = fs.getLE32();
            var vec_mp2addons = new List<mp2addon_t>( /* count mp2addon_t */);
            vec_mp2addons.SetSize(addonsSize);

            foreach (var mp2Addon in vec_mp2addons)
            {
                mp2Addon.indexAddon = (ushort) fs.getLE16();
                mp2Addon.objectNameN1 = (byte) (fs.get() * 2);
                mp2Addon.indexNameN1 = (byte) fs.get();
                mp2Addon.quantityN = (byte) fs.get();
                mp2Addon.objectNameN2 = (byte) fs.get();
                mp2Addon.indexNameN2 = (byte) fs.get();

                mp2Addon.uniqNumberN1 = (uint) fs.getLE32();
                mp2Addon.uniqNumberN2 = (uint) fs.getLE32();
            }

            var endof_addons = fs.tell();
            // offset data
            fs.seek(Mp2Consts.MP2OFFSETDATA);

            vec_tiles.SetSize(w() * h());

            // read all tiles
            var index = -1;
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

                switch ((ObjKind) mp2tile.generalObject)
                {
                    case ObjKind.OBJ_RNDTOWN:
                    case ObjKind.OBJ_RNDCASTLE:
                    case ObjKind.OBJ_CASTLE:
                    case ObjKind.OBJ_HEROES:
                    case ObjKind.OBJ_SIGN:
                    case ObjKind.OBJ_BOTTLE:
                    case ObjKind.OBJ_EVENT:
                    case ObjKind.OBJ_SPHINX:
                    case ObjKind.OBJ_JAIL:
                        vec_object.Add(index);
                        break;
                }

                // offset first addon
                var offsetAddonsBlock = fs.getLE16();

                mp2tile.uniqNumber1 = (uint) fs.getLE32();
                mp2tile.uniqNumber2 = (uint) fs.getLE32();

                tile.Init(index, mp2tile);

                // load all addon for current tils
                while (offsetAddonsBlock != 0)
                {
                    if (vec_mp2addons.Count <= offsetAddonsBlock) break;

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
            for (uint ii = 0; ii < 72; ++ii)
            {
                var cx = fs.get();
                var cy = fs.get();
                var id = fs.get();

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
                }

                // preload in to capture objects cache
                map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), ObjKind.OBJ_CASTLE, ColorKind.NONE);
            }

            fs.seek(endof_addons + 72 * 3);

            // cood resource kingdoms
            // 144 x 3 byte (cx, cy, id)
            for (uint ii = 0; ii < 144; ++ii)
            {
                var cx = fs.get();
                var cy = fs.get();
                var id = fs.get();

                // empty block
                if (0xFF == cx && 0xFF == cy) continue;

                switch (id)
                {
                    // mines: wood
                    case 0x00:
                        map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), ObjKind.OBJ_SAWMILL,
                            ColorKind.NONE);
                        break;
                    // mines: mercury
                    case 0x01:
                        map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), ObjKind.OBJ_ALCHEMYLAB,
                            ColorKind.NONE);
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
                        map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), ObjKind.OBJ_MINES, ColorKind.NONE);
                        break;
                    // lighthouse
                    case 0x64:
                        map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), ObjKind.OBJ_LIGHTHOUSE,
                            ColorKind.NONE);
                        break;
                    // dragon city
                    case 0x65:
                        map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), ObjKind.OBJ_DRAGONCITY,
                            ColorKind.NONE);
                        break;
                    // abandoned mines
                    case 0x67:
                        map_captureobj.Set(MapsStatic.GetIndexFromAbsPoint(cx, cy), ObjKind.OBJ_ABANDONEDMINE,
                            ColorKind.NONE);
                        break;
                }
            }

            fs.seek(endof_addons + 72 * 3 + 144 * 3);

            // byte: num obelisks (01 default)
            fs.skip(1);

            // count final mp2 blocks
            uint countblock = 0;
            while (true)
            {
                var l = fs.get();
                var h = fs.get();

                if (0 == h && 0 == l) break;
                countblock = (uint) (256 * h + l - 1);
            }

            // castle or heroes or (events, rumors, etc)
            for (uint ii = 0; ii < countblock; ++ii)
            {
                var findobject = -1;

                // read block
                var sizeblock = fs.getLE16();
                var pblock = fs.getRaw(sizeblock);

                for (var it_index = 0; it_index != vec_object.Count && findobject < 0; ++it_index)
                {
                    var tile = vec_tiles[it_index];

                    // orders(quantity2, quantity1)
                    var orders = tile.GetQuantity2() != 0 ? tile.GetQuantity2() : 0;
                    orders <<= 8;
                    orders |= tile.GetQuantity1();


                    if (orders != 0 && orders % 0x08 == 0 && ii + 1 == orders / 0x08)
                        findobject = it_index;
                }

                if (0 <= findobject)
                {
                    var tile = vec_tiles[findobject];
                    TilesAddon addon = null;

                    switch (tile.GetObject())
                    {
                        case ObjKind.OBJ_CASTLE:
                            // add castle
                            if (Mp2Consts.SIZEOFMP2CASTLE != pblock.Length)
                            {
                            }
                            else
                            {
                                var castle = GetCastle(MapsStatic.GetPoint(findobject));
                                if (castle != null)
                                {
                                    var bvr = new ByteVectorReader(pblock);
                                    castle.LoadFromMP2(bvr);
                                    MapsStatic.MinimizeAreaForCastle(castle.GetCenter());
                                    map_captureobj.SetColor(tile.GetIndex(), castle.GetColor());
                                }
                            }

                            break;
                        case ObjKind.OBJ_RNDTOWN:
                        case ObjKind.OBJ_RNDCASTLE:
                            // add rnd castle
                            if (Mp2Consts.SIZEOFMP2CASTLE != pblock.Length)
                            {
                            }
                            else
                            {
                                var castle = GetCastle(MapsStatic.GetPoint(findobject));
                                if (castle != null)
                                {
                                    var bvr = new ByteVectorReader(pblock);
                                    castle.LoadFromMP2(bvr);
                                    MapsStatic.UpdateRNDSpriteForCastle(castle.GetCenter(), castle.GetRace(),
                                        castle.isCastle());
                                    MapsStatic.MinimizeAreaForCastle(castle.GetCenter());
                                    map_captureobj.SetColor(tile.GetIndex(), castle.GetColor());
                                }
                            }

                            break;
                        case ObjKind.OBJ_JAIL:
                            // add jail
                            if (Mp2Consts.SIZEOFMP2HEROES != pblock.Length)
                            {
                            }
                            else
                            {
                                var race = RaceType.KNGT;
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
                                }

                                var hero = GetFreemanHeroes(race);

                                if (hero != null)
                                {
                                    var bvr = new ByteVectorReader(pblock);
                                    hero.LoadFromMP2(findobject, ColorKind.NONE, hero.GetRace(), bvr);
                                    hero.SetModes(HeroesFlags.JAIL);
                                }
                            }

                            break;
                        case ObjKind.OBJ_HEROES:
                            // add heroes
                            if (Mp2Consts.SIZEOFMP2HEROES != pblock.Length)
                            {
                            }
                            else if (null != (addon = tile.FindObjectConst(ObjKind.OBJ_HEROES)))
                            {
                                var colorRace = TilesAddon.ColorRaceFromHeroSprite(addon);
                                var kingdom = GetKingdom(colorRace.Item1);

                                if (colorRace.Item2 == RaceType.RAND &&
                                    colorRace.Item1 != ColorKind.NONE)
                                    colorRace.Item2 = kingdom.GetRace();

                                // check heroes max count
                                if (kingdom.AllowRecruitHero(false, 0))
                                {
                                    Heroes hero = null;
                                    if (pblock[17] != 0 &&
                                        pblock[18] < (int) HeroKinds.BAX)
                                        hero = vec_heroes.Get(pblock[18]);

                                    if (hero == null || !hero.isFreeman())
                                        hero = vec_heroes.GetFreeman(colorRace.Item2);

                                    if (hero != null)
                                    {
                                        var bvr = new ByteVectorReader(pblock);
                                        hero.LoadFromMP2(findobject, colorRace.Item1, colorRace.Item2, bvr);
                                    }
                                }
                            }

                            break;
                        case ObjKind.OBJ_SIGN:
                        case ObjKind.OBJ_BOTTLE:
                            // add sign or buttle
                            if (Mp2Consts.SIZEOFMP2SIGN - 1 < pblock.Length && 0x01 == pblock[0])
                            {
                                var obj = new MapSign();
                                var bvr = new ByteVectorReader(pblock);
                                obj.LoadFromMP2(findobject, bvr);
                                map_objects.add(obj);
                            }

                            break;
                        case ObjKind.OBJ_EVENT:
                            // add event maps
                            if (Mp2Consts.SIZEOFMP2EVENT - 1 < pblock.Length && 0x01 == pblock[0])
                            {
                                var obj = new MapEvent();
                                var bvr = new ByteVectorReader(pblock);
                                obj.LoadFromMP2(findobject, bvr);
                                map_objects.add(obj);
                            }

                            break;
                        case ObjKind.OBJ_SPHINX:
                            // add riddle sphinx
                            if (Mp2Consts.SIZEOFMP2RIDDLE - 1 < pblock.Length && 0x00 == pblock[0])
                            {
                                var obj = new MapSphinx();
                                var bvr = new ByteVectorReader(pblock);
                                obj.LoadFromMP2(findobject, bvr);
                                map_objects.add(obj);
                            }

                            break;
                    }
                }
                // other events
                else if (0x00 == pblock[0])
                {
                    // add event day
                    if (Mp2Consts.SIZEOFMP2EVENT - 1 < pblock.Length && 1 == pblock[42])
                    {
                        vec_eventsday.Add(new EventDate());
                        var bvr = new ByteVectorReader(pblock);
                        vec_eventsday.Last().LoadFromMP2(bvr);
                    }
                    // add rumors
                    else if (Mp2Consts.SIZEOFMP2RUMOR - 1 < pblock.Length)
                    {
                        if (pblock[8] != 0)
                        {
                            var subBlock = new List<byte>();
                            //(pblock.begin() + 8, pblock.end());

                            var bvr = new ByteVectorReader(pblock);
                            var valueRumor = bvr.toString(subBlock.Count);
                            vec_rumors.Add(GameStatic.GetEncodeString(valueRumor));
                        }
                    }
                }

                // debug
            }

            PostLoad();


            return true;
        }

        public Tiles GetTiles(short ax, int ay)
        {
            return GetTiles(ay * W + ax);
        }

        public Tiles GetTiles(int index)
        {
            return vec_tiles[index];
        }
    }
}