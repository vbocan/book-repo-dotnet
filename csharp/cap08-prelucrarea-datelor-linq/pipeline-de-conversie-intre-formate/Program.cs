// Exercițiul 8.4 - Pipeline de conversie între formate
// Capitolul 8: Prelucrarea datelor cu LINQ: XML, JSON și CSV
//
// Rulare: dotnet run --project csharp/cap08-prelucrarea-datelor-linq/pipeline-de-conversie-intre-formate
//
// Pipeline: CSV (angajati.csv) -> obiecte C# -> grupare LINQ pe departament ->
// export XML (raport-salarii.xml) și JSON (raport-salarii.json).
// Fișierul CSV este copiat lângă executabil la compilare; exporturile sunt salvate
// în același director și afișate în consolă.

using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Linq;

// Formatare numerică independentă de cultură: punct zecimal, fără separator de mii
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

string director = AppContext.BaseDirectory;

// Data raportului este fixată pentru un rezultat determinist; într-o aplicație reală
// s-ar folosi DateTime.Now.
var dataRaport = new DateTime(2026, 3, 18);

// 1. Citire: CSV -> obiecte Angajat
List<Angajat> angajati = File.ReadAllLines(Path.Combine(director, "angajati.csv"))
    .Skip(1)
    .Where(linie => !string.IsNullOrWhiteSpace(linie))
    .Select(linie =>
    {
        string[] c = linie.Split(',');
        return new Angajat(c[0], c[1], int.Parse(c[2]), int.Parse(c[3]));
    })
    .ToList();

// 2. Transformare: grupare pe departament, departamentele descrescător după salariul
//    mediu, angajații descrescător după salariu
List<Departament> departamente = angajati
    .GroupBy(a => a.Departament)
    .Select(g => new Departament(
        g.Key,
        g.Count(),
        (int)Math.Round(g.Average(a => a.Salariu)),
        g.Sum(a => a.Salariu),
        g.OrderByDescending(a => a.Salariu).ToArray()))
    .OrderByDescending(d => d.SalariuMediu)
    .ToList();

// 3a. Export XML prin construcție funcțională
XDocument xml = new XDocument(
    new XDeclaration("1.0", "utf-8", "yes"),
    new XElement("raport-salarii",
        new XAttribute("data", dataRaport.ToString("yyyy-MM-dd")),
        departamente.Select(d =>
            new XElement("departament",
                new XAttribute("nume", d.Nume),
                new XElement("nr-angajati", d.NrAngajati),
                new XElement("salariu-mediu", d.SalariuMediu),
                new XElement("fond-salarii", d.FondSalarii),
                new XElement("angajati",
                    d.Angajati.Select(a =>
                        new XElement("angajat",
                            new XAttribute("an-angajare", a.AnAngajare),
                            new XElement("nume", a.Nume),
                            new XElement("salariu", a.Salariu))))))));

xml.Save(Path.Combine(director, "raport-salarii.xml"));

Console.WriteLine("=== Export XML ===");
Console.WriteLine(xml);   // ToString() omite declarația <?xml ...?>

// 3b. Export JSON: aceeași structură, proiectată în tipuri anonime
var structura = departamente.Select(d => new
{
    Departament = d.Nume,
    d.NrAngajati,
    d.SalariuMediu,
    d.FondSalarii,
    // Departamentul nu se repetă la fiecare angajat: rezultă deja din grupare
    Angajati = d.Angajati.Select(a => new { a.Nume, a.Salariu, a.AnAngajare })
});

var optiuni = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true,
    // Păstrează diacriticele lizibile în loc să le escapeze (\uXXXX)
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

string json = JsonSerializer.Serialize(structura, optiuni);
File.WriteAllText(Path.Combine(director, "raport-salarii.json"), json);

Console.WriteLine();
Console.WriteLine("=== Export JSON ===");
Console.WriteLine(json);

record Angajat(string Nume, string Departament, int Salariu, int AnAngajare);

record Departament(string Nume, int NrAngajati, int SalariuMediu, int FondSalarii, Angajat[] Angajati);
