// Capitolul 5 - Moștenire, interfețe și polimorfism
// Secțiunea 5.4.1 - Suprascriere (virtual / override) (codul complet al exemplului)
//
// Un tablou de Angajat amestecă angajați full-time și part-time; apelul
// CalculeazaSalariu() este rezolvat la runtime către clasa derivată reală.
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/suprascriere-virtual-override

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

Angajat[] angajati =
[
    new AngajatFullTime("Maria Ionescu", 8000m, 1500m),
    new AngajatPartTime("Dan Popescu", 8000m, 80),
    new AngajatFullTime("Elena Vasilescu", 10000m, 2000m),
    new AngajatPartTime("Alex Munteanu", 6000m, 60)
];

decimal total = 0;
foreach (var a in angajati)
{
    decimal salariu = a.CalculeazaSalariu();   // dispatch polimorfic
    Console.WriteLine($"{a.Nume}: {salariu:N2} RON");
    total += salariu;
}

Console.WriteLine();
Console.WriteLine($"Total salarii: {total:N2} RON");

abstract class Angajat(string nume, decimal salariu)
{
    public string Nume { get; } = nume;
    public decimal SalariuBaza { get; } = salariu;
    public virtual decimal CalculeazaSalariu() => SalariuBaza;
}

// Salariu de bază plus bonus
class AngajatFullTime(string nume, decimal salariu, decimal bonus) : Angajat(nume, salariu)
{
    public override decimal CalculeazaSalariu() => SalariuBaza + bonus;
}

// Salariu proporțional cu orele lucrate dintr-o normă de 160 de ore pe lună
class AngajatPartTime(string nume, decimal salariu, int ore) : Angajat(nume, salariu)
{
    public override decimal CalculeazaSalariu() => SalariuBaza * ore / 160m;
}
