int[] numere = [10, 20, 30];

try
{
    Console.WriteLine(numere[5]); // IndexOutOfRangeException!
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine($"Excepție: {ex.GetType().Name}");
    Console.WriteLine($"Mesaj: {ex.Message}");
    Console.WriteLine($"Tabloul are {numere.Length} elemente (indici 0–{numere.Length - 1})");
}
