namespace Library;

public class Item
{
    private string name;
    private int attack;
    private int defense;
    private int health;
    private bool hasMagic;
    private int magic;

    public Item(string name, int attack, int defense, int health, int magic,bool hasMagic)
    {
        this.name = name;
        this.attack = attack;
        this.defense = defense;
        this.health = health;
        this.magic = magic;
        this.hasMagic = hasMagic;
    }
    
    public int GetAttack() => attack;
    public int GetDefense() => defense;
    public int GetHealth() => health;
    public int GetMagic() => magic;

}