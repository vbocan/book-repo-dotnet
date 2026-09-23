// Tema 1: Maximul a trei numere
int a = 14, b = 27, c = 19;

int max = (a > b) ? ((a > c) ? a : c) : ((b > c) ? b : c);
Console.WriteLine($"Numerele: {a}, {b}, {c}");
Console.WriteLine($"Maximul: {max}");
