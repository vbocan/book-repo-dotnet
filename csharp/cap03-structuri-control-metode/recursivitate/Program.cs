static long Factorial(int n)
{
    if (n <= 1) return 1;  // Cazul de bază
    return n * Factorial(n - 1);  // Apelul recursiv
}

for (int i = 0; i <= 10; i++)
{
    Console.WriteLine($"{i}! = {Factorial(i)}");
}
