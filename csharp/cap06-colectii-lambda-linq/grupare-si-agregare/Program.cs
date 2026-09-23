List<Student> studenti =
[
    new("Ana Popescu", 3, 9.50),
    new("Ion Ionescu", 2, 7.30),
    new("Maria Dumitrescu", 3, 8.75),
    new("Vlad Georgescu", 1, 6.20),
    new("Elena Marinescu", 2, 9.10),
    new("Andrei Vasilescu", 3, 8.00),
    new("Cristina Radu", 1, 7.85)
];

// Grupare după an de studiu
var grupuri = studenti.GroupBy(s => s.AnStudiu);

foreach (var grup in grupuri.OrderBy(g => g.Key))
{
    double mediaGrup = grup.Average(s => s.Medie);
    Console.WriteLine($"Anul {grup.Key} ({grup.Count()} studenți, media: {mediaGrup:F2}):");
    foreach (var s in grup.OrderByDescending(s => s.Medie))
    {
        Console.WriteLine($"  {s.Nume}: {s.Medie:F2}");
    }
}

record Student(string Nume, int AnStudiu, double Medie);
