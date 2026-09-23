using System.Xml.Linq;

string xml = """
    <config>
      <server>localhost</server>
      <port>8080</port>
      <debug>true</debug>
    </config>
    """;

XDocument config = XDocument.Parse(xml);
XElement root = config.Root!;

// Modificare valoare existentă
root.Element("port")!.Value = "9090";

// Adăugare element nou
root.Add(new XElement("timeout", "30"));

// Eliminare element
root.Element("debug")!.Remove();

// Adăugare atribut pe rădăcină
root.SetAttributeValue("versiune", "2.0");

Console.WriteLine(config);

// Salvare în fișier
// config.Save("config-nou.xml");
