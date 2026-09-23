using System.Text.Json;
using System.Text.Encodings.Web; // pentru encoder-ul care păstrează diacriticele
using System.Xml.Linq;

// Pornim de la XML-ul generat anterior (sau orice XML)
string xmlSursa = """
    <produse>
      <categorie nume="Electronice" total="4300">
        <produs cod="P001"><denumire>Laptop Dell</denumire><pret>3200</pret></produs>
        <produs cod="P002"><denumire>Monitor LG</denumire><pret>1100</pret></produs>
      </categorie>
      <categorie nume="Audio" total="400">
        <produs cod="P005"><denumire>Căști Sony</denumire><pret>400</pret></produs>
      </categorie>
    </produse>
    """;

XDocument xmlDoc = XDocument.Parse(xmlSursa);

// Transformare XML → structură anonimă → JSON
var structura = xmlDoc.Root!.Elements("categorie")
    .Select(cat => new
    {
        Categorie = (string)cat.Attribute("nume")!,
        Total = (int)cat.Attribute("total")!,
        Produse = cat.Elements("produs")
            .Select(p => new
            {
                Cod = (string)p.Attribute("cod")!,
                Denumire = (string)p.Element("denumire")!,
                Pret = (int)p.Element("pret")!
            })
            .ToArray()
    })
    .ToArray();

var optiuni = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    // Păstrează diacriticele lizibile în loc să le escapeze (\uXXXX)
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

string jsonRezultat = JsonSerializer.Serialize(structura, optiuni);
Console.WriteLine("=== XML → JSON ===");
Console.WriteLine(jsonRezultat);
