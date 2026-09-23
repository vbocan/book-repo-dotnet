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

// Sintaxa de interogare (query syntax)
var rezultatQuery = from s in studenti
                    where s.AnStudiu == 3
                    orderby s.Medie descending
                    select new { s.Nume, s.Medie };

// Sintaxa metodă (method syntax / fluent syntax)
var rezultatMetoda = studenti
    .Where(s => s.AnStudiu == 3)
    .OrderByDescending(s => s.Medie)
    .Select(s => new { s.Nume, s.Medie });

Console.WriteLine("Studenți din anul 3 (ordonați descrescător după medie):");
foreach (var s in rezultatQuery)
{
    Console.WriteLine($"  {s.Nume}: {s.Medie:F2}");
}

record Student(string Nume, int AnStudiu, double Medie);
