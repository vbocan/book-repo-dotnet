var cerc = new Cerc(3);
cerc.Deseneaza();
Console.WriteLine($"Aria: {cerc.CalculeazaAria():F2}");

interface IDesenabil
{
    void Deseneaza();
}

interface IMasurabila
{
    double CalculeazaAria();
    double CalculeazaPerimetrul();
}

class Cerc : IDesenabil, IMasurabila
{
    public double Raza { get; }

    public Cerc(double raza) => Raza = raza;

    public void Deseneaza()
    {
        Console.WriteLine($"Desenez un cerc cu raza {Raza}");
    }

    public double CalculeazaAria() => Math.PI * Raza * Raza;
    public double CalculeazaPerimetrul() => 2 * Math.PI * Raza;
}
