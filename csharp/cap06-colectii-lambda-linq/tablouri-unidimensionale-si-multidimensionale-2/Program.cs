// Matrice 3×4 (3 rânduri, 4 coloane)
int[,] matrice = new int[3, 4];

// Populare
for (int i = 0; i < 3; i++)
    for (int j = 0; j < 4; j++)
        matrice[i, j] = (i + 1) * 10 + (j + 1);

// Afișare
for (int i = 0; i < matrice.GetLength(0); i++)
{
    for (int j = 0; j < matrice.GetLength(1); j++)
    {
        Console.Write($"{matrice[i, j],4}");
    }
    Console.WriteLine();
}
Console.WriteLine($"Dimensiuni: {matrice.GetLength(0)} x {matrice.GetLength(1)}");
Console.WriteLine($"Total elemente: {matrice.Length}");
