namespace Library;

public class Dwarf:ICharacter
{
    private int health = 200;
    private int attack = 20;
    private int defense = 50;
    private List<Item> items = new List<Item>();

    public void UseItem(Item item)
    {
        this.defense += item.GetDefense();
        this.attack += item.GetAttack();
        this.health += item.GetHealth();
        items.Add(item);
    }

    public int GetTotalAttack() => attack;
    public int GetTotalDefense() => defense;
    public int GetTotalHealth() => health;

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
        if (health < 200)
        {
            health = 200;
        }
    }

}