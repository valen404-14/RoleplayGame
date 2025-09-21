namespace Library;

public class Elf
{
    private int health = 225;
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
    public int GetTotalHealth()=> health;

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
        if (health < 225)
        {
            health = 225;
        }
    }
}