namespace Library;

public class Spell
{
    private string _name;
    private int _magic; // Por ahora solo tendrá magic, más adelante puede tener otros atributos o compartamientos
    
    public Spell(string name, int magic)
    {
        this._name = name; 
        this._magic = magic;
    }

    public int GetMagic() => _magic;
    public string GetName() => _name;
}