namespace Library;

public interface ICharacter
{
    public void UseItem(Item item);
    public void ReceiveAttack(int damage);
    public void Heal();
}