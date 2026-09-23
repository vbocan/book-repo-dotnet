// Capitolul 4 - Programare orientată pe obiecte în C#
// Exercițiul 2 - Proprietăți și metode
//
// Clasa Dreptunghi cu proprietăți validate (Lungime, Latime), metodele
// GetArie() și GetPerimetru() și metoda Scala(), care multiplică ambele
// dimensiuni cu un factor dat.
//
// Rulare: dotnet run --project csharp/cap04-programare-orientata-obiecte/proprietati-si-metode

using System.Globalization;

// Formatare independentă de setările regionale: punct zecimal
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var dreptunghi = new Dreptunghi(10, 5);
Console.WriteLine(dreptunghi);
Console.WriteLine($"Arie: {dreptunghi.GetArie():F1}");
Console.WriteLine($"Perimetru: {dreptunghi.GetPerimetru():F1}");

dreptunghi.Scala(2);
Console.WriteLine($"După scalare ×2: {dreptunghi}");
Console.WriteLine($"Arie: {dreptunghi.GetArie():F1}");
Console.WriteLine($"Perimetru: {dreptunghi.GetPerimetru():F1}");

// Validarea din accesorul set respinge o lungime negativă
try
{
    dreptunghi.Lungime = -3;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Eroare: {ex.ParamName} — valoare invalidă");
}

class Dreptunghi
{
    // Semi-auto properties (C# 14): validare fără câmp explicit de stocare
    public double Lungime
    {
        get => field;
        set => field = value > 0 ? value
            : throw new ArgumentOutOfRangeException(nameof(Lungime),
                "Lungimea trebuie să fie pozitivă.");
    }

    public double Latime
    {
        get => field;
        set => field = value > 0 ? value
            : throw new ArgumentOutOfRangeException(nameof(Latime),
                "Lățimea trebuie să fie pozitivă.");
    }

    public Dreptunghi(double lungime, double latime)
    {
        Lungime = lungime;   // trece prin validarea din set
        Latime = latime;
    }

    public double GetArie() => Lungime * Latime;

    public double GetPerimetru() => 2 * (Lungime + Latime);

    public void Scala(double factor)
    {
        if (factor <= 0)
            throw new ArgumentOutOfRangeException(nameof(factor),
                "Factorul de scalare trebuie să fie pozitiv.");
        Lungime *= factor;
        Latime *= factor;
    }

    public override string ToString() => $"Dreptunghi({Lungime:F1} × {Latime:F1})";
}
