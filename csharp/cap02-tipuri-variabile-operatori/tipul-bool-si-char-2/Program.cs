char litera = 'A';
char cifra = '7';
char emoji = '\u263A';  // ☺ — secvență de escape Unicode
char esc = '\e';        // caracter ESC (C# 13) — echivalent cu '\u001B'

Console.WriteLine($"Litera: {litera}, cod numeric: {(int)litera}");
Console.WriteLine($"Cifra: {cifra}, cod numeric: {(int)cifra}");
Console.WriteLine($"Emoji: {emoji}");
Console.WriteLine($"ESC cod: {(int)esc}");  // 27

// Metode utile din System.Char
Console.WriteLine($"'A' este literă: {char.IsLetter(litera)}");
Console.WriteLine($"'7' este cifră: {char.IsDigit(cifra)}");
Console.WriteLine($"'A' minusculă: {char.ToLower(litera)}");
