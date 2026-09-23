// Capitolul 4 - Programare orientată pe obiecte în C#
// Exercițiul 3 - Constructori și modificatori de acces
//
// Clasa Masina are câmpuri private, doi constructori (unul îl apelează pe
// celălalt prin this(...)) și metode publice de acces. Clasa MasinaPrimara
// este varianta alternativă, cu constructor primar (C# 12).
//
// Rulare: dotnet run --project csharp/cap04-programare-orientata-obiecte/constructori-si-modificatori-de-acces

using System.Globalization;

// Separatorul de mii „," și punctul zecimal nu depind de setările regionale
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Varianta clasică: mașină nouă (0 km), apoi rulăm 18 200 km
var dacia = new Masina("Dacia", "Duster", 2023);
dacia.Ruleaza(18_200);
Console.WriteLine(dacia.Descriere());

// Varianta cu constructor primar
var bmw = new MasinaPrimara("BMW", "X3", 2024, 8_500);
Console.WriteLine(bmw.Descriere());

class Masina
{
    // Câmpuri private: starea internă nu este accesibilă din exterior
    private readonly string _marca;
    private readonly string _model;
    private readonly int _anFabricatie;
    private int _kilometraj;

    // Constructorul complet
    public Masina(string marca, string model, int anFabricatie, int kilometraj)
    {
        if (kilometraj < 0)
            throw new ArgumentOutOfRangeException(nameof(kilometraj));
        _marca = marca;
        _model = model;
        _anFabricatie = anFabricatie;
        _kilometraj = kilometraj;
    }

    // Constructor pentru o mașină nouă: deleagă constructorului complet
    public Masina(string marca, string model, int anFabricatie)
        : this(marca, model, anFabricatie, 0)
    {
    }

    // Metode publice de acces (doar citire)
    public string GetMarca() => _marca;
    public string GetModel() => _model;
    public int GetAnFabricatie() => _anFabricatie;
    public int GetKilometraj() => _kilometraj;

    // Singura cale de a modifica kilometrajul: acesta nu poate scădea
    public void Ruleaza(int kilometri)
    {
        if (kilometri <= 0)
            throw new ArgumentOutOfRangeException(nameof(kilometri));
        _kilometraj += kilometri;
    }

    public string Descriere() =>
        $"{_marca} {_model} ({_anFabricatie}) — {_kilometraj:N0} km";
}

// Varianta alternativă cu constructor primar (C# 12)
class MasinaPrimara(string marca, string model, int anFabricatie, int kilometraj)
{
    public string Marca { get; } = marca;
    public string Model { get; } = model;
    public int AnFabricatie { get; } = anFabricatie;
    public int Kilometraj { get; private set; } = kilometraj;

    public void Ruleaza(int kilometri)
    {
        if (kilometri <= 0)
            throw new ArgumentOutOfRangeException(nameof(kilometri));
        Kilometraj += kilometri;
    }

    public string Descriere() =>
        $"{Marca} {Model} ({AnFabricatie}) — {Kilometraj:N0} km";
}
