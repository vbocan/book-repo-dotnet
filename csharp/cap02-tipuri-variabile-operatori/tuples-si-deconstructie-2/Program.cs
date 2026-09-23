// Metodă care returnează un tuplu cu nume
(double Min, double Max, double Medie) CalculeazaStatistici(int[] numere)
{
    double min = numere[0], max = numere[0], suma = 0;
    foreach (int n in numere)
    {
        if (n < min) min = n;
        if (n > max) max = n;
        suma += n;
    }
    return (min, max, suma / numere.Length);
}

int[] date = { 7, 3, 9, 1, 5, 8, 2, 6, 4 };
var stat = CalculeazaStatistici(date);
Console.WriteLine($"Min: {stat.Min}, Max: {stat.Max}, Medie: {stat.Medie:F2}");
