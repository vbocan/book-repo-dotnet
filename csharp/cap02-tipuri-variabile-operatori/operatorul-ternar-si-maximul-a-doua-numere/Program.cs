// Exercițiul 3: Operatorul ternar
int m = 17, n = 23;

int maxim = (m > n) ? m : n;
int minim = (m < n) ? m : n;

Console.WriteLine($"m = {m}, n = {n}");
Console.WriteLine($"Maximul: {maxim}");
Console.WriteLine($"Minimul: {minim}");

// Verificare paritate cu operatorul ternar
int numar = 42;
string paritate = (numar % 2 == 0) ? "par" : "impar";
Console.WriteLine($"{numar} este {paritate}");
