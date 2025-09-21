using Library;

namespace LibraryTests;

public class CharacterTests
{
    private Wizard wizard;
    private Dwarf dwarf;
    private Elf elf;
    private Item helmet;
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
    
    [Test]
    public void Attack()
    {
        dwarf.ReceiveAttack(100); // Como el dwarf tiene 50 de defense y 200 de health, al recibir un damage de 100, debe quedarse sin defensa  y 150 de health
        
        Assert.That(dwarf.GetTotalHealth(), Is.EqualTo(150));
        Assert.That(dwarf.GetTotalDefense(),Is.EqualTo(0));
    }
    
    [Test]
    public void Heal() 
    {
        elf.ReciveAttack(40);// El elf tiene 225 de health y 15 de defense. Al atacarlo con damage 40, se debe quedar sin defensa y su health en 200.
        elf.Heal(); // Al curarlo, su health debe volver a 225
        
        Assert.That(elf.GetTotalHealth(), Is.EqualTo(225));
    }
    
    [Test]
    public void GetTotalMagic() 
    {
        wizard.StudySubject(wingardiumLeviosa); //La magic inicial del mago es de 100. Al estudiar este hechizo la magic del mago debería incrementarse 20
        wizard.StudySubject(avadaKedavra);//+ 100 del avadaKedavra
        wizard.UseItem(horrocrux);//+40
        wizard.UseItem(magicWand);//+50
        Assert.That(wizard.GetTotalMagic(),Is.EqualTo(310));
        
    }
}
