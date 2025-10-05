using Library;

namespace LibraryTests;

public class WizardTest
{
    private Wizard wizard;
    private Item magicWand;
    private Item horrocrux;
    private Spell wingardiumLeviosa;
    private Spell avadaKedavra;
    
    [SetUp]
    public void Setup()
    {
        wizard = new Wizard();
        magicWand = new Item("Bastón mágico", 10, 0, 0, 50,true);
        horrocrux = new Item("Horrocrux", 0, 100, 0, 40,true);
        wingardiumLeviosa = new Spell("Wingardium Leviosa", 20);
        avadaKedavra = new Spell("Avada Kedavra", 100);
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
