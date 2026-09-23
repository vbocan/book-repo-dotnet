int[] numere = [10, 20, 30, 40, 50, 60, 70, 80];

// Span peste o porțiune din tablou — fără copiere
Span<int> portiune = numere.AsSpan(2, 4); // elementele de la index 2, lungime 4

Console.Write("Porțiune: ");
foreach (int n in portiune)
    Console.Write($"{n} ");
Console.WriteLine();

// Modificarea prin Span modifică tabloul original
portiune[0] = 999;
Console.WriteLine($"numere[2] = {numere[2]}"); // reflectă modificarea
