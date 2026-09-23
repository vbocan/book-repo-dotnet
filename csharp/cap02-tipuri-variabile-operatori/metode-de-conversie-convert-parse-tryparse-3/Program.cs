Console.Write("Introduceți un număr: ");
string? input = "abc"; // simulăm un input invalid

if (int.TryParse(input, out int rezultat))
{
    Console.WriteLine($"Ați introdus: {rezultat}");
}
else
{
    Console.WriteLine($"'{input}' nu este un număr întreg valid.");
}

// TryParse funcționează pentru toate tipurile numerice
if (double.TryParse("3.14", out double pi))
    Console.WriteLine($"Pi = {pi}");

if (bool.TryParse("true", out bool val))
    Console.WriteLine($"Valoare booleană: {val}");
