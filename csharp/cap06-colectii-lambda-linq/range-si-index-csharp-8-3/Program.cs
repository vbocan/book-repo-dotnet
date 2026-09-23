string mesaj = "Programare .NET";
string primele4 = mesaj[..4];
string ultimele3 = mesaj[^3..];

Console.WriteLine($"Primele 4 caractere: {primele4}");
Console.WriteLine($"Ultimele 3 caractere: {ultimele3}");
