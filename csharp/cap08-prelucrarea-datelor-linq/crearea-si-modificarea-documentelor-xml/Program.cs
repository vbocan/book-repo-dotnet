using System.Xml.Linq;

// Date sursă
var produse = new[]
{
    new { Cod = "P001", Nume = "Laptop", Pret = 3500.00m, Stoc = 15 },
    new { Cod = "P002", Nume = "Monitor", Pret = 1200.00m, Stoc = 30 },
    new { Cod = "P003", Nume = "Tastatură", Pret = 250.00m, Stoc = 50 },
    new { Cod = "P004", Nume = "Mouse", Pret = 120.00m, Stoc = 80 }
};

// Construcție funcțională — structura C# reflectă structura XML
XDocument raport = new XDocument(
    new XDeclaration("1.0", "utf-8", "yes"),
    new XElement("raport",
        new XAttribute("data", DateTime.Now.ToString("yyyy-MM-dd")),
        new XElement("titlu", "Raport inventar produse"),
        new XElement("produse",
            produse.Select(p =>
                new XElement("produs",
                    new XAttribute("cod", p.Cod),
                    new XElement("nume", p.Nume),
                    new XElement("pret", p.Pret),
                    new XElement("stoc", p.Stoc),
                    new XElement("valoare", p.Pret * p.Stoc)
                )
            )
        ),
        new XElement("sumar",
            new XElement("totalProduse", produse.Length),
            new XElement("valoareTotala", produse.Sum(p => p.Pret * p.Stoc))
        )
    )
);

Console.WriteLine(raport);
