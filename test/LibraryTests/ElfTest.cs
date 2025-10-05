using Library;
namespace LibraryTests;

public class ElfTest
{

    private Elf _elf;
    private Item _helmet;
  

    [SetUp]
    public void Setup()
    {
        
        _elf = new Elf();
        _helmet = new Item("Casco", 0, 30, 0, 0,false);
    }
    [Test]
    public void TestGetTotalDefense()
    {
        _elf.UseItem(_helmet); // Al inicializar tenía defense 15, y con el helmte ahora deberia tener 45
        
        Assert.That(_elf.GetTotalDefense(), Is.EqualTo(45));
    }
    [Test]
    public void HealTest() 
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