int a = 17, b = 5;

Console.WriteLine($"{a} + {b} = {a + b}");
Console.WriteLine($"{a} - {b} = {a - b}");
Console.WriteLine($"{a} * {b} = {a * b}");
Console.WriteLine($"{a} / {b} = {a / b}");    // împărțire întreagă!
Console.WriteLine($"{a} % {b} = {a % b}");    // restul împărțirii

// Pentru rezultat real, cel puțin un operand trebuie să fie real
Console.WriteLine($"{a} / (double){b} = {a / (double)b}");

// Operatori de incrementare/decrementare
int x = 10;
Console.WriteLine($"x = {x}");
Console.WriteLine($"x++ = {x++}");  // post-increment: returnează 10, apoi x devine 11
Console.WriteLine($"x = {x}");
Console.WriteLine($"++x = {++x}");  // pre-increment: x devine 12, apoi returnează 12
