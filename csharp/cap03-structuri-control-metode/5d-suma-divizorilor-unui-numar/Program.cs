static int SumaDivizorilor(int n)
{
    if (n <= 1) return 0;

    int suma = 1; // 1 este întotdeauna divizor propriu

    for (int i = 2; i * i <= n; i++)
    {
        if (n % i == 0)
        {
            suma += i;
            if (i != n / i && n / i != n)
            {
                suma += n / i;
            }
        }
    }

    return suma;
}

Console.WriteLine($"SumaDivizorilor(12) = {SumaDivizorilor(12)}");
Console.WriteLine($"SumaDivizorilor(28) = {SumaDivizorilor(28)}");
Console.WriteLine($"SumaDivizorilor(6) = {SumaDivizorilor(6)}");
Console.WriteLine($"SumaDivizorilor(7) = {SumaDivizorilor(7)}");

// Numerele perfecte sunt cele la care suma divizorilor proprii = numărul însuși
Console.Write("Numere perfecte până la 1000: ");
for (int i = 2; i <= 1000; i++)
{
    if (SumaDivizorilor(i) == i)
        Console.Write($"{i} ");
}
Console.WriteLine();
