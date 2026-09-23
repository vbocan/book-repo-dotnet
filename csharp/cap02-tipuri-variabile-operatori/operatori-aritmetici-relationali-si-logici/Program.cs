// Exercițiul 2: Operatori
int a = 15, b = 4;

// Operatori aritmetici
Console.WriteLine("=== Operatori aritmetici ===");
Console.WriteLine($"{a} + {b} = {a + b}");
Console.WriteLine($"{a} - {b} = {a - b}");
Console.WriteLine($"{a} * {b} = {a * b}");
Console.WriteLine($"{a} / {b} = {a / b} (împărțire întreagă)");
Console.WriteLine($"{a} / (double){b} = {a / (double)b:F2} (împărțire reală)");
Console.WriteLine($"{a} % {b} = {a % b}");

// Operatori relaționali
Console.WriteLine("\n=== Operatori relaționali ===");
Console.WriteLine($"{a} == {b}: {a == b}");
Console.WriteLine($"{a} != {b}: {a != b}");
Console.WriteLine($"{a} > {b}: {a > b}");
Console.WriteLine($"{a} < {b}: {a < b}");
Console.WriteLine($"{a} >= 15: {a >= 15}");
Console.WriteLine($"{a} <= 15: {a <= 15}");

// Operatori logici
Console.WriteLine("\n=== Operatori logici ===");
bool x = true, y = false;
Console.WriteLine($"{x} && {y} = {x && y}");
Console.WriteLine($"{x} || {y} = {x || y}");
Console.WriteLine($"!{x} = {!x}");
Console.WriteLine($"!{y} = {!y}");
