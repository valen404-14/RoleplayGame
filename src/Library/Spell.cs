namespace Library;

public class Spell
{
    private string name;
    private int magic; // Por ahora solo tendrá magic, más adelante puede tener otros atributos o compartamientos
    
    public Spell(string name, int magic)
    {
        this.name = name; 
        this.magic = magic;
    }

    public int GetMagic() => magic;
    public string GetName() => name;
}