// Sintaxa delegate (C# 2.0)
Func<int, int, int> sumaVeche = delegate (int a, int b)
{
    return a + b;
};

// Sintaxa lambda echivalentă (C# 3.0+)
Func<int, int, int> sumaNoua = (a, b) => a + b;

Console.WriteLine($"Delegate: {sumaVeche(3, 4)}");
Console.WriteLine($"Lambda: {sumaNoua(3, 4)}");
