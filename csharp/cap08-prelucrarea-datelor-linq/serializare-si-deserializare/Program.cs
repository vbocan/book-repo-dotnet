// Exemplul din secțiunea 8.2.2 - Serializare și deserializare
// Capitolul 8: Prelucrarea datelor cu LINQ: XML, JSON și CSV
//
// Rulare: dotnet run --project csharp/cap08-prelucrarea-datelor-linq/serializare-si-deserializare

using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

// Formatare numerică independentă de cultură: punct zecimal, fără separator de mii
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

string json = """
    {
      "universitate": "Politehnica Timișoara",
      "facultate": "Automatică și Calculatoare",
      "studenti": [
        {
          "nume": "Ana Popescu",
          "an": 3,
          "note": [9, 8, 10],
          "bursa": true
        },
        {
          "nume": "Mihai Ionescu",
          "an": 2,
          "note": [7, 6, 8],
          "bursa": false
        },
        {
          "nume": "Elena Dragomir",
          "an": 3,
          "note": [10, 9, 9],
          "bursa": true
        }
      ]
    }
    """;

// Deserializare: JSON -> obiecte tipizate
var optiuni = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
Facultate facultate = JsonSerializer.Deserialize<Facultate>(json, optiuni)!;

Console.WriteLine($"{facultate.Universitate} — {facultate.NumeFacultate}");
Console.WriteLine($"Număr studenți: {facultate.Studenti.Length}");
Console.WriteLine();

foreach (Student s in facultate.Studenti)
{
    Console.WriteLine($"  {s.Nume}, anul {s.An}, media {s.Note.Average():F2}, bursier: {s.Bursa}");
}

// Serializare: proiecție LINQ -> JSON
// Data raportului este fixată pentru un rezultat determinist; într-o aplicație reală
// s-ar folosi DateTime.Now.ToString("yyyy-MM-dd").
var dataRaport = new DateTime(2026, 3, 18);

var raportBursieri = new
{
    Titlu = "Studenți bursieri",
    Data = dataRaport.ToString("yyyy-MM-dd"),
    Bursieri = facultate.Studenti
        .Where(s => s.Bursa)
        .Select(s => new { s.Nume, Media = s.Note.Average() })
        .ToArray()
};

var optiuniScriere = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true,
    // Păstrează diacriticele lizibile în loc să le escapeze (\uXXXX)
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

Console.WriteLine();
Console.WriteLine(JsonSerializer.Serialize(raportBursieri, optiuniScriere));

record Student(string Nume, int An, int[] Note, bool Bursa);

record Facultate(
    string Universitate,
    [property: JsonPropertyName("facultate")] string NumeFacultate,
    Student[] Studenti
);
