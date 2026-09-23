string[] limbaje = ["C#", "F#", "Python", "Rust", "Go", "Java"];

string[] primele3 = limbaje[..3];       // indexul 0, 1, 2
string[] de_la_2 = limbaje[2..];        // indexul 2, 3, 4, 5
string[] mijloc = limbaje[1..^1];       // indexul 1, 2, 3, 4
string[] ultimele2 = limbaje[^2..];     // indexul 4, 5

Console.WriteLine($"Primele 3: {string.Join(", ", primele3)}");
Console.WriteLine($"De la index 2: {string.Join(", ", de_la_2)}");
Console.WriteLine($"Fără primul și ultimul: {string.Join(", ", mijloc)}");
Console.WriteLine($"Ultimele 2: {string.Join(", ", ultimele2)}");
