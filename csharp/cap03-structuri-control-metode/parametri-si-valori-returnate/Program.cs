static int CalculeazaSuma(int a, int b)
{
    return a + b;
}

static bool InmultesteSiVerifica(int a, int b, out int produs)
{
    produs = a * b;
    return produs > 100;
}

// Testare CalculeazaSuma
int suma = CalculeazaSuma(33, 44);
Console.WriteLine($"CalculeazaSuma(33, 44) = {suma}");

// Testare InmultesteSiVerifica
if (InmultesteSiVerifica(7, 8, out int rezultat1))
{
    Console.WriteLine($"7 × 8 = {rezultat1} (depășește 100)");
}
else
{
    Console.WriteLine($"7 × 8 = {rezultat1} (nu depășește 100)");
}

if (InmultesteSiVerifica(12, 15, out int rezultat2))
{
    Console.WriteLine($"12 × 15 = {rezultat2} (depășește 100)");
}
else
{
    Console.WriteLine($"12 × 15 = {rezultat2} (nu depășește 100)");
}
