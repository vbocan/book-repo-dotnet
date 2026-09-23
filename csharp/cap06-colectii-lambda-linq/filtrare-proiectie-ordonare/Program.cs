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

// Filtrare simplă
var bursieri = studenti.Where(s => s.Medie >= 8.50);
Console.WriteLine("Candidați la bursă (medie ≥ 8.50):");
foreach (var s in bursieri)
    Console.WriteLine($"  {s.Nume} (anul {s.AnStudiu}): {s.Medie:F2}");

// Filtrare cu mai multe condiții
var anulDoiPesteMedie = studenti
    .Where(s => s.AnStudiu == 2 && s.Medie > 7.0);

Console.WriteLine("\nAnul 2, medie > 7:");
foreach (var s in anulDoiPesteMedie)
    Console.WriteLine($"  {s.Nume}: {s.Medie:F2}");

record Student(string Nume, int AnStudiu, double Medie);
