namespace Library;

public class Wizard : ICharacter
{
    private int _health = 250;
    private int _attack = 75;
    private int _defense = 50;
    private int _magic = 100;
    private List<Item> _items = new List<Item>();
    private SpellBook _spellBook = new SpellBook();    

    public void UseItem(Item item)
    {
        this._defense += item.GetDefense();
        this._attack += item.GetAttack();
        this._health += item.GetHealth();
        this._magic += item.GetMagic();
        _items.Add(item);
    }

    public void StudySubject(Spell spell)
    {
        _spellBook.AddSpell(spell);
        _magic = _magic + spell.GetMagic();
    }

    public int GetTotalAttack() => _attack;
    public int GetTotalDefense() => _defense;
    public int GetTotalHealth() => _health;
    public int GetTotalMagic() => _magic;
    public void ReceiveAttack(int damage)
    {
        if (damage <= _defense)
        {
            _defense -= damage;
        }
        else
        {
            _defense -= damage;
            _health += _defense;
            _defense = 0;
        }
    }

    public void Heal()
    {
        if (_health < 250)
        {
            _health = 250;
        }
    }
}