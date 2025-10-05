using Library;

namespace LibraryTests;

public class WizardTest
{
    private Wizard _wizard;
    private Item _magicWand;
    private Item _horrocrux;
    private Spell _wingardiumLeviosa;
    private Spell _avadaKedavra;
    
    [SetUp]
    public void Setup()
    {
        _wizard = new Wizard();
        _magicWand = new Item("Bastón mágico", 10, 0, 0, 50,true);
        _horrocrux = new Item("Horrocrux", 0, 100, 0, 40,true);
        _wingardiumLeviosa = new Spell("Wingardium Leviosa", 20);
        _avadaKedavra = new Spell("Avada Kedavra", 100);
    }
    
    [Test]
    public void GetTotalMagic() 
    {
        _wizard.StudySubject(_wingardiumLeviosa); //La magic inicial del mago es de 100. Al estudiar este hechizo la magic del mago debería incrementarse 20
        _wizard.StudySubject(_avadaKedavra);//+ 100 del avadaKedavra
        _wizard.UseItem(_horrocrux);//+40
        _wizard.UseItem(_magicWand);//+50
        Assert.That(_wizard.GetTotalMagic(),Is.EqualTo(310));
    }
}
