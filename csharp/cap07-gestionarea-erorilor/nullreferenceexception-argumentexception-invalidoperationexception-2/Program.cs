static double CalculeazaRadical(double numar)
{
    if (numar < 0)
        throw new ArgumentOutOfRangeException(
            nameof(numar),
            numar,
            "Numărul trebuie să fie pozitiv sau zero.");

    return Math.Sqrt(numar);
}

try
{
    Console.WriteLine(CalculeazaRadical(25));
    Console.WriteLine(CalculeazaRadical(-4));
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Excepție: {ex.GetType().Name}");
    Console.WriteLine($"Parametru: {ex.ParamName}");
    Console.WriteLine($"Valoare: {ex.ActualValue}");
    Console.WriteLine($"Mesaj: {ex.Message}");
}
