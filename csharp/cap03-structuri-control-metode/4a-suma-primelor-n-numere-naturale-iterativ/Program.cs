static long SumaNumere(int n)
{
    long suma = 0;
    for (int i = 1; i <= n; i++)
    {
        suma += i;
    }
    return suma;
}

Console.WriteLine($"SumaNumere(10) = {SumaNumere(10)}");
Console.WriteLine($"SumaNumere(100) = {SumaNumere(100)}");
Console.WriteLine($"SumaNumere(1000) = {SumaNumere(1000)}");
