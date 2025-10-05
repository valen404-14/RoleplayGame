using Library;

namespace LibraryTests;

public class DwarfTest
{
    private Dwarf _dwarf;
    private Item _sword;
    private Item _helmet;
    private Item _healthPotion;
    
    [SetUp]
    public void Setup()
    {
        _dwarf = new Dwarf();
        _sword = new Item("Espada", 100, 0, 0, 0,false);
        _helmet = new Item("Casco", 0, 30, 0, 0, false);
        _healthPotion=new Item("Poción de vida",0,0,50,0,false);
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
    [Test]
    public void HealTest1()
    {
        _dwarf.UseItem(_healthPotion); //le suma 50 a health (en total 250)
        _dwarf.UseItem(_helmet); //le suma 30 a defense (en total 80).
        _dwarf.ReceiveAttack(15); //el damage al ser menor que defense, defense queda con 65 (50+30-15).
        _dwarf.Heal();//Como health actual (250) es mayor que 200, al utilizar el método Heal, debería devolver el valor actual de health (250)
        Assert.That(_dwarf.GetTotalHealth(), Is.EqualTo(250));
        Assert.That(_dwarf.GetTotalDefense(), Is.EqualTo(65));
    }
    [Test]
    public void HealTest2()
    {
        _dwarf.UseItem(_healthPotion); // le suma 50 a health (en total 250)
        _dwarf.UseItem(_helmet); //le suma 30 a defense (en total 80).
        _dwarf.ReceiveAttack(200);//Como defense es 80, y health es 250, al recibir un ataque de 200 se queda sin defensa, y con 130 de health
        Assert.That(_dwarf.GetTotalHealth(), Is.EqualTo(130));
        Assert.That(_dwarf.GetTotalDefense(), Is.EqualTo(0));
        _dwarf.Heal();//al usar Heal, y tener menos de 200 de health (130), ahora health se reestablece en el valor inicial (200)
        Assert.That(_dwarf.GetTotalHealth(), Is.EqualTo(200));
    }
}