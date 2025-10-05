namespace Library;

public class SpellBook
{
    public List<Spell> Spells = new List<Spell>();

    public void AddSpell(Spell spell)
    {
        Spells.Add(spell);
    }
}