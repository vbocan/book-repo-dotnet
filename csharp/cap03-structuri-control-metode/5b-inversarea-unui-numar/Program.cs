static int InverseazaNumar(int numar)
{
    int rezultat = 0;

    while (numar > 0)
    {
        int cifra = numar % 10;
        rezultat = rezultat * 10 + cifra;
        numar /= 10;
    }

    return rezultat;
}

Console.WriteLine($"InverseazaNumar(123) = {InverseazaNumar(123)}");
Console.WriteLine($"InverseazaNumar(9876) = {InverseazaNumar(9876)}");
Console.WriteLine($"InverseazaNumar(1000) = {InverseazaNumar(1000)}");
Console.WriteLine($"InverseazaNumar(5) = {InverseazaNumar(5)}");
