// Exercițiul 4: Conversii
Console.WriteLine("=== Conversii implicite ===");
int intreg = 42;
double real = intreg;  // implicit
Console.WriteLine($"int {intreg} → double {real}");

Console.WriteLine("\n=== Conversii explicite (cast) ===");
double valoare = 9.78;
int trunchiat = (int)valoare;
Console.WriteLine($"double {valoare} → int {trunchiat} (trunchiere)");

Console.WriteLine("\n=== Conversii cu TryParse ===");
string[] inputuri = { "42", "3.14", "abc", "", "2147483648" };
foreach (string input in inputuri)
{
    if (int.TryParse(input, out int rez))
        Console.WriteLine($"  \"{input}\" → int {rez}");
    else
        Console.WriteLine($"  \"{input}\" → conversie eșuată");
}
