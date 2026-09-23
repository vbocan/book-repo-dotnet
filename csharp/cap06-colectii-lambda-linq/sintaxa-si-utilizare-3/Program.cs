List<string> orase = ["București", "Timișoara", "Cluj-Napoca", "Iași",
                       "Constanța", "Brașov", "Oradea", "Sibiu"];

// Sortare după lungimea numelui
orase.Sort((a, b) => a.Length.CompareTo(b.Length));
Console.WriteLine($"Sortate după lungime: {string.Join(", ", orase)}");

// Găsirea primului oraș care începe cu 'C'
string? primulCuC = orase.Find(o => o.StartsWith('C'));
Console.WriteLine($"Primul cu 'C': {primulCuC}");

// Filtrarea orașelor cu mai mult de 7 caractere
List<string> lungi = orase.FindAll(o => o.Length > 7);
Console.WriteLine($"Peste 7 caractere: {string.Join(", ", lungi)}");
