string text = "Programare .NET cu C# 14";

// ReadOnlySpan<char> peste un string — fără alocare de substring
ReadOnlySpan<char> primeleCuvinte = text.AsSpan(0, 11);
ReadOnlySpan<char> ultimeleCuvinte = text.AsSpan(16);

Console.WriteLine($"Primele cuvinte: {primeleCuvinte}");
Console.WriteLine($"Ultimele cuvinte: {ultimeleCuvinte}");
