List<Nota> note =
[
    new("Ana", "POO", 10),
    new("Ion", "POO", 7),
    new("Ana", "BD", 9),
    new("Maria", "POO", 8),
    new("Ion", "BD", 6)
];
string[] grupa = ["Ana", "Ion", "Maria", "Vlad"];

// CountBy (.NET 9): numărul de note la fiecare disciplină
foreach (var (disciplina, numar) in note.CountBy(n => n.Disciplina))
    Console.WriteLine($"{disciplina}: {numar} note");

// AggregateBy (.NET 9): suma notelor fiecărui student
var totaluri = note.AggregateBy(n => n.Student, 0, (suma, n) => suma + n.Valoare);
Console.WriteLine(string.Join(", ", totaluri.Select(t => $"{t.Key} = {t.Value}")));

// Index (.NET 9): fiecare element împreună cu poziția lui
foreach (var (i, n) in note.Index().Take(2))
    Console.WriteLine($"#{i}: {n.Student}, {n.Disciplina}");

// LeftJoin (.NET 10): toți studenții grupei, inclusiv cei fără notă la BD
var noteBD = note.Where(n => n.Disciplina == "BD");
var situatieBD = grupa.LeftJoin(noteBD,
    s => s, n => n.Student,
    (s, n) => $"{s}: {n?.Valoare.ToString() ?? "—"}");
Console.WriteLine(string.Join(", ", situatieBD));

// RightJoin (.NET 10): aceeași interogare, cu sursele inversate
var situatieBD2 = noteBD.RightJoin(grupa,
    n => n.Student, s => s,
    (n, s) => $"{s}: {n?.Valoare.ToString() ?? "—"}");
Console.WriteLine(string.Join(", ", situatieBD2));

record Nota(string Student, string Disciplina, int Valoare);
