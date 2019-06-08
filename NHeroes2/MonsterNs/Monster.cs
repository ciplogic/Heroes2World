using System;

namespace NHeroes2.MonsterNs
{
    public class Monster
    {
        public MonsterType id;

        public Monster(MonsterType monsterType)
        {
            id = monsterType;
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return monstats_t.monsters[(int) id].name;
        }

        public string GetMultiName()
        {
            return monstats_t.monsters[(int) id].multiname;
        }
    }
}