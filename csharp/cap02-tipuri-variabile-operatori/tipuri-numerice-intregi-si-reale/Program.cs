// Demonstrarea diferenței de precizie între double și decimal
double a = 0.1 + 0.2;
decimal b = 0.1m + 0.2m;

Console.WriteLine($"double: 0.1 + 0.2 = {a}");
Console.WriteLine($"double == 0.3? {a == 0.3}");
Console.WriteLine($"decimal: 0.1 + 0.2 = {b}");
Console.WriteLine($"decimal == 0.3? {b == 0.3m}");
