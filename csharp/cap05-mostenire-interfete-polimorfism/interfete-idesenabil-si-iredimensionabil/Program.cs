// Capitolul 5 - Moștenire, interfețe și polimorfism
// Exercițiul 2 - Interfețe IDesenabil și IRedimensionabil
//
// Formele implementează două interfețe mici și independente (ISP). Metodele
// DeseneazaToate() și RedimensioneazaToate() depind doar de interfețe, deci
// funcționează cu orice tip care respectă contractul.
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/interfete-idesenabil-si-iredimensionabil

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var cerc = new Cerc(5);
var dreptunghi = new Dreptunghi(8, 4);

// Aceleași obiecte, văzute prin două interfețe diferite
IDesenabil[] desenabile = [cerc, dreptunghi];
IRedimensionabil[] redimensionabile = [cerc, dreptunghi];

DeseneazaToate(desenabile);
Console.WriteLine();

RedimensioneazaToate(redimensionabile, 1.5);
Console.WriteLine();

DeseneazaToate(desenabile);

static void Deseneaza(IDesenabil element) => element.Deseneaza();

static void DeseneazaToate(IDesenabil[] elemente)
{
    Console.WriteLine("=== Desen complet ===");
    foreach (var element in elemente)
    {
        Deseneaza(element);
    }
    Console.WriteLine("=====================");
}

static void RedimensioneazaToate(IRedimensionabil[] elemente, double factor)
{
    Console.WriteLine($"Redimensionare cu factorul {factor:F1}:");
    foreach (var element in elemente)
    {
        element.Redimensioneaza(factor);
        Console.WriteLine($"  {element.GetType().Name} redimensionat: {element.Dimensiuni}");
    }
}

interface IDesenabil
{
    void Deseneaza();
}

interface IRedimensionabil
{
    void Redimensioneaza(double factor);
    string Dimensiuni { get; }
}

class Cerc(double raza) : IDesenabil, IRedimensionabil
{
    public double Raza { get; private set; } = raza;

    public void Deseneaza() => Console.WriteLine($"[Desenare] Cerc cu raza {Raza:F1}");

    public void Redimensioneaza(double factor)
    {
        if (factor <= 0) throw new ArgumentOutOfRangeException(nameof(factor));
        Raza *= factor;
    }

    public string Dimensiuni => $"raza = {Raza:F1}";
}

class Dreptunghi(double latime, double inaltime) : IDesenabil, IRedimensionabil
{
    public double Latime { get; private set; } = latime;
    public double Inaltime { get; private set; } = inaltime;

    public void Deseneaza() => Console.WriteLine($"[Desenare] Dreptunghi {Latime:F1} × {Inaltime:F1}");

    public void Redimensioneaza(double factor)
    {
        if (factor <= 0) throw new ArgumentOutOfRangeException(nameof(factor));
        Latime *= factor;
        Inaltime *= factor;
    }

    public string Dimensiuni => $"{Latime:F1} × {Inaltime:F1}";
}
