static double Putere(double baza, int exponent)
{
    if (exponent == 0) return 1;
    if (exponent < 0) return 1.0 / Putere(baza, -exponent);
    return baza * Putere(baza, exponent - 1);
}

Console.WriteLine($"2^10 = {Putere(2, 10)}");
Console.WriteLine($"3^0 = {Putere(3, 0)}");
Console.WriteLine($"5^-2 = {Putere(5, -2)}");
