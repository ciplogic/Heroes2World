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
        string name;
        public ColorBase color;
        ColorBase killer_color;
        uint experience;
        int move_point_scale;

        SecSkills secondary_skills;
        int hid; /* hero id */
        int portrait; /* hero id */
        int race;
        int save_maps_object;

        H2Path path;

        int direction;
        int sprite_index;

        H2Point patrol_center;
        int patrol_square;
        public MapPosition position = new MapPosition();
        ColorKind _killerColorKind;


        List<IndexObject> visit_object = new List<IndexObject>();
        public RaceType GetRace()
        {
            throw new System.NotImplementedException();
        }

        public void LoadFromMP2(int findobject, ColorKind none, RaceType getRace, ByteVectorReader bvr)
        {
            throw new System.NotImplementedException();
        }

        public void SetModes(HeroesFlags jail)
        {
            throw new System.NotImplementedException();
        }

        public bool isFreeman()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public byte GetMapsObject()
        {
            throw new System.NotImplementedException();
        }

        public void Recruit(Castle castle)
        {
            
        }
        public void Recruit(ColorKind getColor, H2Point h2Point)
        {
            throw new System.NotImplementedException();
        }

        public int GetColor()
        {
            return color.Color;
        }

        public bool Modes(HeroesFlags patrol)
        {
            throw new System.NotImplementedException();
        }

        public void SetFreeman(int i)
        {
            throw new System.NotImplementedException();
        }

        public void SetCenterPatrol(H2Point cp)
        {
            throw new System.NotImplementedException();
        }
    }
}