using Library;

namespace LibraryTests;

public class DwarfTest
{
    private Dwarf _dwarf;
    private Item _sword;
    
    [SetUp]
    public void Setup()
    {
        _dwarf = new Dwarf();
        _sword = new Item("Espada", 100, 0, 0, 0,false);
    }
    [Test]
    public void TestGetTotalAttack()
    {
        _dwarf.UseItem(_sword); // El ataque inicial era de 20, y le suma 100 la espada, en total 120
        
        Assert.That(_dwarf.GetTotalAttack(), Is.EqualTo(120));
    }
    
    [Test]
    public void Attack()
    {
        _dwarf.ReceiveAttack(100); // Como el dwarf tiene 50 de defense y 200 de health, al recibir un damage de 100, debe quedarse sin defensa  y 150 de health
        
        Assert.That(_dwarf.GetTotalHealth(), Is.EqualTo(150));
        Assert.That(_dwarf.GetTotalDefense(),Is.EqualTo(0));
    }
    
    [Test]
    public void MagicItemInDwarfTest()
    {
        Item magicWand = new Item("Bastón mágico", 10, 0, 0, 50,true);
        int initialAttack = _dwarf.GetTotalAttack();
        _dwarf.UseItem(magicWand); // No debería modificar el ataque, ya que es un elemento mágico y solo le corresponde a los magos
        
        Assert.That(_dwarf.GetTotalAttack(), Is.EqualTo(initialAttack));
    }
}