// Testare
var p1 = new Persoana { Nume = "Ana", Varsta = 22 };
var p2 = new Persoana { Nume = "Mihai", Varsta = 25 };

p1.SalutaCu("Bună ziua");
p2.SalutaCu("Salut");
Console.WriteLine(p1);
Console.WriteLine(p2);

class Persoana
{
    public string Nume { get; set; } = "";
    public int Varsta { get; set; }

    public void SalutaCu(string mesaj)
    {
        Console.WriteLine($"{mesaj}! Mă numesc {Nume} și am {Varsta} ani.");
    }

    public override string ToString() => $"{Nume}, {Varsta} ani";
}
