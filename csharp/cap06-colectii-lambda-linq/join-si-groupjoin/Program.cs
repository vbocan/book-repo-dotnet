List<Student> studenti =
[
    new(1, "Ana Popescu", 101),
    new(2, "Ion Ionescu", 102),
    new(3, "Maria Dumitrescu", 101),
    new(4, "Vlad Georgescu", 103),
    new(5, "Elena Marinescu", 102)
];

List<Specializare> specializari =
[
    new(101, "Calculatoare"),
    new(102, "Automatică"),
    new(103, "Electronică")
];

// Join — legătura între studenți și specializări
var rezultat = studenti.Join(
    specializari,                      // colecția cu care se face join
    student => student.IdSpecializare, // cheia din prima colecție
    spec => spec.Id,                   // cheia din a doua colecție
    (student, spec) => new             // selector de rezultat
    {
        student.Nume,
        Specializare = spec.Denumire
    });

Console.WriteLine("Studenți cu specializări:");
foreach (var r in rezultat)
    Console.WriteLine($"  {r.Nume} — {r.Specializare}");

record Student(int Id, string Nume, int IdSpecializare);

record Specializare(int Id, string Denumire);
