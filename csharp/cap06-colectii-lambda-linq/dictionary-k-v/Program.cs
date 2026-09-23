// Catalog de note
Dictionary<string, List<int>> catalogNote = new()
{
    ["Ana"] = [10, 9, 8],
    ["Ion"] = [7, 8, 6],
    ["Maria"] = [10, 10, 9]
};

// Adăugare
catalogNote["Vlad"] = [8, 7, 9];

// Accesare sigură cu TryGetValue
if (catalogNote.TryGetValue("Ana", out var noteAna))
{
    double media = noteAna.Average();
    Console.WriteLine($"Ana: note = [{string.Join(", ", noteAna)}], media = {media:F2}");
}

// Verificare existență cheie
Console.WriteLine($"Există 'Elena'? {catalogNote.ContainsKey("Elena")}");

// Parcurgere
Console.WriteLine("\nCatalog complet:");
foreach (var (student, note) in catalogNote)
{
    double media = note.Average();
    Console.WriteLine($"  {student}: [{string.Join(", ", note)}] → media {media:F2}");
}

// Eliminare
catalogNote.Remove("Ion");
Console.WriteLine($"\nDupă eliminare: {catalogNote.Count} studenți");
