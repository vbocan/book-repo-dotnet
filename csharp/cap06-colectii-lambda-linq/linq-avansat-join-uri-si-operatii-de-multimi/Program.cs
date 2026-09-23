// Capitolul 6 - Colecții, expresii lambda și LINQ
// Exercițiul 4 - LINQ avansat: join-uri și operații de mulțimi
//
// Combinarea studenților cu notele lor prin Join și GroupJoin, operații de
// mulțimi (Intersect, Except, Union) și o grupare pe cursuri.
//
// Rulare: dotnet run --project csharp/cap06-colectii-lambda-linq/linq-avansat-join-uri-si-operatii-de-multimi

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

List<Student> studenti =
[
    new(1, "Ana Popescu"),
    new(2, "Ion Ionescu"),
    new(3, "Maria Dumitrescu"),
    new(4, "Vlad Georgescu"),
    new(5, "Elena Marinescu"),
];

List<Nota> note =
[
    new(1, "Programare .NET", 10),
    new(1, "Baze de date", 9),
    new(2, "Programare .NET", 7),
    new(2, "Rețele", 8),
    new(3, "Programare .NET", 9),
    new(3, "Baze de date", 8),
    new(3, "Algoritmi", 10),
    new(4, "Rețele", 6),
    new(5, "Programare .NET", 9),
    new(5, "Algoritmi", 8),
];

// Join: o pereche (student, notă) pentru fiecare potrivire a cheilor
Console.WriteLine("=== Join: studenți cu note ===");
var studentiCuNote = studenti.Join(note,
    s => s.Id, n => n.StudentId,
    (s, n) => new { s.Nume, n.Curs, n.Valoare });
foreach (var x in studentiCuNote)
    Console.WriteLine($"  {x.Nume}: {x.Curs} — nota {x.Valoare}");

// GroupJoin: fiecare student împreună cu colecția notelor sale
Console.WriteLine();
Console.WriteLine("=== GroupJoin: medii pe studenți ===");
var mediiPeStudenti = studenti
    .GroupJoin(note,
        s => s.Id, n => n.StudentId,
        (s, noteStudent) => new
        {
            s.Nume,
            NumarCursuri = noteStudent.Count(),
            Media = noteStudent.Average(n => n.Valoare),
        })
    .OrderByDescending(x => x.Media);
foreach (var x in mediiPeStudenti)
    Console.WriteLine($"  {x.Nume}: {x.NumarCursuri} cursuri, media {x.Media:F2}");

// Operații de mulțimi pe cursurile a doi studenți
Console.WriteLine();
Console.WriteLine("=== Operații de mulțimi ===");
IEnumerable<string> CursuriStudent(int id) =>
    note.Where(n => n.StudentId == id).Select(n => n.Curs);

var cursuriAna = CursuriStudent(1).ToList();
var cursuriMaria = CursuriStudent(3).ToList();

// TrimEnd elimină spațiul rămas după „:" atunci când mulțimea este vidă
static void AfiseazaMultime(string eticheta, IEnumerable<string> cursuri) =>
    Console.WriteLine($"{eticheta}: {string.Join(", ", cursuri)}".TrimEnd());

AfiseazaMultime("Cursuri Ana", cursuriAna);
AfiseazaMultime("Cursuri Maria", cursuriMaria);
AfiseazaMultime("Comune", cursuriAna.Intersect(cursuriMaria));
AfiseazaMultime("Doar Ana", cursuriAna.Except(cursuriMaria));
AfiseazaMultime("Doar Maria", cursuriMaria.Except(cursuriAna));
AfiseazaMultime("Toate (reuniune)", cursuriAna.Union(cursuriMaria));

// Grupare pe cursuri, ordonată după numărul de studenți
// (OrderByDescending este stabil: la egalitate se păstrează ordinea grupelor)
Console.WriteLine();
Console.WriteLine("=== Cele mai populare cursuri ===");
var cursuriPopulare = note
    .GroupBy(n => n.Curs)
    .Select(g => new { Curs = g.Key, Numar = g.Count(), Media = g.Average(n => n.Valoare) })
    .OrderByDescending(x => x.Numar);
foreach (var x in cursuriPopulare)
    Console.WriteLine($"  {x.Curs}: {x.Numar} studenți, nota medie {x.Media:F2}");

record Student(int Id, string Nume);
record Nota(int StudentId, string Curs, int Valoare);
