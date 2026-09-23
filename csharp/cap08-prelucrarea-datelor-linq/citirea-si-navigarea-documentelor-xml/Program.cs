using System.Xml.Linq;

// Încărcarea din string (pentru fișier, folosiți XDocument.Load("cale.xml"))
string xml = """
    <studenti>
      <student id="1" an="3">
        <nume>Ana Popescu</nume>
        <nota materie="POO">9</nota>
        <nota materie="BD">8</nota>
        <nota materie="RC">10</nota>
      </student>
      <student id="2" an="2">
        <nume>Mihai Ionescu</nume>
        <nota materie="POO">7</nota>
        <nota materie="BD">6</nota>
        <nota materie="RC">8</nota>
      </student>
      <student id="3" an="3">
        <nume>Elena Dragomir</nume>
        <nota materie="POO">10</nota>
        <nota materie="BD">9</nota>
        <nota materie="RC">9</nota>
      </student>
    </studenti>
    """;

XDocument doc = XDocument.Parse(xml);

// Elementul rădăcină
XElement radacina = doc.Root!;
Console.WriteLine($"Element rădăcină: <{radacina.Name}>");

// Navigare prin elemente copil
foreach (XElement student in radacina.Elements("student"))
{
    string nume = student.Element("nume")!.Value;
    string id = student.Attribute("id")!.Value;
    string an = student.Attribute("an")!.Value;

    var note = student.Elements("nota")
        .Select(n => $"{n.Attribute("materie")!.Value}: {n.Value}");

    Console.WriteLine($"[{id}] {nume} (anul {an}) — {string.Join(", ", note)}");
}
