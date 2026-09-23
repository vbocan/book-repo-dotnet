static double CalculeazaAriaCerc(double raza)
{
    return Math.PI * raza * raza;
}

double raza = 5.0;
double aria = CalculeazaAriaCerc(raza);
Console.WriteLine($"Aria cercului cu raza {raza}: {aria:F2}");
