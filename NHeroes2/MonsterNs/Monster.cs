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
    }
}