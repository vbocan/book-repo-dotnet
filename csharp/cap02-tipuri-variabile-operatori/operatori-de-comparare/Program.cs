int x = 10, y = 20;

Console.WriteLine($"{x} == {y}: {x == y}");
Console.WriteLine($"{x} != {y}: {x != y}");
Console.WriteLine($"{x} < {y}: {x < y}");
Console.WriteLine($"{x} > {y}: {x > y}");
Console.WriteLine($"{x} <= {y}: {x <= y}");
Console.WriteLine($"{x} >= 10: {x >= 10}");

// Pentru string, == compară conținutul (nu referința)
string a = "hello";
string b = "HELLO".ToLower();  // șir nou, construit la execuție
Console.WriteLine($"\"{a}\" == \"{b}\": {a == b}");           // True — comparare de conținut
Console.WriteLine($"Același obiect: {ReferenceEquals(a, b)}");  // False — obiecte distincte
