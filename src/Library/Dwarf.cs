namespace Library;

public class Dwarf : ICharacter
{
    private int _health = 200;
    private int _attack = 20;
    private int _defense = 50;
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
        _items.Add(item);
    }

    public int GetTotalAttack() => _attack;
    public int GetTotalDefense() => _defense;
    public int GetTotalHealth() => _health;

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
        if (_health < 200)
        {
            _health = 200;
        }
    }

}