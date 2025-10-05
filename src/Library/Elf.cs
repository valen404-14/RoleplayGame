namespace Library;

public class Elf: ICharacter
{
    private int _health = 225;
    private int _attack = 30;
    private int _defense = 15;
    private int _magic = 30;
    
    private List<Item> _items = new List<Item>();

    public void UseItem(Item item)
    {
        if (item.HasMagic())
        {
            return;
        }
        this._defense += item.GetDefense();
        this._attack += item.GetAttack();
        this._health += item.GetHealth();
        this._magic += item.GetMagic();
        _items.Add(item);
    }

    public int GetTotalAttack() => _attack;
    public int GetTotalDefense() => _defense;
    public int GetTotalHealth() => _health;
    public int GetMagic() => _magic;

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
        if (_health < 225)
        {
            _health = 225;
        }
    }
}