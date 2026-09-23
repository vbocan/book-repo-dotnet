using System.Xml.Linq;

string[] csvDate =
[
    "Cod,Denumire,Categorie,Pret",
    "P001,Laptop Dell,Electronice,3200",
    "P002,Monitor LG,Electronice,1100",
    "P003,Scaun ergonomic,Mobilier,850",
    "P004,Birou reglabil,Mobilier,1500",
    "P005,Căști Sony,Audio,400"
];

// Parsare CSV
var produse = csvDate.Skip(1)
    .Select(linie =>
    {
        var c = linie.Split(',');
        return new { Cod = c[0], Denumire = c[1], Categorie = c[2], Pret = int.Parse(c[3]) };
    });

// Construcție XML cu LINQ
XDocument xmlDoc = new XDocument(
    new XElement("produse",
        produse.GroupBy(p => p.Categorie)
            .Select(g =>
                new XElement("categorie",
                    new XAttribute("nume", g.Key),
                    new XAttribute("total", g.Sum(p => p.Pret)),
                    g.Select(p =>
                        new XElement("produs",
                            new XAttribute("cod", p.Cod),
                            new XElement("denumire", p.Denumire),
                            new XElement("pret", p.Pret)
                        )
                    )
                )
            )
    )
);

Console.WriteLine("=== CSV → XML ===");
Console.WriteLine(xmlDoc);
