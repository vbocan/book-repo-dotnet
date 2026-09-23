bool a = true, b = false;

Console.WriteLine($"true && false = {a && b}");   // AND logic
Console.WriteLine($"true || false = {a || b}");   // OR logic
Console.WriteLine($"!true = {!a}");               // NOT logic

// Evaluarea scurtcircuitată (short-circuit)
int x = 0;
// Dacă prima condiție e false, a doua nu se evaluează
bool rezultat = (x != 0) && (100 / x > 5);
Console.WriteLine($"Scurtcircuit evită împărțirea la zero: {rezultat}");

// Exemplu practic: validarea unui input
string? input = "42";
if (input != null && input.Length > 0 && int.TryParse(input, out int val))
{
    Console.WriteLine($"Input valid: {val}");
}
