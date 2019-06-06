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
            throw new System.NotImplementedException();
        }

        public string GetName() => monstats_t.monsters[(int) id].name;
        public string GetMultiName() => monstats_t.monsters[(int) id].multiname;
    }
}