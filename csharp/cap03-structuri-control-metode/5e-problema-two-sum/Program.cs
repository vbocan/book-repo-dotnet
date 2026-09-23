static (int, int) TwoSum(int[] numere, int tinta)
{
    for (int i = 0; i < numere.Length; i++)
    {
        for (int j = i + 1; j < numere.Length; j++)
        {
            if (numere[i] + numere[j] == tinta)
            {
                return (i, j);
            }
        }
    }

    throw new InvalidOperationException("Nu s-a găsit nicio pereche.");
}

int[] date = { 2, 7, 11, 15 };
int tinta = 9;

var (idx1, idx2) = TwoSum(date, tinta);
Console.WriteLine($"Tablou: [{string.Join(", ", date)}]");
Console.WriteLine($"Ținta: {tinta}");
Console.WriteLine($"Indici: ({idx1}, {idx2})");
Console.WriteLine($"Verificare: {date[idx1]} + {date[idx2]} = {date[idx1] + date[idx2]}");

Console.WriteLine();

int[] date2 = { 3, 5, -4, 8, 11, 1, -1, 6 };
int tinta2 = 10;

var (i1, i2) = TwoSum(date2, tinta2);
Console.WriteLine($"Tablou: [{string.Join(", ", date2)}]");
Console.WriteLine($"Ținta: {tinta2}");
Console.WriteLine($"Indici: ({i1}, {i2})");
Console.WriteLine($"Verificare: {date2[i1]} + {date2[i2]} = {date2[i1] + date2[i2]}");
