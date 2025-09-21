namespace Library;

public class SpellBook
{
    public List<Spell> spells = new List<Spell>();

    public void AddSpell(Spell spell)
    {
        spells.Add(spell);
    }
}