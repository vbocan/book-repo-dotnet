// Capitolul 5 - Moștenire, interfețe și polimorfism
// Secțiunea 5.4.4 - Pattern matching pe tipuri (C# 7+) (codul complet al exemplului)
//
// Descrie() ramifică după tipul concret al formei (type, property patterns,
// guard), iar CategorieArie() clasifică aria prin pattern-uri relaționale.
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/pattern-matching-pe-tipuri-csharp-7

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

FormaGeometrica[] forme =
[
    new Cerc(3),
    new Dreptunghi(5, 5),
    new Dreptunghi(4, 7),
    new Triunghi(6, 8)
];

foreach (var forma in forme)
{
    Console.WriteLine($"{Descrie(forma)} — arie {CategorieArie(forma)} ({forma.CalculeazaAria():F2})");
}

// Switch expression cu type patterns și property patterns
static string Descrie(FormaGeometrica f) => f switch
{
    Cerc c => $"Cerc cu raza {c.Raza:F1}",
    Dreptunghi { Latime: var l, Inaltime: var h } when l == h => $"Pătrat cu latura {l:F1}",
    Dreptunghi d => $"Dreptunghi {d.Latime:F1} × {d.Inaltime:F1}",
    Triunghi t => $"Triunghi cu baza {t.Baza:F1} și înălțimea {t.InaltimeTriunghi:F1}",
    _ => "Formă necunoscută"
};

// Pattern relațional combinat
static string CategorieArie(FormaGeometrica f) => f.CalculeazaAria() switch
{
    < 10 => "mică",
    >= 10 and < 100 => "medie",
    >= 100 => "mare",
    _ => "nedefinită"   // double.NaN: singura valoare neacoperită de ramurile de mai sus
};

abstract class FormaGeometrica
{
    public abstract double CalculeazaAria();
}

class Cerc(double raza) : FormaGeometrica
{
    public double Raza { get; } = raza;
    public override double CalculeazaAria() => Math.PI * Raza * Raza;
}

class Dreptunghi(double latime, double inaltime) : FormaGeometrica
{
    public double Latime { get; } = latime;
    public double Inaltime { get; } = inaltime;
    public override double CalculeazaAria() => Latime * Inaltime;
}

// Triunghi dat prin bază și înălțimea corespunzătoare
class Triunghi(double baza, double inaltime) : FormaGeometrica
{
    public double Baza { get; } = baza;
    public double InaltimeTriunghi { get; } = inaltime;
    public override double CalculeazaAria() => Baza * InaltimeTriunghi / 2;
}
