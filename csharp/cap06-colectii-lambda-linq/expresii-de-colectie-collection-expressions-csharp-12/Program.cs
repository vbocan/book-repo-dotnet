// Sintaxa unificată — compilatorul deduce tipul colecției
int[] tablou = [1, 2, 3, 4, 5];
List<int> lista = [10, 20, 30];
HashSet<string> limbaje = ["C#", "F#", "Python"];
Span<double> valori = [1.5, 2.7, 3.14];

Console.WriteLine($"Tablou: {string.Join(", ", tablou)}");
Console.WriteLine($"Lista: {string.Join(", ", lista)}");
Console.WriteLine($"Set: {string.Join(", ", limbaje)}");
