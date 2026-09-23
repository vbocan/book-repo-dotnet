string text = """
    Programarea este arta de a instrui un calculator să rezolve probleme.
    Un bun programator nu este cel care scrie mult cod,
    ci cel care scrie cod clar și eficient.
    Programarea este o disciplină care combină logica cu creativitatea.
    """;

// Normalizare: lowercase, eliminare punctuație, split pe spații
string[] cuvinte = text
    .ToLower()
    .Replace(".", "")
    .Replace(",", "")
    .Replace("\n", " ")
    .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

Dictionary<string, int> frecvente = [];

foreach (string cuvant in cuvinte)
{
    if (!frecvente.TryAdd(cuvant, 1))
        frecvente[cuvant]++;
}

// Afișare sortată descrescător după frecvență
Console.WriteLine("Frecvența cuvintelor (sortată descrescător):");
var sortate = frecvente
    .OrderByDescending(kv => kv.Value)
    .ThenBy(kv => kv.Key);

foreach (var (cuvant, count) in sortate)
{
    string bara = new('█', count);
    Console.WriteLine($"  {cuvant,-15} {count} {bara}");
}

Console.WriteLine($"\nCuvinte unice: {frecvente.Count}");
Console.WriteLine($"Total cuvinte: {cuvinte.Length}");
Console.WriteLine($"Cel mai frecvent: \"{frecvente.MaxBy(kv => kv.Value).Key}\"");
