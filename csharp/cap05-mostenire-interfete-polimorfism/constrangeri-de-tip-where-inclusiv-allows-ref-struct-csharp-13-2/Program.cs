// Parametrul de tip T poate fi un ref struct datorită lui allows ref struct
static T Primul<T>(T valoare) where T : allows ref struct => valoare;

Span<int> numere = [10, 20, 30];
Span<int> rezultat = Primul(numere);   // T = Span<int> — un ref struct
Console.WriteLine($"Primul element: {rezultat[0]}, lungime: {rezultat.Length}");

ReadOnlySpan<char> text = "F#".AsSpan();
var copie = Primul(text);              // T = ReadOnlySpan<char>
Console.WriteLine($"Text: {copie.ToString()}");
