using Library;

namespace LibraryTests;

public class WizardTest
{
    private Wizard _wizard;
    private Item _magicWand;
    private Item _horrocrux;
    private Spell _wingardiumLeviosa;
    private Spell _avadaKedavra;
    private Item _healthPotion;
    
    [SetUp]
    public void Setup()
    {
        _wizard = new Wizard();
        _magicWand = new Item("Bastón mágico", 10, 0, 0, 50,true);
        _horrocrux = new Item("Horrocrux", 0, 100, 0, 40,true);
        _wingardiumLeviosa = new Spell("Wingardium Leviosa", 20);
        _avadaKedavra = new Spell("Avada Kedavra", 100);
        _healthPotion=new Item("Poción de vida",0,0,50,0,false);
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

    [Test]
    public void ReceiveAttackTest()
    {
        _wizard.ReceiveAttack(150);//health queda en 150: defense queda en 0.
        Assert.That(_wizard.GetTotalHealth(), Is.EqualTo(150));
    }

    [Test]
    public void HealTest1()
    {
        _wizard.UseItem(_healthPotion); //+50 a health (300)
        _wizard.ReceiveAttack(45); //45<50, defense queda en 5. Health no se modifica (queda en 300).
        Assert.That(_wizard.GetTotalHealth(), Is.EqualTo(300));
        Assert.That(_wizard.GetTotalDefense(), Is.EqualTo(5));
        _wizard.Heal(); //al tener más de 250 de health (200), al usar este método debería volver al valor de health actual (300)
        Assert.That(_wizard.GetTotalHealth(), Is.EqualTo(300));
    }
    
    [Test]
    public void HealTest2()
    {
        _wizard.UseItem(_healthPotion); //+50 a health (300)
        _wizard.ReceiveAttack(150); //50<150, defense queda en 0. Health queda en 200.
        Assert.That(_wizard.GetTotalHealth(), Is.EqualTo(200));
        Assert.That(_wizard.GetTotalDefense(), Is.EqualTo(0));
        _wizard.Heal(); //al tener menos de 250 de health (200), al usar este método debería reestablecer health (devolviento del valor inicial, 250)
        Assert.That(_wizard.GetTotalHealth(), Is.EqualTo(250));
    }
}
