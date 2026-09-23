var p = new Persoana("Elena", 22);
Console.WriteLine(p);       // apelează ToString()
p.Varsta = 23;
Console.WriteLine(p);

class Persoana
{
    public string Nume { get; set; }
    public int Varsta { get; set; }

    public Persoana(string nume, int varsta)
    {
        Nume = nume;
        Varsta = varsta;
    }

    public override string ToString() => $"{Nume}, {Varsta} ani";
}
