int n = int.Parse("123");
double d = double.Parse("45.67");

Console.WriteLine($"int.Parse: {n}");
Console.WriteLine($"double.Parse: {d}");

// Dacă șirul nu e valid, Parse aruncă FormatException
try
{
    int invalid = int.Parse("abc");
}
catch (FormatException)
{
    Console.WriteLine("Eroare: 'abc' nu este un număr valid.");
}
