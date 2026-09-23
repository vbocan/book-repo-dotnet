// Date CSV inline (în practică, citiți din fișier cu File.ReadAllLines)
string[] liniiCsv =
[
    "Nume,AnStudiu,Nota1,Nota2,Nota3",
    "Ana Popescu,3,9,8,10",
    "Mihai Ionescu,2,7,6,8",
    "Elena Dragomir,3,10,9,9",
    "Andrei Munteanu,2,8,7,9",
    "Maria Luca,3,6,8,7"
];

// Parsare: separăm header-ul de date
string[] header = liniiCsv[0].Split(',');
Console.WriteLine($"Coloane: {string.Join(" | ", header)}");
Console.WriteLine(new string('-', 50));

// Parsarea rândurilor de date
var studenti = liniiCsv.Skip(1)  // Sărim header-ul
    .Select(linie =>
    {
        string[] campuri = linie.Split(',');
        return new
        {
            Nume = campuri[0],
            AnStudiu = int.Parse(campuri[1]),
            Note = new[] {
                int.Parse(campuri[2]),
                int.Parse(campuri[3]),
                int.Parse(campuri[4])
            }
        };
    })
    .ToList();

foreach (var s in studenti)
{
    double media = s.Note.Average();
    Console.WriteLine($"  {s.Nume,-20} anul {s.AnStudiu}  " +
        $"note: [{string.Join(", ", s.Note)}]  media: {media:F2}");
}
