List<int> note = [10, 8, 9, 7, 10, 6, 8, 9, 5, 10];

Console.WriteLine($"Count: {note.Count}");
Console.WriteLine($"Sum: {note.Sum()}");
Console.WriteLine($"Average: {note.Average():F2}");
Console.WriteLine($"Min: {note.Min()}");
Console.WriteLine($"Max: {note.Max()}");

// Aggregate — operație personalizată de reducere
string concatenate = note
    .Select(n => n.ToString())
    .Aggregate((acumulator, element) => acumulator + ", " + element);
Console.WriteLine($"Concatenate: {concatenate}");

// Numărare condiționată
int noteMari = note.Count(n => n >= 9);
Console.WriteLine($"Note ≥ 9: {noteMari}");
