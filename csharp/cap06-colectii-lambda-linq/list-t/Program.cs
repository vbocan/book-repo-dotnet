List<string> studenti = ["Ana", "Ion", "Maria"];

// Adăugare
studenti.Add("Vlad");
studenti.Insert(1, "Elena"); // inserare la indexul 1

Console.WriteLine("După adăugare:");
foreach (var s in studenti)
    Console.WriteLine($"  {s}");

// Căutare
bool existaAna = studenti.Contains("Ana");
int indexMaria = studenti.IndexOf("Maria");
Console.WriteLine($"\nConține 'Ana'? {existaAna}");
Console.WriteLine($"Indexul lui 'Maria': {indexMaria}");

// Eliminare
studenti.Remove("Ion");
Console.WriteLine($"\nDupă eliminarea lui 'Ion': {string.Join(", ", studenti)}");

// Sortare
studenti.Sort();
Console.WriteLine($"Sortați: {string.Join(", ", studenti)}");

// Proprietăți
Console.WriteLine($"\nCount: {studenti.Count}");
Console.WriteLine($"Capacity: {studenti.Capacity}");
