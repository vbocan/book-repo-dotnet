// Func — funcție care returnează o valoare
Func<double, double, double> calcul = (a, b) => a * a + b * b;
Console.WriteLine($"3² + 4² = {calcul(3, 4)}");

Func<string, int> lungime = s => s.Length;
Console.WriteLine($"Lungimea 'programare': {lungime("programare")}");

// Action — funcție fără valoare de retur
Action<string, int> afiseazaRepetitiv = (text, n) =>
{
    for (int i = 0; i < n; i++)
        Console.Write(text);
    Console.WriteLine();
};
afiseazaRepetitiv("*", 10);

// Predicate — funcție care returnează bool
Predicate<int> estePar = n => n % 2 == 0;
Console.WriteLine($"4 este par? {estePar(4)}");
Console.WriteLine($"7 este par? {estePar(7)}");
