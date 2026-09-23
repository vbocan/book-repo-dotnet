var nota = new Nota("Programare .NET", 9.5, new DateTime(2025, 6, 15));

var (disciplina, valoare, _) = nota; // _ ignoră data
Console.WriteLine($"{disciplina}: {valoare}");

public record Nota(string Disciplina, double Valoare, DateTime Data);
