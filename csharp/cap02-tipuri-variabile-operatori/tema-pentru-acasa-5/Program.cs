// Tema 5: Numere prime
bool EstePrim(int n)
{
    if (n < 2) return false;
    if (n == 2) return true;
    if (n % 2 == 0) return false;

    for (int i = 3; i * i <= n; i += 2)
    {
        if (n % i == 0)
            return false;
    }
    return true;
}

// Verificare pentru un număr specific
int numar = 97;
Console.WriteLine($"{numar} este prim: {EstePrim(numar)}");

// Afișarea numerelor prime până la 50
int limita = 50;
Console.Write($"Numere prime până la {limita}: ");
for (int i = 2; i <= limita; i++)
{
    if (EstePrim(i))
        Console.Write($"{i} ");
}
Console.WriteLine();

// Numărarea primelor
int contorPrime = 0;
for (int i = 2; i <= limita; i++)
{
    if (EstePrim(i)) contorPrime++;
}
Console.WriteLine($"Total numere prime până la {limita}: {contorPrime}");
