var p1 = new Produs("Laptop", 4500m);
var p2 = new Produs("Telefon", 2500m);
var p3 = new Produs("Tabletă", 1800m);

Console.WriteLine($"Produse create: {Produs.NumarProduse}");
Console.WriteLine(p1);
Console.WriteLine(p2);
Console.WriteLine(p3);

class Produs
{
    private static int _contorInstante = 0;

    public string Nume { get; set; }
    public decimal Pret { get; set; }

    public Produs(string nume, decimal pret)
    {
        Nume = nume;
        Pret = pret;
        _contorInstante++;
    }

    public static int NumarProduse => _contorInstante;

    public override string ToString() => $"{Nume}: {Pret:F2} RON";
}
