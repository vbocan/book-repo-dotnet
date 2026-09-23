// Tablou zimțat: 3 rânduri cu lungimi diferite
int[][] zimtat = new int[3][];
zimtat[0] = [1, 2, 3, 4, 5];
zimtat[1] = [10, 20];
zimtat[2] = [100, 200, 300];

for (int i = 0; i < zimtat.Length; i++)
{
    Console.Write($"Rândul {i} ({zimtat[i].Length} elemente): ");
    for (int j = 0; j < zimtat[i].Length; j++)
    {
        Console.Write($"{zimtat[i][j]} ");
    }
    Console.WriteLine();
}
