// Capitolul 6 - Colecții, expresii lambda și LINQ
// Exercițiul 5 - Temă de casă: analiză de produse cu LINQ
//
// 1. Cel mai scump produs din fiecare categorie (GroupBy + MaxBy).
// 2. Prețul mediu pe categorii (Average, Sum).
// 3. Produsele cu prețul peste media generală (Where față de o valoare calculată).
// 4. Frecvența cuvintelor dintr-un paragraf (CountBy, .NET 9).
//
// Rulare: dotnet run --project csharp/cap06-colectii-lambda-linq/tema-de-casa-analiza-de-produse-cu-linq

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Prețurile se afișează fără zecimale, cu punctul ca separator de mii (4.500 RON)
var formatPret = new NumberFormatInfo { NumberGroupSeparator = ".", NumberGroupSizes = [3] };
string Lei(decimal suma) => $"{suma.ToString("#,0", formatPret)} RON";

List<Produs> produse =
[
    new("Laptop ASUS",       "Electronice", 4500m),
    new("Mouse wireless",    "Periferice",  150m),
    new("Placă video RTX",   "Componente",  3800m),
    new("Telefon Samsung",   "Electronice", 3200m),
    new("Tastatură mecanică","Periferice",  250m),
    new("Memorie RAM 32 GB", "Componente",  650m),
    new("Tableta iPad",      "Electronice", 2800m),
    new("Imprimantă laser",  "Periferice",  900m),
    new("SSD NVMe 1 TB",     "Componente",  520m),
    new("Smartwatch",        "Electronice", 1200m),
    new("Cameră web",        "Periferice",  300m),
    new("Sursă 750 W",       "Componente",  1100m),
    new("Boxe stereo",       "Periferice",  500m),
];

// 1. Cel mai scump produs din fiecare categorie
Console.WriteLine("1. Cel mai scump produs per categorie:");
var celeMaiScumpe = produse
    .GroupBy(p => p.Categorie)
    .Select(g => g.MaxBy(p => p.Pret)!);
foreach (var p in celeMaiScumpe)
    Console.WriteLine($"   {p.Categorie}: {p.Nume} — {Lei(p.Pret)}");

// 2. Prețul mediu pe categorii, descrescător
Console.WriteLine();
Console.WriteLine("2. Prețul mediu pe categorii:");
var statisticiCategorii = produse
    .GroupBy(p => p.Categorie)
    .Select(g => new
    {
        Categorie = g.Key,
        Media = g.Average(p => p.Pret),
        Numar = g.Count(),
        Total = g.Sum(p => p.Pret),
    })
    .OrderByDescending(x => x.Media);
foreach (var x in statisticiCategorii)
    Console.WriteLine($"   {x.Categorie}: media {Lei(x.Media)} ({x.Numar} produse, total {Lei(x.Total)})");

// 3. Produse peste media generală: media se calculează o singură dată, înainte de filtrare
decimal mediaGenerala = produse.Average(p => p.Pret);
Console.WriteLine();
Console.WriteLine($"3. Produse peste media generală ({Lei(mediaGenerala)}):");
var pesteMedie = produse
    .Where(p => p.Pret > mediaGenerala)
    .OrderByDescending(p => p.Pret);
foreach (var p in pesteMedie)
    Console.WriteLine($"   {p.Nume} ({p.Categorie}): {Lei(p.Pret)}");

// 4. Analiză de frecvență: primele 10 cuvinte, după frecvență și apoi alfabetic
string paragraf = """
    C# este un limbaj modern dezvoltat de Microsoft. C# combină paradigma
    orientată pe obiecte cu tehnici moderne. Limbajul C# este utilizat pe scară
    mare în proiecte de toate tipurile; platforma .NET este open-source.
    """;

var frecvente = paragraf
    .ToLower()
    .Split([' ', '\r', '\n', '.', ',', ';'], StringSplitOptions.RemoveEmptyEntries)
    .CountBy(cuvant => cuvant)
    .OrderByDescending(kv => kv.Value)
    // Comparare lingvistică: „în" se ordonează lângă „i", nu după „z" ca la comparația ordinală
    .ThenBy(kv => kv.Key, StringComparer.InvariantCulture)
    .Take(10);

Console.WriteLine();
Console.WriteLine("4. Analiză de frecvență a cuvintelor:");
foreach (var (cuvant, numar) in frecvente)
    Console.WriteLine($"   \"{cuvant}\": {numar}");

record Produs(string Nume, string Categorie, decimal Pret);
