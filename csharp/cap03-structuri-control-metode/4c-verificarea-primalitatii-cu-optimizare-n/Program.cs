static bool EstePrim(int n)
{
    if (n < 2) return false;
    if (n == 2) return true;
    if (n % 2 == 0) return false;

    int limita = (int)Math.Sqrt(n);
    for (int i = 3; i <= limita; i += 2)
    {
        if (n % i == 0) return false;
    }
    return true;
}

int[] numereTest = { 1, 2, 3, 4, 17, 18, 19, 97, 100 };
foreach (int n in numereTest)
{
    Console.WriteLine($"EstePrim({n}) = {EstePrim(n)}");
}

// Afișăm numerele prime până la 50
Console.Write("Numere prime până la 50: ");
for (int i = 2; i <= 50; i++)
{
    if (EstePrim(i))
        Console.Write($"{i} ");
}
Console.WriteLine();
