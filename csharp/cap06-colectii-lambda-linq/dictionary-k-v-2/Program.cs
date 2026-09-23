string text = "ana are ana are mere și pere și mere";
string[] cuvinte = text.Split(' ');

Dictionary<string, int> frecvente = [];

foreach (string cuvant in cuvinte)
{
    if (frecvente.ContainsKey(cuvant))
        frecvente[cuvant]++;
    else
        frecvente[cuvant] = 1;
}

Console.WriteLine("Frecvența cuvintelor:");
foreach (var (cuvant, count) in frecvente)
{
    Console.WriteLine($"  \"{cuvant}\": {count}");
}
