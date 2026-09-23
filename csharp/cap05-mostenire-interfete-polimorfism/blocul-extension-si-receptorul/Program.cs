int n = 17;
Console.WriteLine($"{n} este par? {n.EstePar}");
Console.WriteLine($"{n} este prim? {n.EstePrim()}");
Console.WriteLine($"Cifrele lui {n}: [{string.Join(", ", n.Cifre())}]");

Console.WriteLine();

int m = 12345;
Console.WriteLine($"{m} este par? {m.EstePar}");
Console.WriteLine($"{m} este prim? {m.EstePrim()}");
Console.WriteLine($"Cifrele lui {m}: [{string.Join(", ", m.Cifre())}]");

static class IntExtensions
{
    extension(int n)   // membri de instanță — receptor cu nume
    {
        public bool EstePar => n % 2 == 0;

        public bool EstePrim()
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 3; i * i <= n; i += 2)
                if (n % i == 0) return false;
            return true;
        }

        public int[] Cifre()
        {
            if (n == 0) return [0];
            var cifre = new List<int>();
            int rest = Math.Abs(n);
            while (rest > 0)
            {
                cifre.Insert(0, rest % 10);
                rest /= 10;
            }
            return [.. cifre];
        }
    }
}
