// Exercițiul 8.1 - Prelucrarea fișierelor CSV
// Capitolul 8: Prelucrarea datelor cu LINQ: XML, JSON și CSV
//
// Rulare: dotnet run --project csharp/cap08-prelucrarea-datelor-linq/prelucrarea-fisierelor-csv
//
// Datele studenților se află în fișierul studenti.csv (Nume,AnStudiu,Nota1,Nota2,Nota3),
// copiat lângă executabil la compilare.

using System.Globalization;

// Formatare numerică independentă de cultură: punct zecimal, fără separator de mii
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

const double Prag = 8;

string[] linii = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "studenti.csv"));

// Parsarea rândurilor de date (sărim header-ul) și calculul mediei fiecărui student
List<Student> studenti = linii.Skip(1)
    .Where(linie => !string.IsNullOrWhiteSpace(linie))
    .Select(linie =>
    {
        string[] campuri = linie.Split(',');
        int[] note = campuri.Skip(2).Select(int.Parse).ToArray();
        return new Student(campuri[0], int.Parse(campuri[1]), note.Average());
    })
    .ToList();

// 1. Mediile tuturor studenților, descrescător
// (OrderByDescending este stabilă: la medii egale se păstrează ordinea din fișier)
var ordonati = studenti.OrderByDescending(s => s.Media).ToList();

Console.WriteLine("=== Medii studenți ===");
foreach (Student s in ordonati)
{
    Console.WriteLine($"  {s.Nume,-20} anul {s.AnStudiu}  media: {s.Media:F2}");
}

// 2. Studenții cu media peste prag
Console.WriteLine();
Console.WriteLine($"=== Studenți cu media >= {Prag} ===");
foreach (Student s in ordonati.Where(s => s.Media >= Prag))
{
    Console.WriteLine($"  {s.Nume,-20} {s.Media:F2}");
}

// 3. Statistici pe an de studiu
var statistici = studenti
    .GroupBy(s => s.AnStudiu)
    .OrderBy(g => g.Key)
    .Select(g => new
    {
        An = g.Key,
        Numar = g.Count(),
        Media = g.Average(s => s.Media),
        Max = g.Max(s => s.Media),
        Min = g.Min(s => s.Media)
    });

Console.WriteLine();
Console.WriteLine("=== Statistici pe an ===");
foreach (var st in statistici)
{
    Console.WriteLine($"  Anul {st.An}: {st.Numar} studenți, media: {st.Media:F2}, " +
        $"max: {st.Max:F2}, min: {st.Min:F2}");
}

record Student(string Nume, int AnStudiu, double Media);
