string salut = "Bună ziua!";
string gol = "";           // șir vid
string? nul = null;        // referință null — NU este un șir vid

Console.WriteLine($"Salut: {salut}");
Console.WriteLine($"Lungime: {salut.Length}");
Console.WriteLine($"Șir vid are lungimea: {gol.Length}");
Console.WriteLine($"Șir vid == \"\": {gol == ""}");
Console.WriteLine($"Șir vid este null: {gol == null}");
