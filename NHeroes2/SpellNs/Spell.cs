namespace NHeroes2.SpellNs
{
    public class Spell
    {
        public SpellType Id { get; }

        public Spell(SpellType id = SpellType.NONE)
        {
            this.Id = id;
        }
    }
}