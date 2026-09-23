// Exercițiul 8.2 - Prelucrarea documentelor XML
// Capitolul 8: Prelucrarea datelor cu LINQ: XML, JSON și CSV
//
// Rulare: dotnet run --project csharp/cap08-prelucrarea-datelor-linq/prelucrarea-documentelor-xml
//
// Catalogul se află în fișierul catalog-carti.xml, copiat lângă executabil la compilare.
// Documentul modificat este salvat ca catalog-carti-modificat.xml în același director.

using System.Globalization;
using System.Xml.Linq;

// Formatare numerică independentă de cultură: punct zecimal, fără separator de mii
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

string director = AppContext.BaseDirectory;
XDocument catalog = XDocument.Load(Path.Combine(director, "catalog-carti.xml"));

// 1. Filtrare și sortare: cărțile de programare, de la cea mai recentă
var cartiProgramare = catalog.Descendants("carte")
    .Where(c => (string)c.Attribute("gen")! == "Programare")
    .OrderByDescending(c => (int)c.Element("an")!)
    .Select(c => new
    {
        Titlu = (string)c.Element("titlu")!,
        Autor = (string)c.Element("autor")!,
        An = (int)c.Element("an")!,
        Pret = (decimal)c.Element("pret")!
    });

Console.WriteLine("=== Cărți de programare ===");
foreach (var c in cartiProgramare)
{
    Console.WriteLine($"  {c.Titlu} ({c.Autor}, {c.An}) — {c.Pret:F2} USD");
}

// 2. Agregare: numărul de cărți și valoarea totală pe gen, descrescător după total
var statisticiGen = catalog.Descendants("carte")
    .GroupBy(c => (string)c.Attribute("gen")!)
    .Select(g => new
    {
        Gen = g.Key,
        Numar = g.Count(),
        Total = g.Sum(c => (decimal)c.Element("pret")!)
    })
    .OrderByDescending(s => s.Total);

Console.WriteLine();
Console.WriteLine("=== Statistici pe gen ===");
foreach (var s in statisticiGen)
{
    Console.WriteLine($"  {s.Gen}: {FormatCarti(s.Numar)}, total {s.Total:F2} USD");
}

// 3. Modificarea documentului
XElement radacina = catalog.Root!;

// Adăugarea unei cărți noi prin construcție funcțională
radacina.Add(
    new XElement("carte",
        new XAttribute("isbn", "978-0073523323"),
        new XAttribute("gen", "Baze de date"),
        new XElement("titlu", "Database System Concepts"),
        new XElement("autor", "Abraham Silberschatz"),
        new XElement("an", 2019),
        new XElement("pret", 89.99m)));

// Actualizarea prețului unei cărți existente
XElement cleanCode = radacina.Elements("carte")
    .First(c => (string)c.Element("titlu")! == "Clean Code");
cleanCode.SetElementValue("pret", 29.99m);

// 4. Salvarea rezultatului și verificarea prin reîncărcarea fișierului salvat
string caleModificat = Path.Combine(director, "catalog-carti-modificat.xml");
catalog.Save(caleModificat);

XDocument salvat = XDocument.Load(caleModificat);
int numarCarti = salvat.Descendants("carte").Count();
decimal pretNou = salvat.Descendants("carte")
    .Where(c => (string)c.Element("titlu")! == "Clean Code")
    .Select(c => (decimal)c.Element("pret")!)
    .First();

Console.WriteLine();
Console.WriteLine($"După modificări: {FormatCarti(numarCarti)}");
Console.WriteLine($"Clean Code preț nou: {pretNou:F2} USD");

// Acordul substantivului cu numeralul: „1 carte”, „3 cărți”
static string FormatCarti(int numar) => numar == 1 ? "1 carte" : $"{numar} cărți";
