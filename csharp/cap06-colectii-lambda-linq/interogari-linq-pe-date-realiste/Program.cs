// Capitolul 6 - Colecții, expresii lambda și LINQ
// Exercițiul 3 - Interogări LINQ pe date realiste
//
// Filtrare, ordonare, grupare și agregare pe o colecție de 12 studenți.
//
// Rulare: dotnet run --project csharp/cap06-colectii-lambda-linq/interogari-linq-pe-date-realiste

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

List<Student> studenti =
[
    new("Ana Popescu",       "Calculatoare", 3, 9.50),
    new("Ion Ionescu",       "Automatică",   3, 8.00),
    new("Maria Dumitrescu",  "Calculatoare", 3, 8.75),
    new("Vlad Georgescu",    "Automatică",   1, 6.20),
    new("Elena Marinescu",   "Calculatoare", 2, 9.10),
    new("Radu Constantin",   "Electronică",  2, 5.50),
    new("Laura Stanescu",    "Calculatoare", 3, 9.20),
    new("Bogdan Stoica",     "Electronică",  1, 7.85),
    new("Andrei Vasilescu",  "Automatică",   3, 7.60),
    new("Ioana Petrescu",    "Electronică",  2, 7.49),
    new("Mihai Florescu",    "Calculatoare", 1, 8.40),
    new("Cristina Radu",     "Automatică",   2, 6.59),
];

// 1. Filtrare și ordonare
Console.WriteLine("1. Studenți cu media > 8 (descrescător):");
var peste8 = studenti
    .Where(s => s.Medie > 8)
    .OrderByDescending(s => s.Medie);
foreach (var s in peste8)
    Console.WriteLine($"   {s.Nume} ({s.Specializare}, anul {s.An}): {s.Medie:F2}");

// 2. Grupare pe specializări, cu proiecție într-un tip anonim
Console.WriteLine();
Console.WriteLine("2. Media pe specializări:");
var peSpecializari = studenti
    .GroupBy(s => s.Specializare)
    .Select(g => new { Specializare = g.Key, Media = g.Average(s => s.Medie), Numar = g.Count() })
    .OrderByDescending(x => x.Media);
foreach (var x in peSpecializari)
    Console.WriteLine($"   {x.Specializare}: {x.Media:F2} ({x.Numar} studenți)");

// 3. Cel mai bun student din fiecare grupă (MaxBy, .NET 6+)
Console.WriteLine();
Console.WriteLine("3. Cel mai bun student din fiecare an:");
var celMaiBunPeAn = studenti
    .GroupBy(s => s.An)
    .OrderBy(g => g.Key)
    .Select(g => g.MaxBy(s => s.Medie)!);
foreach (var s in celMaiBunPeAn)
    Console.WriteLine($"   Anul {s.An}: {s.Nume} — {s.Medie:F2}");

// 4. Agregări pe întreaga colecție și operatori de cuantificare
Console.WriteLine();
Console.WriteLine("4. Statistici generale:");
Console.WriteLine($"   Total studenți: {studenti.Count}");
Console.WriteLine($"   Media generală: {studenti.Average(s => s.Medie):F2}");
Console.WriteLine($"   Nota minimă: {studenti.Min(s => s.Medie):F2}");
Console.WriteLine($"   Nota maximă: {studenti.Max(s => s.Medie):F2}");
Console.WriteLine($"   Bursieri (medie ≥ 8.5): {studenti.Count(s => s.Medie >= 8.5)}");
Console.WriteLine($"   Toți promovați? {studenti.All(s => s.Medie >= 5)}");

// 5. Mai multe agregări pe fiecare grupă
Console.WriteLine();
Console.WriteLine("5. Statistici pe ani de studiu:");
var statisticiPeAn =
    from s in studenti
    group s by s.An into g
    orderby g.Key
    select new
    {
        An = g.Key,
        Numar = g.Count(),
        Media = g.Average(s => s.Medie),
        Min = g.Min(s => s.Medie),
        Max = g.Max(s => s.Medie),
    };
foreach (var x in statisticiPeAn)
    Console.WriteLine($"   Anul {x.An}: {x.Numar} studenți, media {x.Media:F2}, min {x.Min:F2}, max {x.Max:F2}");

record Student(string Nume, string Specializare, int An, double Medie);
