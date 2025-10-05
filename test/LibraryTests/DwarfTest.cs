using Library;

namespace LibraryTests;

public class DwarfTest
{
    private Dwarf dwarf;
    private Item sword;
    
    [SetUp]
    public void Setup()
    {
        dwarf = new Dwarf();
        sword = new Item("Espada", 100, 0, 0, 0,false);
    }
    [Test]
    public void TestGetTotalAttack()
    {
        dwarf.UseItem(sword); // El ataque inicial era de 20, y le suma 100 la espada, en total 120
        
        Assert.That(dwarf.GetTotalAttack(), Is.EqualTo(120));
    }
    
    [Test]
    public void Attack()
    {
        dwarf.ReceiveAttack(100); // Como el dwarf tiene 50 de defense y 200 de health, al recibir un damage de 100, debe quedarse sin defensa  y 150 de health
        
        Assert.That(dwarf.GetTotalHealth(), Is.EqualTo(150));
        Assert.That(dwarf.GetTotalDefense(),Is.EqualTo(0));
    }
}