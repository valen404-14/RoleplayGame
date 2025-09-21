using Library;

namespace LibraryTests;

public class CharacterTests
{
    private Wizard wizard;
    private Dwarf dwarf;
    private Elf elf;
    private Item helmet;
    private Item bandages;
    private Item magicWand;
    private Item horrocrux;
    private Item sword;
    private Spell wingardiumLeviosa;
    private Spell avadaKedavra;
    
    [SetUp]
    public void Setup()
    {
        wizard = new Wizard();
        dwarf = new Dwarf();
        elf = new Elf();
        helmet = new Item("Casco", 0, 30, 0, 0);
        bandages = new Item("Curitas", 0, 0, 10, 0);
        magicWand = new Item("Bastón mágico", 10, 0, 0, 50);
        horrocrux = new Item("Horrocrux", 0, 100, 0, 40);
        sword = new Item("Espada", 100, 0, 0, 0);
        wingardiumLeviosa = new Spell("Wingardium Leviosa", 20);
        avadaKedavra = new Spell("Avada Kedavra", 100);
    }

    [Test]
    public void TestGetTotalDefense()
    {
        elf.UseItem(helmet); // Al inicializar tenía defense 15, y con el helmte ahora deberia tener 45
        
        Assert.That(elf.GetTotalDefense(), Is.EqualTo(45));
    }

    [Test]
    public void TestGetTotalAttack()
    {
        dwarf.UseItem(sword); // El ataque inicial era de 20, y le suma 100 la espada, en total 120
        
        Assert.That(dwarf.GetTotalAttack(), Is.EqualTo(120));
    }
}