static void GasesteMinMax(int[] numere, out int minim, out int maxim)
{
    if (numere.Length == 0)
        throw new ArgumentException("Tabloul nu poate fi gol.");

    minim = numere[0];
    maxim = numere[0];

    for (int i = 1; i < numere.Length; i++)
    {
        if (numere[i] < minim) minim = numere[i];
        if (numere[i] > maxim) maxim = numere[i];
    }
}

int[] date = { 34, -7, 12, 89, 0, -23, 56, 3 };

GasesteMinMax(date, out int min, out int max);

Console.Write("Tablou: ");
foreach (int n in date) Console.Write($"{n} ");
Console.WriteLine();
Console.WriteLine($"Minim: {min}");
Console.WriteLine($"Maxim: {max}");
