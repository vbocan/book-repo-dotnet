static double Medie(params double[] valori)
{
    if (valori.Length == 0) return 0;

    double suma = 0;
    foreach (double v in valori)
    {
        suma += v;
    }
    return suma / valori.Length;
}

Console.WriteLine($"Medie(3, 7): {Medie(3, 7):F2}");
Console.WriteLine($"Medie(2, 4, 6, 8, 10): {Medie(2, 4, 6, 8, 10):F2}");
Console.WriteLine($"Medie(100): {Medie(100):F2}");
