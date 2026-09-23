// Exemplul din secțiunea 8.1.2 - Interogări LINQ pe structuri XML
// Capitolul 8: Prelucrarea datelor cu LINQ: XML, JSON și CSV
//
// Rulare: dotnet run --project csharp/cap08-prelucrarea-datelor-linq/interogari-linq-pe-structuri-xml
//
// Catalogul de cărți se află în fișierul catalog.xml, copiat lângă executabil la compilare.
// Ordinea cărților din fișier contează: OrderByDescending este o sortare stabilă, deci
// cele două cărți din 2008 apar în ordinea din document (JavaScript: The Good Parts,
// apoi Clean Code).

using System.Globalization;
using System.Xml.Linq;

// Formatare numerică independentă de cultură: punct zecimal, fără separator de mii
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

XDocument catalog = XDocument.Load(Path.Combine(AppContext.BaseDirectory, "catalog.xml"));

// Cărți publicate după 2005, ordonate descrescător după an
var cartiRecente = catalog.Descendants("carte")
    .Where(c => (int)c.Element("an")! > 2005)
    .OrderByDescending(c => (int)c.Element("an")!)
    .Select(c => new
    {
        Titlu = (string)c.Element("titlu")!,
        An = (int)c.Element("an")!,
        Pret = (decimal)c.Element("pret")!
    });

Console.WriteLine("=== Cărți publicate după 2005 ===");
foreach (var carte in cartiRecente)
{
    Console.WriteLine($"  {carte.Titlu} ({carte.An}) — {carte.Pret:F2} USD");
}

// Statistici pe gen: număr de titluri și preț mediu
// (grupurile apar în ordinea primei apariții a genului în document)
var statisticiGen = catalog.Descendants("carte")
    .GroupBy(c => (string)c.Attribute("gen")!)
    .Select(g => new
    {
        Gen = g.Key,
        Numar = g.Count(),
        PretMediu = g.Average(c => (decimal)c.Element("pret")!)
    });

Console.WriteLine();
Console.WriteLine("=== Statistici pe gen ===");
foreach (var s in statisticiGen)
{
    string titluri = s.Numar == 1 ? "1 carte" : $"{s.Numar} cărți";
    Console.WriteLine($"  {s.Gen}: {titluri}, preț mediu {s.PretMediu:F2} USD");
}

// Cartea cea mai scumpă
XElement ceaMaiScumpa = catalog.Descendants("carte")
    .MaxBy(c => (decimal)c.Element("pret")!)!;

Console.WriteLine();
Console.WriteLine($"Cea mai scumpă carte: {(string)ceaMaiScumpa.Element("titlu")!} — " +
    $"{(decimal)ceaMaiScumpa.Element("pret")!:F2} USD");
