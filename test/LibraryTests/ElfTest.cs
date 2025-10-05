using Library;
namespace LibraryTests;

public class ElfTest
{

    private Elf elf;
    private Item helmet;
  

    [SetUp]
    public void Setup()
    {
        
        elf = new Elf();
        helmet = new Item("Casco", 0, 30, 0, 0,false);
    }
    [Test]
    public void TestGetTotalDefense()
    {
        elf.UseItem(helmet); // Al inicializar tenía defense 15, y con el helmte ahora deberia tener 45
        
        Assert.That(elf.GetTotalDefense(), Is.EqualTo(45));
    }
    [Test]
    public void Heal() 
    {
        elf.ReceiveAttack(40);// El elf tiene 225 de health y 15 de defense. Al atacarlo con damage 40, se debe quedar sin defensa y su health en 200.
        elf.Heal(); // Al curarlo, su health debe volver a 225
        
        Assert.That(elf.GetTotalHealth(), Is.EqualTo(225));
    }

}