namespace NHeroes2.MapsNs
{
    // origin mp2 tile
    internal enum mapsize_t
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
    internal class mp2castle_t
    {
        private byte allowCastle; // 00 TRUE, 01 FALSE
        private ushort building;
        private bool capitan;
        private bool castle;
        private byte[] castleName = new byte[13]; // name + '\0'
        private byte color; // 00 blue, 01 green, 02 red, 03 yellow, 04 orange, 05 purpl, ff unknown
        private ushort count1;
        private ushort count2;
        private ushort count3;
        private ushort count4;
        private ushort count5;
        private bool customBuilding;
        private bool customCastleName;

        private bool customTroops;

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
        private ushort dwelling;

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
        private byte magicTower;
        private byte monster1;
        private byte monster2;
        private byte monster3;
        private byte monster4;
        private byte monster5;
        private byte type; // 00 knight, 01 barb, 02 sorc, 03 warl, 04 wiz, 05 necr, 06 rnd
        private byte[] unknown = new byte[29];
    }

    // origin mp2 heroes
    // 0x004c - size
    internal class mp2heroes_t
    {
        private byte artifact1; // 0xff none
        private byte artifact2; // 0xff none
        private byte artifact3; // 0xff none
        private ushort countMonter1;
        private ushort countMonter2;
        private ushort countMonter3;
        private ushort countMonter4;
        private ushort countMonter5;
        private byte countSquare; // for patrol
        private byte customName;
        private byte customPortrate;
        private bool customSkill;
        private bool customTroops;
        private uint exerience;
        private byte monster1; // 0xff none
        private byte monster2; // 0xff none
        private byte monster3; // 0xff none
        private byte monster4; // 0xff none
        private byte monster5; // 0xff none
        private byte[] name = new byte[13]; // name + '\0'
        private bool patrol;
        private byte portrate;
        private byte skill1; // 0xff none
        private byte skill2; // pathfinding, archery, logistic, scouting,
        private byte skill3; // diplomacy, navigation, leadership, wisdom,
        private byte skill4; // mysticism, luck, ballistics, eagle, necromance, estate
        private byte skill5;
        private byte skill6;
        private byte skill7;
        private byte skill8;
        private byte skillLevel1;
        private byte skillLevel2;
        private byte skillLevel3;
        private byte skillLevel4;
        private byte skillLevel5;
        private byte skillLevel6;
        private byte skillLevel7;
        private byte skillLevel8;
        private byte unknown;
        private byte unknown2; // 0
        private byte unknown3; // 0
        private byte[] unknown4 = new byte[15]; // 0
    }

    // origin mp2 sign or buttle
    internal class mp2info_t
    {
        private byte id; // 0x01
        private char text; // message  + '/0'
        private byte[] zero = new byte[8]; // 8 byte 0x00
    }

    // origin mp2 event for coord
    internal class mp2eventcoord_t
    {
        private ushort artifact; // 0xffff - none
        private bool blue;
        private bool cancel; // cancel event after first visit
        private bool computer; // allow events for computer
        private uint crystal;
        private uint gems;
        private uint golds;
        private bool green;
        private byte id; // 0x01
        private uint mercury;
        private bool orange;
        private uint ore;
        private bool purple;
        private bool red;
        private uint sulfur;
        private char text; // message + '/0'
        private uint wood;
        private bool yellow;
        private byte[] zero = new byte[10]; // 10 byte 0x00
    }


    // origin mp2 event for day
    internal class mp2eventday_t
    {
        private ushort artifact; // always 0xffff - none
        private bool blue;
        private ushort computer; // allow events for computer
        private uint crystal;
        private ushort first; // day of first occurent
        private uint gems;
        private uint golds;
        private bool green;
        private byte id; // 0x00
        private uint mercury;
        private bool orange;
        private uint ore;
        private bool purple;
        private bool red;
        private ushort subsequent; // subsequent occurrences
        private uint sulfur;
        private char text; // message + '/0'
        private uint wood;
        private bool yellow;
        private byte[] zero = new byte[6]; // 6 byte 0x00 and end 0x01
    }

    // origin mp2 rumor
    internal class mp2rumor_t
    {
        private byte id; // 0x00
        private char text; // message + '/0'
        private byte[] zero = new byte[7]; // 7 byte 0x00
    }

    // origin mp2 riddle sphinx
    internal class mp2riddle_t
    {
        private byte[] answer1 = new byte[13];
        private byte[] answer2 = new byte[13];
        private byte[] answer3 = new byte[13];
        private byte[] answer4 = new byte[13];
        private byte[] answer5 = new byte[13];
        private byte[] answer6 = new byte[13];
        private byte[] answer7 = new byte[13];
        private byte[] answer8 = new byte[13];
        private ushort artifact; // 0xffff - none
        private byte count; // count answers (1, 8)
        private uint crystal;
        private uint gems;
        private uint golds;
        private byte id; // 0x00
        private uint mercury;
        private uint ore;
        private uint sulfur;
        private char text; // message + '/0'
        private uint wood;
    }
}