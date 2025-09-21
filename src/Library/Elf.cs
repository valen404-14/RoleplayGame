namespace Library;

public class Elve
{
    private int health = 300;
    private int attack = 30;
    private int defense = 15;
    private int magic = 30;
    
    private List<Item> items = new List<Item>();

    public void UseItem(Item item)
    {
        this.defense += item.GetDefense();
        this.attack += item.GetAttack();
        this.health += item.GetHealth();
        this.magic += item.GetMagic();
        items.Add(item);
    }

    public int GetTotalAttack() => attack;
    public int GetTotalDefense() => defense;

    public void ReciveAttack(int damage)
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
        if (health < 200)
        {
            health = 200;
        }
    }
}