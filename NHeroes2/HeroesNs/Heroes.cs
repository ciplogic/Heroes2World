using System.Collections.Generic;
using NHeroes2.ArmyNs;
using NHeroes2.Engine;
using NHeroes2.HeroesNs.Route;
using NHeroes2.KingdomNs;
using NHeroes2.MapsNs;
using NHeroes2.Serialize;

namespace NHeroes2.HeroesNs
{
    enum HeroesKind
    {
    // knight
    LORDKILBURN,
    SIRGALLANTH,
    ECTOR,
    GVENNETH,
    TYRO,
    AMBROSE,
    RUBY,
    MAXIMUS,
    DIMITRY,
    // barbarian
    THUNDAX,
    FINEOUS,
    JOJOSH,
    CRAGHACK,
    JEZEBEL,
    JACLYN,
    ERGON,
    TSABU,
    ATLAS,
    // sorceress
    ASTRA,
    NATASHA,
    TROYAN,
    VATAWNA,
    REBECCA,
    GEM,
    ARIEL,
    CARLAWN,
    LUNA,
    // warlock
    ARIE,
    ALAMAR,
    VESPER,
    CRODO,
    BAROK,
    KASTORE,
    AGAR,
    FALAGAR,
    WRATHMONT,
    // wizard
    MYRA,
    FLINT,
    DAWN,
    HALON,
    MYRINI,
    WILFREY,
    SARAKIN,
    KALINDRA,
    MANDIGAL,
    // necromancer
    ZOM,
    DARLANA,
    ZAM,
    RANLOO,
    CHARITY,
    RIALDO,
    ROXANA,
    SANDRO,
    CELIA,
    // from campain
    ROLAND,
    CORLAGON,
    ELIZA,
    ARCHIBALD,
    HALTON,
    BAX,
    // from extended
    SOLMYR,
    DAINWIN,
    MOG,
    UNCLEIVAN,
    JOSEPH,
    GALLAVANT,
    ELDERIAN,
    CEALLACH,
    DRAKONIA,
    MARTINE,
    JARKONAS,
    // debugger
    SANDYSANDY,
    UNKNOWN
    };
    public class Heroes
    {
        string name;
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

        public void Recruit(ColorKind getColor, H2Point h2Point)
        {
            throw new System.NotImplementedException();
        }
    }
}