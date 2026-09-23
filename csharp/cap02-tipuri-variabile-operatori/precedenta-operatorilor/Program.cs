int a = 2, b = 3, c = 4;

// Fără paranteze — se aplică precedența
int r1 = a + b * c;        // b * c se evaluează primul
Console.WriteLine($"a + b * c = {r1}");    // 2 + 12 = 14

// Cu paranteze — ordine explicită
int r2 = (a + b) * c;
Console.WriteLine($"(a + b) * c = {r2}");  // 5 * 4 = 20

// Operatorul condițional (ternar)
int max = (a > b) ? a : b;
Console.WriteLine($"max({a}, {b}) = {max}");
