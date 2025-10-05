namespace Library;

public class Item
{
    private string _name;
    private int _attack;
    private int _defense;
    private int _health;
    private bool _hasMagic;
    private int _magic;

    public Item(string name, int attack, int defense, int health, int magic,bool hasMagic)
    {
        this._name = name;
        this._attack = attack;
        this._defense = defense;
        this._health = health;
        this._magic = magic;
        this._hasMagic = hasMagic;
    }
    
    public int GetAttack() => _attack;
    public int GetDefense() => _defense;
    public int GetHealth() => _health;
    public int GetMagic() => _magic;
    public bool HasMagic() => _hasMagic;

}