List<int> numere = [5, 12, 3, 18, 7, 25, 1, 14, 9];

// 1. Metodă numită
static bool MaiMareDe10(int n) => n > 10;
List<int> rezultat1 = numere.FindAll(MaiMareDe10);

// 2. Funcție anonimă (sintaxă delegate — C# 2.0)
List<int> rezultat2 = numere.FindAll(delegate (int n) { return n > 10; });

// 3. Expresie lambda (C# 3.0+)
List<int> rezultat3 = numere.FindAll(n => n > 10);

Console.WriteLine($"Metoda numită: {string.Join(", ", rezultat1)}");
Console.WriteLine($"Funcție anonimă: {string.Join(", ", rezultat2)}");
Console.WriteLine($"Lambda: {string.Join(", ", rezultat3)}");
