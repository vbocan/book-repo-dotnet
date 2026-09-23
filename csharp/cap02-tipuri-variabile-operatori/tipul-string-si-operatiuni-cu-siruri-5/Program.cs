string text = "  Programare .NET la UPT  ";

Console.WriteLine($"Original: '{text}'");
Console.WriteLine($"Trim: '{text.Trim()}'");
Console.WriteLine($"ToUpper: '{text.Trim().ToUpper()}'");
Console.WriteLine($"ToLower: '{text.Trim().ToLower()}'");
Console.WriteLine($"Conține '.NET': {text.Contains(".NET")}");
Console.WriteLine($"Începe cu '  Pro': {text.StartsWith("  Pro")}");
Console.WriteLine($"IndexOf('UPT'): {text.IndexOf("UPT")}");
Console.WriteLine($"Replace: '{text.Trim().Replace("UPT", "Politehnica")}'");
Console.WriteLine($"Substring(2, 11): '{text.Substring(2, 11)}'");

// Split — despărțirea unui șir în componente
string csv = "Ion,Maria,Andrei,Elena";
string[] nume = csv.Split(',');
Console.WriteLine($"Număr de nume: {nume.Length}");
foreach (string n in nume)
    Console.WriteLine($"  - {n}");
