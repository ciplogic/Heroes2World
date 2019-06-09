using System;
using System.Collections.Generic;
using NHeroes2.CastleNs;
using NHeroes2.Engine;
using NHeroes2.HeroesNs.Route;
using NHeroes2.KingdomNs;
using NHeroes2.MapsNs;
using NHeroes2.Serialize;

namespace NHeroes2.HeroesNs
{
    public class Heroes
    {
        private ColorKind _killerColorKind;
        public ColorBase color;

        private int direction;
        private uint experience;
        private int hid; /* hero id */
        private ColorBase killer_color;
        private int move_point_scale;
        private string name;

        private H2Path path;

        private H2Point patrol_center;
        private int patrol_square;
        private int portrait; /* hero id */
        public MapPosition position = new MapPosition();
        private int race;
        private int save_maps_object;

        private SecSkills secondary_skills;
        private int sprite_index;


        private List<IndexObject> visit_object = new List<IndexObject>();

        public RaceType GetRace()
        {
            throw new NotImplementedException();
        }

        public void LoadFromMP2(int findobject, ColorKind none, RaceType getRace, ByteVectorReader bvr)
        {
            throw new NotImplementedException();
        }

        public void SetModes(HeroesFlags jail)
        {
            throw new NotImplementedException();
        }

        public bool isFreeman()
        {
            throw new NotImplementedException();
        }

        public bool isPosition(H2Point center)
        {
            return position.center.AreEqual(center);
        }

        public void SetMapsObject(ObjKind obj)
        {
            save_maps_object = (int) (obj != ObjKind.OBJ_HEROES ? obj : ObjKind.OBJ_ZERO);
        }

        public int GetID()
        {
            throw new NotImplementedException();
        }

        public byte GetMapsObject()
        {
            throw new NotImplementedException();
        }

        public void Recruit(Castle castle)
        {
        }

        public void Recruit(ColorKind getColor, H2Point h2Point)
        {
            throw new NotImplementedException();
        }

        public int GetColor()
        {
            return color.Color;
        }

        public bool Modes(HeroesFlags patrol)
        {
            throw new NotImplementedException();
        }

        public void SetFreeman(int i)
        {
            throw new NotImplementedException();
        }

        public void SetCenterPatrol(H2Point cp)
        {
            throw new NotImplementedException();
        }

        public bool isShipMaster()
        {
            throw new NotImplementedException();
        }
    }
}