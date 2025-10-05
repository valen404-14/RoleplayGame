namespace Library;

public class Wizard : ICharacter
{
    private int health = 250;
    private int attack = 75;
    private int defense = 50;
    private int magic = 100;
    private List<Item> items = new List<Item>();
    private SpellBook spellBook = new SpellBook();    

    public void UseItem(Item item)
    {
        this.defense += item.GetDefense();
        this.attack += item.GetAttack();
        this.health += item.GetHealth();
        this.magic += item.GetMagic();
        items.Add(item);
    }

    public void StudySubject(Spell spell)
    {
        spellBook.AddSpell(spell);
        magic = magic + spell.GetMagic();
    }

    public int GetTotalAttack() => attack;
    public int GetTotalDefense() => defense;
    public int GetTotalHealth() => health;
    public int GetTotalMagic() => magic;
    public void ReceiveAttack(int damage)
    {
        if (damage <= defense)
        {
            defense -= damage;
        }
        else
        {
            defense -= damage;
            health += defense;
            defense = 0;
        }
    }

    public void Heal()
    {
        if (health < 250)
        {
            health = 250;
        }
    }
}