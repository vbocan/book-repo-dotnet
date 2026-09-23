// Exemplul din secțiunea 8.3.2 - Transformări și interogări LINQ pe date CSV
// Capitolul 8: Prelucrarea datelor cu LINQ: XML, JSON și CSV
//
// Rulare: dotnet run --project csharp/cap08-prelucrarea-datelor-linq/transformari-si-interogari-linq-pe-date-csv
//
// Datele de vânzări se află în fișierul vanzari.csv (Produs,Regiune,Cantitate,PretUnitar),
// copiat lângă executabil la compilare.

using System.Globalization;

// Formatare numerică independentă de cultură: punct zecimal, fără separator de mii
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

string[] linii = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "vanzari.csv"));

// Proiecția fiecărei linii CSV (fără header) într-un record Vanzare
List<Vanzare> vanzari = linii.Skip(1)
    .Where(linie => !string.IsNullOrWhiteSpace(linie))
    .Select(linie =>
    {
        string[] c = linie.Split(',');
        return new Vanzare(
            c[0],
            c[1],
            int.Parse(c[2], CultureInfo.InvariantCulture),
            decimal.Parse(c[3], CultureInfo.InvariantCulture));
    })
    .ToList();

// 1. Total vânzări pe regiune
var totalPeRegiune = vanzari
    .GroupBy(v => v.Regiune)
    .Select(g => new
    {
        Regiune = g.Key,
        TotalVanzari = g.Sum(v => v.Cantitate * v.PretUnitar),
        NrTranzactii = g.Count()
    })
    .OrderByDescending(r => r.TotalVanzari);

Console.WriteLine("=== Total vânzări pe regiune ===");
foreach (var r in totalPeRegiune)
{
    Console.WriteLine($"  {r.Regiune,-8}{r.TotalVanzari:F2} RON  ({r.NrTranzactii} tranzacții)");
}

// 2. Top 3 produse după valoare
var topProduse = vanzari
    .GroupBy(v => v.Produs)
    .Select(g => new
    {
        Produs = g.Key,
        Valoare = g.Sum(v => v.Cantitate * v.PretUnitar),
        Bucati = g.Sum(v => v.Cantitate)
    })
    .OrderByDescending(p => p.Valoare)
    .Take(3);

Console.WriteLine();
Console.WriteLine("=== Top 3 produse după valoare ===");
foreach (var p in topProduse)
{
    Console.WriteLine($"  {p.Produs,-12}{p.Valoare:F2} RON  ({p.Bucati} bucăți)");
}

// 3. Matrice produs × regiune: dimensiunile se obțin cu Distinct
var produse = vanzari.Select(v => v.Produs).Distinct().Order(StringComparer.Ordinal).ToList();
var regiuni = vanzari.Select(v => v.Regiune).Distinct().Order(StringComparer.Ordinal).ToList();

Console.WriteLine();
Console.WriteLine("=== Matrice vânzări (valoare) ===");
Console.WriteLine($"  {"Produs",-12}{string.Concat(regiuni.Select(r => $"{r,8}"))}");
foreach (string produs in produse)
{
    // Pentru o combinație fără vânzări, Sum pe o secvență vidă returnează 0
    var celule = regiuni.Select(regiune => vanzari
        .Where(v => v.Produs == produs && v.Regiune == regiune)
        .Sum(v => v.Cantitate * v.PretUnitar));

    Console.WriteLine($"  {produs,-12}{string.Concat(celule.Select(valoare => $"{valoare,8:F0}"))}");
}

record Vanzare(string Produs, string Regiune, int Cantitate, decimal PretUnitar);
