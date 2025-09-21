namespace Program;

public class Spell
{
    private int magic; // Por ahora solo tendrá magic, más adelante puede tener otros atributos o compartamientos
    
    public Spell(int magic)
    {
        this.magic = magic;
    }

    public int GetMagic() => magic;
}