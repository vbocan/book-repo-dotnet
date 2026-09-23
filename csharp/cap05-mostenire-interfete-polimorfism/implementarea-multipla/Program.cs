// Capitolul 5 - Moștenire, interfețe și polimorfism
// Secțiunea 5.3.2 - Implementarea multiplă (codul complet al exemplului)
//
// Clasa Student implementează simultan IComparable<Student> (sortare),
// IEquatable<Student> (egalitate) și IFormattable (formatare personalizată).
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/implementarea-multipla

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var studenti = new List<Student>
{
    new() { Nume = "Andrei Popescu", Media = 8.75 },
    new() { Nume = "Maria Ionescu", Media = 9.50 },
    new() { Nume = "Dan Munteanu", Media = 7.90 },
    new() { Nume = "Elena Vasilescu", Media = 9.85 }
};

studenti.Sort();   // folosește IComparable<Student>.CompareTo

Console.WriteLine("Studenți ordonați după medie:");
foreach (var s in studenti)
{
    Console.WriteLine($"  {s:L}");   // folosește IFormattable.ToString("L", ...)
}

class Student : IComparable<Student>, IEquatable<Student>, IFormattable
{
    public string Nume { get; init; } = "";
    public double Media { get; init; }

    public int CompareTo(Student? other)   // IComparable — sortare după medie
        => other is null ? 1 : Media.CompareTo(other.Media);

    public bool Equals(Student? other)     // IEquatable — egalitate structurală
        => other is not null && Nume == other.Nume && Media == other.Media;

    public string ToString(string? format, IFormatProvider? formatProvider)
        => format switch { "S" => Nume, "L" => $"{Nume} (media: {Media:F2})", _ => $"{Nume} — {Media:F2}" };

    // Suprascrieri coerente cu IEquatable<Student> și IFormattable
    public override bool Equals(object? obj) => Equals(obj as Student);
    public override int GetHashCode() => HashCode.Combine(Nume, Media);
    public override string ToString() => ToString(null, null);
}
