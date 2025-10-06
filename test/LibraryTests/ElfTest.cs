using Library;
namespace LibraryTests;

public class ElfTest
{

    private Elf _elf;
    private Item _helmet;
    private Item _heathPotion;
    private Item _bow;

    [SetUp]
    public void Setup()
    {
        
        _elf = new Elf();
        _helmet = new Item("Casco", 0, 30, 0, 0,false);
        _heathPotion = new Item("Poción de vida",0,0,50,0,false);
        _bow = new Item("Arco", 70, 0, 0, 0, false);
    }
    [Test]
    public void TestGetTotalDefense()
    {
        _elf.UseItem(_helmet); // Al inicializar tenía defense 15, y con el helmte ahora deberia tener 45
        
        Assert.That(_elf.GetTotalDefense(), Is.EqualTo(45));
    }
    [Test]
    public void TestGetTotalAttack()
    {
        _elf.UseItem(_bow); // Al inicializar tenía attack 30, y con el bow ahora deberia tener 100
        
        Assert.That(_elf.GetTotalAttack(), Is.EqualTo(100));
    }
    
    [Test]
    public void HealTest1() 
    {
        _elf.UseItem(_heathPotion); //+50 en health (queda en 275)
        _elf.ReceiveAttack(14);// Elf tiene 15 de defense. Al atacarlo con damage 14, defense debe quedar en 1, y health no se ve afectada.
        Assert.That(_elf.GetTotalDefense(), Is.EqualTo(1));
        _elf.Heal(); // Como health actual (275) es mayor que 225, al utilizar el método Heal, debería devolver el valor actual de health (275)
        Assert.That(_elf.GetTotalHealth(), Is.EqualTo(275));
    }
    
    [Test]
    public void HealTest2() 
    {
        _elf.ReceiveAttack(40);// El elf tiene 225 de health y 15 de defense. Al atacarlo con damage 40, se debe quedar sin defensa y su health en 200.
        _elf.Heal(); // Al curarlo, su health debe volver a 225
        Assert.That(_elf.GetTotalHealth(), Is.EqualTo(225));
    }

    [Test]
    public void MagicItemInElfTest()
    {
        Item magicWand = new Item("Bastón mágico", 10, 0, 0, 50,true);
        int initialMagic = _elf.GetMagic();
        _elf.UseItem(magicWand); // No debería modificar la magia del elfo, ya que al ser un elemento mágico solo lo debe usar el mago
        
        Assert.That(_elf.GetMagic(), Is.EqualTo(initialMagic));
    }
}