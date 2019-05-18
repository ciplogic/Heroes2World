using System;

namespace NHeroes2.Maps
{
    // origin mp2 tile
    enum mapsize_t
    {
        ZERO = 0,
        SMALL = 36,
        MEDIUM = 72,
        LARGE = 108,
        XLARGE = 144
    }
    // origin mp2 addons tile

    // origin mp2 castle
    // 0x0046 - size
    class mp2castle_t
    {
        byte color; // 00 blue, 01 green, 02 red, 03 yellow, 04 orange, 05 purpl, ff unknown
        bool customBuilding;
        UInt16 building;
        /*
        0000 0000 0000 0010	Thieve's Guild
        0000 0000 0000 0100	Tavern
        0000 0000 0000 1000	Shipyard
        0000 0000 0001 0000	Well
        0000 0000 1000 0000	Statue
        0000 0001 0000 0000	Left Turret
        0000 0010 0000 0000	Right Turret
        0000 0100 0000 0000	Marketplace
        0000 1000 0000 0000	Farm, Garbage He, Crystal Gar, Waterfall, Orchard, Skull Pile
        0001 0000 0000 0000	Moat
        0010 0000 0000 0000	Fortification, Coliseum, Rainbow, Dungeon, Library, Storm
        */
        UInt16 dwelling;
        /*
        0000 0000 0000 1000	dweling1
        0000 0000 0001 0000	dweling2
        0000 0000 0010 0000	dweling3
        0000 0000 0100 0000	dweling4
        0000 0000 1000 0000	dweling5
        0000 0001 0000 0000	dweling6
        0000 0010 0000 0000	upgDweling2
        0000 0100 0000 0000	upgDweling3
        0000 1000 0000 0000	upgDweling4
        0001 0000 0000 0000	upgDweling5
        0010 0000 0000 0000	upgDweling6
        */
        byte magicTower;
        bool customTroops;
        byte monster1;
        byte monster2;
        byte monster3;
        byte monster4;
        byte monster5;
        UInt16 count1;
        UInt16 count2;
        UInt16 count3;
        UInt16 count4;
        UInt16 count5;
        bool capitan;
        bool customCastleName;
        byte[] castleName = new byte[13]; // name + '\0'
        byte type; // 00 knight, 01 barb, 02 sorc, 03 warl, 04 wiz, 05 necr, 06 rnd
        bool castle;
        byte allowCastle; // 00 TRUE, 01 FALSE
        byte [] unknown = new byte[29];
    };

    // origin mp2 heroes
    // 0x004c - size
    class mp2heroes_t
    {
        byte unknown;
        bool customTroops;
        byte monster1; // 0xff none
        byte monster2; // 0xff none
        byte monster3; // 0xff none
        byte monster4; // 0xff none
        byte monster5; // 0xff none
        UInt16 countMonter1;
        UInt16 countMonter2;
        UInt16 countMonter3;
        UInt16 countMonter4;
        UInt16 countMonter5;
        byte customPortrate;
        byte portrate;
        byte artifact1; // 0xff none
        byte artifact2; // 0xff none
        byte artifact3; // 0xff none
        byte unknown2; // 0
        UInt32 exerience;
        bool customSkill;
        byte skill1; // 0xff none
        byte skill2; // pathfinding, archery, logistic, scouting,
        byte skill3; // diplomacy, navigation, leadership, wisdom,
        byte skill4; // mysticism, luck, ballistics, eagle, necromance, estate
        byte skill5;
        byte skill6;
        byte skill7;
        byte skill8;
        byte skillLevel1;
        byte skillLevel2;
        byte skillLevel3;
        byte skillLevel4;
        byte skillLevel5;
        byte skillLevel6;
        byte skillLevel7;
        byte skillLevel8;
        byte unknown3; // 0
        byte customName;
        byte []name = new byte[13]; // name + '\0'
        bool patrol;
        byte countSquare; // for patrol
        byte []unknown4 = new byte[15]; // 0
    };

    // origin mp2 sign or buttle
    class mp2info_t
    {
        byte id; // 0x01
        byte [] zero = new byte[8]; // 8 byte 0x00
        char text; // message  + '/0'
    };

    // origin mp2 event for coord
    class mp2eventcoord_t
    {
        byte id; // 0x01
        UInt32 wood;
        UInt32 mercury;
        UInt32 ore;
        UInt32 sulfur;
        UInt32 crystal;
        UInt32 gems;
        UInt32 golds;
        UInt16 artifact; // 0xffff - none
        bool computer; // allow events for computer
        bool cancel; // cancel event after first visit
        byte []zero = new byte[10]; // 10 byte 0x00
        bool blue;
        bool green;
        bool red;
        bool yellow;
        bool orange;
        bool purple;
        char text; // message + '/0'
    };


    // origin mp2 event for day
    class mp2eventday_t
    {
        byte id; // 0x00
        UInt32 wood;
        UInt32 mercury;
        UInt32 ore;
        UInt32 sulfur;
        UInt32 crystal;
        UInt32 gems;
        UInt32 golds;
        UInt16 artifact; // always 0xffff - none
        UInt16 computer; // allow events for computer
        UInt16 first; // day of first occurent
        UInt16 subsequent; // subsequent occurrences
        byte [] zero = new byte[6]; // 6 byte 0x00 and end 0x01
        bool blue;
        bool green;
        bool red;
        bool yellow;
        bool orange;
        bool purple;
        char text; // message + '/0'
    };

    // origin mp2 rumor
    class mp2rumor_t
    {
        byte id; // 0x00
        byte []zero = new byte[7]; // 7 byte 0x00
        char text; // message + '/0'
    };

    // origin mp2 riddle sphinx
    class mp2riddle_t
    {
        byte id; // 0x00
        UInt32 wood;
        UInt32 mercury;
        UInt32 ore;
        UInt32 sulfur;
        UInt32 crystal;
        UInt32 gems;
        UInt32 golds;
        UInt16 artifact; // 0xffff - none
        byte count; // count answers (1, 8)
        byte[] answer1 = new byte[13];
        byte[] answer2 = new byte[13];
        byte[] answer3 = new byte[13];
        byte[] answer4 = new byte[13];
        byte[] answer5 = new byte[13];
        byte[] answer6 = new byte[13];
        byte[] answer7 = new byte[13];
        byte[] answer8 = new byte[13];
        char text; // message + '/0'
    };

}