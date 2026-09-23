// Capitolul 5 - Moștenire, interfețe și polimorfism
// Exercițiul 1 - Ierarhia de forme geometrice și polimorfism
//
// Clasa abstractă FormaGeometrica declară CalculeazaAria() și
// CalculeazaPerimetrul(); Cerc, Dreptunghi și Triunghi le implementează.
// Codul care parcurge lista lucrează doar cu tipul de bază.
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/ierarhia-de-forme-geometrice-si-polimorfism

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

List<FormaGeometrica> forme =
[
    new Cerc(5),
    new Dreptunghi(4, 7),
    new Triunghi(3, 4, 5),
    new Cerc(2.5),
    new Dreptunghi(3, 10)
];

double arieTotala = 0;
double perimetruTotal = 0;
FormaGeometrica? formaMaxima = null;

Console.WriteLine("Forme geometrice:");
foreach (var forma in forme)
{
    Console.WriteLine($"  {forma}");

    // Apelurile sunt rezolvate polimorfic, după tipul real al obiectului
    arieTotala += forma.CalculeazaAria();
    perimetruTotal += forma.CalculeazaPerimetrul();

    if (formaMaxima is null || forma.CalculeazaAria() > formaMaxima.CalculeazaAria())
        formaMaxima = forma;
}

Console.WriteLine();
Console.WriteLine($"Arie totală: {arieTotala:F2}");
Console.WriteLine($"Perimetru total: {perimetruTotal:F2}");
Console.WriteLine();
Console.WriteLine($"Forma cu aria maximă: {formaMaxima}");

abstract class FormaGeometrica
{
    public abstract double CalculeazaAria();
    public abstract double CalculeazaPerimetrul();

    // Metodă concretă, comună tuturor formelor
    public override string ToString() =>
        $"{GetType().Name}: arie = {CalculeazaAria():F2}, perimetru = {CalculeazaPerimetrul():F2}";
}

class Cerc(double raza) : FormaGeometrica
{
    public double Raza { get; } = raza;

    public override double CalculeazaAria() => Math.PI * Raza * Raza;
    public override double CalculeazaPerimetrul() => 2 * Math.PI * Raza;
}

class Dreptunghi(double latime, double inaltime) : FormaGeometrica
{
    public double Latime { get; } = latime;
    public double Inaltime { get; } = inaltime;

    public override double CalculeazaAria() => Latime * Inaltime;
    public override double CalculeazaPerimetrul() => 2 * (Latime + Inaltime);
}

class Triunghi : FormaGeometrica
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triunghi(double a, double b, double c)
    {
        // Inegalitatea triunghiului: fiecare latură mai mică decât suma celorlalte
        if (a <= 0 || b <= 0 || c <= 0 || a >= b + c || b >= a + c || c >= a + b)
            throw new ArgumentException("Laturile nu formează un triunghi valid.");
        A = a;
        B = b;
        C = c;
    }

    // Formula lui Heron
    public override double CalculeazaAria()
    {
        double s = (A + B + C) / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    public override double CalculeazaPerimetrul() => A + B + C;
}
