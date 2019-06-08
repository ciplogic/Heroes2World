using NHeroes2.KingdomNs;
using NHeroes2.ResourceNs;
using static NHeroes2.SystemNs.Translation;

namespace NHeroes2.MonsterNs
{
    internal class monstats_t
    {
        public static monstats_t[] monsters =
        {
            new monstats_t(0, 0, 0, 0, 0, Speed.VERYSLOW, 0, 0, "Unknown Monster", "Unknown Monsters",
                new cost_t(0, 0, 0, 0, 0, 0, 0)),

            // atck dfnc  min  max   hp             speed grwn  shots  name                  multiname             cost
            new monstats_t(1, 1, 1, 1, 1, Speed.VERYSLOW, 12, 0, _("Peasant"), _("Peasants"),
                new cost_t(20, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 3, 2, 3, 10, Speed.VERYSLOW, 8, 12, _("Archer"), _("Archers"),
                new cost_t(150, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 3, 2, 3, 10, Speed.AVERAGE, 8, 24, _("Ranger"), _("Rangers"),
                new cost_t(200, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 9, 3, 4, 15, Speed.AVERAGE, 5, 0, _("Pikeman"), _("Pikemen"),
                new cost_t(200, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 9, 3, 4, 20, Speed.FAST, 5, 0, _("Veteran Pikeman"), _("Veteran Pikemen"),
                new cost_t(250, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 9, 4, 6, 25, Speed.AVERAGE, 4, 0, _("Swordsman"), _("Swordsmen"),
                new cost_t(250, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 9, 4, 6, 30, Speed.FAST, 4, 0, _("Master Swordsman"), _("Master Swordsmen"),
                new cost_t(300, 0, 0, 0, 0, 0, 0)),
            new monstats_t(10, 9, 5, 10, 30, Speed.VERYFAST, 3, 0, _("Cavalry"), _("Cavalries"),
                new cost_t(300, 0, 0, 0, 0, 0, 0)),
            new monstats_t(10, 9, 5, 10, 40, Speed.ULTRAFAST, 3, 0, _("Champion"), _("Champions"),
                new cost_t(375, 0, 0, 0, 0, 0, 0)),
            new monstats_t(11, 12, 10, 20, 50, Speed.FAST, 2, 0, _("Paladin"), _("Paladins"),
                new cost_t(600, 0, 0, 0, 0, 0, 0)),
            new monstats_t(11, 12, 10, 20, 65, Speed.VERYFAST, 2, 0, _("Crusader"), _("Crusaders"),
                new cost_t(1000, 0, 0, 0, 0, 0, 0)),

            // atck dfnc  min  max   hp             speed grwn  shots  name                  multiname            cost
            new monstats_t(3, 1, 1, 2, 3, Speed.AVERAGE, 10, 0, _("Goblin"), _("Goblins"),
                new cost_t(40, 0, 0, 0, 0, 0, 0)),
            new monstats_t(3, 4, 2, 3, 10, Speed.VERYSLOW, 8, 8, _("Orc"), _("Orcs"),
                new cost_t(140, 0, 0, 0, 0, 0, 0)),
            new monstats_t(3, 4, 3, 4, 15, Speed.SLOW, 8, 16, _("Orc Chief"), _("Orc Chiefs"),
                new cost_t(175, 0, 0, 0, 0, 0, 0)),
            new monstats_t(6, 2, 3, 5, 20, Speed.VERYFAST, 5, 0, _("Wolf"), _("Wolves"),
                new cost_t(200, 0, 0, 0, 0, 0, 0)),
            new monstats_t(9, 5, 4, 6, 40, Speed.VERYSLOW, 4, 0, _("Ogre"), _("Ogres"),
                new cost_t(300, 0, 0, 0, 0, 0, 0)),
            new monstats_t(9, 5, 5, 7, 60, Speed.AVERAGE, 4, 0, _("Ogre Lord"), _("Ogre Lords"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),
            new monstats_t(10, 5, 5, 7, 40, Speed.AVERAGE, 3, 8, _("Troll"), _("Trolls"),
                new cost_t(600, 0, 0, 0, 0, 0, 0)),
            new monstats_t(10, 5, 7, 9, 40, Speed.FAST, 3, 16, _("War Troll"), _("War Trolls"),
                new cost_t(700, 0, 0, 0, 0, 0, 0)),
            new monstats_t(12, 9, 12, 24, 80, Speed.FAST, 2, 0, _("Cyclops"), _("Cyclopes"),
                new cost_t(750, 0, 0, 0, 0, 1, 0)),

            // atck dfnc  min  max   hp             speed grwn  shots  name                  multiname            cost
            new monstats_t(4, 2, 1, 2, 2, Speed.AVERAGE, 8, 0, _("Sprite"), _("Sprites"),
                new cost_t(50, 0, 0, 0, 0, 0, 0)),
            new monstats_t(6, 5, 2, 4, 20, Speed.VERYSLOW, 6, 0, _("Dwarf"), _("Dwarves"),
                new cost_t(200, 0, 0, 0, 0, 0, 0)),
            new monstats_t(6, 6, 2, 4, 20, Speed.AVERAGE, 6, 0, _("Battle Dwarf"), _("Battle Dwarves"),
                new cost_t(250, 0, 0, 0, 0, 0, 0)),
            new monstats_t(4, 3, 2, 3, 15, Speed.AVERAGE, 4, 24, _("Elf"), _("Elves"),
                new cost_t(250, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 5, 2, 3, 15, Speed.VERYFAST, 4, 24, _("Grand Elf"), _("Grand Elves"),
                new cost_t(300, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 5, 5, 8, 25, Speed.FAST, 3, 8, _("Druid"), _("Druids"),
                new cost_t(350, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 7, 5, 8, 25, Speed.VERYFAST, 3, 16, _("Greater Druid"), _("Greater Druids"),
                new cost_t(400, 0, 0, 0, 0, 0, 0)),
            new monstats_t(10, 9, 7, 14, 40, Speed.FAST, 2, 0, _("Unicorn"), _("Unicorns"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),
            new monstats_t(12, 10, 20, 40, 100, Speed.ULTRAFAST, 1, 0, _("Phoenix"), _("Phoenixes"),
                new cost_t(1500, 0, 1, 0, 0, 0, 0)),

            // atck dfnc  min  max   hp             speed grwn  shots  name                  multiname            cost
            new monstats_t(3, 1, 1, 2, 5, Speed.AVERAGE, 8, 8, _("Centaur"), _("Centaurs"),
                new cost_t(60, 0, 0, 0, 0, 0, 0)),
            new monstats_t(4, 7, 2, 3, 15, Speed.VERYFAST, 6, 0, _("Gargoyle"), _("Gargoyles"),
                new cost_t(200, 0, 0, 0, 0, 0, 0)),
            new monstats_t(6, 6, 3, 5, 25, Speed.AVERAGE, 4, 0, _("Griffin"), _("Griffins"),
                new cost_t(300, 0, 0, 0, 0, 0, 0)),
            new monstats_t(9, 8, 5, 10, 35, Speed.AVERAGE, 3, 0, _("Minotaur"), _("Minotaurs"),
                new cost_t(400, 0, 0, 0, 0, 0, 0)),
            new monstats_t(9, 8, 5, 10, 45, Speed.VERYFAST, 3, 0, _("Minotaur King"), _("Minotaur Kings"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),
            new monstats_t(8, 9, 6, 12, 75, Speed.VERYSLOW, 2, 0, _("Hydra"), _("Hydras"),
                new cost_t(800, 0, 0, 0, 0, 0, 0)),
            new monstats_t(12, 12, 25, 50, 200, Speed.AVERAGE, 1, 0, _("Green Dragon"), _("Green Dragons"),
                new cost_t(3000, 0, 0, 0, 1, 0, 0)),
            new monstats_t(13, 13, 25, 50, 250, Speed.FAST, 1, 0, _("Red Dragon"), _("Red Dragons"),
                new cost_t(3500, 0, 0, 0, 1, 0, 0)),
            new monstats_t(14, 14, 25, 50, 300, Speed.VERYFAST, 1, 0, _("Black Dragon"), _("Black Dragons"),
                new cost_t(4000, 0, 0, 0, 2, 0, 0)),

            // atck dfnc  min  max   hp             speed grwn  shots  name                  multiname            cost
            new monstats_t(2, 1, 1, 3, 3, Speed.SLOW, 8, 12, _("Halfling"), _("Halflings"),
                new cost_t(50, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 4, 2, 3, 15, Speed.VERYFAST, 6, 0, _("Boar"), _("Boars"),
                new cost_t(150, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 10, 4, 5, 30, Speed.VERYSLOW, 4, 0, _("Iron Golem"), _("Iron Golems"),
                new cost_t(300, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 10, 4, 5, 35, Speed.SLOW, 4, 0, _("Steel Golem"), _("Steel Golems"),
                new cost_t(350, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 7, 4, 8, 40, Speed.AVERAGE, 3, 0, _("Roc"), _("Rocs"), new cost_t(400, 0, 0, 0, 0, 0, 0)),
            new monstats_t(11, 7, 7, 9, 30, Speed.FAST, 2, 12, _("Mage"), _("Magi"), new cost_t(600, 0, 0, 0, 0, 0, 0)),
            new monstats_t(12, 8, 7, 9, 35, Speed.VERYFAST, 2, 24, _("Archmage"), _("Archmagi"),
                new cost_t(700, 0, 0, 0, 0, 0, 0)),
            new monstats_t(13, 10, 20, 30, 150, Speed.AVERAGE, 1, 0, _("Giant"), _("Giants"),
                new cost_t(2000, 0, 0, 0, 0, 0, 1)),
            new monstats_t(15, 15, 20, 30, 300, Speed.VERYFAST, 1, 24, _("Titan"), _("Titans"),
                new cost_t(5000, 0, 0, 0, 0, 0, 2)),

            // atck dfnc  min  max   hp             speed grwn  shots  name                  multiname            cost
            new monstats_t(4, 3, 2, 3, 4, Speed.AVERAGE, 8, 0, _("Skeleton"), _("Skeletons"),
                new cost_t(75, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 2, 2, 3, 15, Speed.VERYSLOW, 6, 0, _("Zombie"), _("Zombies"),
                new cost_t(150, 0, 0, 0, 0, 0, 0)),
            new monstats_t(5, 2, 2, 3, 25, Speed.AVERAGE, 6, 0, _("Mutant Zombie"), _("Mutant Zombies"),
                new cost_t(200, 0, 0, 0, 0, 0, 0)),
            new monstats_t(6, 6, 3, 4, 25, Speed.AVERAGE, 4, 0, _("Mummy"), _("Mummies"),
                new cost_t(250, 0, 0, 0, 0, 0, 0)),
            new monstats_t(6, 6, 3, 4, 30, Speed.FAST, 4, 0, _("Royal Mummy"), _("Royal Mummies"),
                new cost_t(300, 0, 0, 0, 0, 0, 0)),
            new monstats_t(8, 6, 5, 7, 30, Speed.AVERAGE, 3, 0, _("Vampire"), _("Vampires"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),
            new monstats_t(8, 6, 5, 7, 40, Speed.FAST, 3, 0, _("Vampire Lord"), _("Vampire Lords"),
                new cost_t(650, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 12, 8, 10, 25, Speed.FAST, 2, 12, _("Lich"), _("Liches"),
                new cost_t(750, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 13, 8, 10, 35, Speed.VERYFAST, 2, 24, _("Power Lich"), _("Power Liches"),
                new cost_t(900, 0, 0, 0, 0, 0, 0)),
            new monstats_t(11, 9, 25, 45, 150, Speed.AVERAGE, 1, 0, _("Bone Dragon"), _("Bone Dragons"),
                new cost_t(1500, 0, 0, 0, 0, 0, 0)),

            // atck dfnc  min  max   hp             speed grwn  shots  name                  multiname                cost
            new monstats_t(6, 1, 1, 2, 4, Speed.FAST, 4, 0, _("Rogue"), _("Rogues"), new cost_t(50, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 6, 2, 5, 20, Speed.VERYFAST, 4, 0, _("Nomad"), _("Nomads"),
                new cost_t(200, 0, 0, 0, 0, 0, 0)),
            new monstats_t(8, 7, 4, 6, 20, Speed.FAST, 4, 0, _("Ghost"), _("Ghosts"),
                new cost_t(1000, 0, 0, 0, 0, 0, 0)),
            new monstats_t(10, 9, 20, 30, 50, Speed.VERYFAST, 4, 0, _("Genie"), _("Genies"),
                new cost_t(650, 0, 0, 0, 0, 0, 1)),
            new monstats_t(8, 9, 6, 10, 35, Speed.AVERAGE, 4, 0, _("Medusa"), _("Medusas"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),
            new monstats_t(8, 8, 4, 5, 50, Speed.SLOW, 4, 0, _("Earth Elemental"), _("Earth Elementals"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),
            new monstats_t(7, 7, 2, 8, 35, Speed.VERYFAST, 4, 0, _("Air Elemental"), _("Air Elementals"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),
            new monstats_t(8, 6, 4, 6, 40, Speed.FAST, 4, 0, _("Fire Elemental"), _("Fire Elementals"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),
            new monstats_t(6, 8, 3, 7, 45, Speed.AVERAGE, 4, 0, _("Water Elemental"), _("Water Elementals"),
                new cost_t(500, 0, 0, 0, 0, 0, 0)),

            new monstats_t(0, 0, 0, 0, 0, Speed.VERYSLOW, 0, 0, "Random Monster", "Random Monsters",
                new cost_t(0, 0, 0, 0, 0, 0, 0)),
            new monstats_t(0, 0, 0, 0, 0, Speed.VERYSLOW, 0, 0, "Random Monster 1", "Random Monsters 3",
                new cost_t(0, 0, 0, 0, 0, 0, 0)),
            new monstats_t(0, 0, 0, 0, 0, Speed.VERYSLOW, 0, 0, "Random Monster 2", "Random Monsters 2",
                new cost_t(0, 0, 0, 0, 0, 0, 0)),
            new monstats_t(0, 0, 0, 0, 0, Speed.VERYSLOW, 0, 0, "Random Monster 3", "Random Monsters 3",
                new cost_t(0, 0, 0, 0, 0, 0, 0)),
            new monstats_t(0, 0, 0, 0, 0, Speed.VERYSLOW, 0, 0, "Random Monster 4", "Random Monsters 4",
                new cost_t(0, 0, 0, 0, 0, 0, 0))
        };

        public byte attack;
        public cost_t cost;
        public byte damageMax;
        public byte damageMin;
        public byte defense;
        public byte grown;
        public ushort hp;
        public string multiname;
        public string name;
        public byte shots;
        public byte speed;

        public monstats_t(byte attack, byte defense, byte damageMin, byte damageMax, ushort hp, Speed speed, byte grown,
            byte shots, string name, string multiname, cost_t cost)
        {
            this.attack = attack;
            this.defense = defense;
            this.damageMin = damageMin;
            this.damageMax = damageMax;
            this.hp = hp;
            this.speed = (byte) speed;
            this.grown = grown;
            this.shots = shots;
            this.name = name;
            this.multiname = multiname;
            this.cost = cost;
        }
    }
}