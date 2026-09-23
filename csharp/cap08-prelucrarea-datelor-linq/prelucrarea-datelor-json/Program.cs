// Exercițiul 8.3 - Prelucrarea datelor JSON
// Capitolul 8: Prelucrarea datelor cu LINQ: XML, JSON și CSV
//
// Rulare: dotnet run --project csharp/cap08-prelucrarea-datelor-linq/prelucrarea-datelor-json
//
// Tabloul de produse se află în fișierul produse.json, copiat lângă executabil la compilare.
// Rezultatul serializat este afișat și salvat ca produse-electronice.json în același director.

using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;

// Formatare numerică independentă de cultură: punct zecimal, fără separator de mii
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

string director = AppContext.BaseDirectory;
string json = File.ReadAllText(Path.Combine(director, "produse.json"));

// 1. Deserializare: cheile JSON sunt camelCase, proprietățile C# sunt PascalCase
var optiuniCitire = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
Produs[] produse = JsonSerializer.Deserialize<Produs[]>(json, optiuniCitire)!;

// 2. Produsele cu valoarea stocului peste 10000 RON, descrescător
var valoroase = produse
    .Select(p => new { p.Nume, p.Categorie, Valoare = p.Pret * p.Stoc })
    .Where(p => p.Valoare > 10000)
    .OrderByDescending(p => p.Valoare);

Console.WriteLine("=== Produse cu valoare stoc > 10000 RON ===");
foreach (var p in valoroase)
{
    Console.WriteLine($"  {p.Nume,-12} ({p.Categorie}): {p.Valoare:F0} RON");
}

// 3. Sumar pe categorie: număr de produse, valoarea stocului și prețul mediu
var sumar = produse
    .GroupBy(p => p.Categorie)
    .Select(g => new
    {
        Categorie = g.Key,
        Numar = g.Count(),
        Valoare = g.Sum(p => p.Pret * p.Stoc),
        PretMediu = g.Average(p => p.Pret)
    })
    .OrderByDescending(s => s.Valoare);

Console.WriteLine();
Console.WriteLine("=== Sumar pe categorie ===");
foreach (var s in sumar)
{
    // Prețul mediu este rotunjit la leu (1733.33 -> 1733)
    Console.WriteLine($"  {s.Categorie,-15}{s.Numar} produse, valoare: {s.Valoare:F0} RON, " +
        $"preț mediu: {s.PretMediu:F0} RON");
}

// 4. Serializare: proiecția produselor electronice, cu cheile în camelCase
var electronice = produse
    .Where(p => p.Categorie == "Electronice")
    .Select(p => new { p.Cod, p.Nume, p.Pret })
    .ToArray();

var optiuniScriere = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true,
    // Păstrează diacriticele lizibile în loc să le escapeze (\uXXXX)
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

string jsonElectronice = JsonSerializer.Serialize(electronice, optiuniScriere);
File.WriteAllText(Path.Combine(director, "produse-electronice.json"), jsonElectronice);

Console.WriteLine();
Console.WriteLine("=== Produse electronice (JSON) ===");
Console.WriteLine(jsonElectronice);

record Produs(string Cod, string Nume, string Categorie, decimal Pret, int Stoc);
