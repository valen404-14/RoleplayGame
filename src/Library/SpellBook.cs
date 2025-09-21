namespace Library;

public class SpellBook
{
    public List<Spell> spells = new List<Spell>();

    public SpellBook(Spell[] initialSpells) // Recibe muchos hechizos
    {
        this.spells = new List<Spell>(initialSpells); // Convertir a List
    }

    public void AddSpell(Spell spell)
    {
        spells.Add(spell);
    }
}