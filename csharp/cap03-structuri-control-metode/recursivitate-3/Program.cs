static long FibonacciIterativ(int n)
{
    if (n <= 0) return 0;
    if (n == 1) return 1;

    long prev = 0, curr = 1;
    for (int i = 2; i <= n; i++)
    {
        long temp = curr;
        curr = prev + curr;
        prev = temp;
    }
    return curr;
}

Console.WriteLine($"Fibonacci(50) = {FibonacciIterativ(50)}");
