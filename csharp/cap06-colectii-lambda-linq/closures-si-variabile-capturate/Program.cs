int prag = 50;
Func<int, bool> pestePrag = n => n > prag;

Console.WriteLine($"75 > {prag}? {pestePrag(75)}");
Console.WriteLine($"30 > {prag}? {pestePrag(30)}");

// Modificarea variabilei capturate afectează lambda
prag = 80;
Console.WriteLine($"75 > {prag}? {pestePrag(75)}");
