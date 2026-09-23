static long Factorial(int n)
{
    if (n < 0)
        throw new ArgumentException("Factorialul nu este definit pentru numere negative.");
    if (n <= 1) return 1;
    return n * Factorial(n - 1);
}

Console.WriteLine($"Factorial(0) = {Factorial(0)}");
Console.WriteLine($"Factorial(5) = {Factorial(5)}");
Console.WriteLine($"Factorial(10) = {Factorial(10)}");
Console.WriteLine($"Factorial(20) = {Factorial(20)}");
