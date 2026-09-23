int a = 0b_1100;  // 12 în binar
int b = 0b_1010;  // 10 în binar

Console.WriteLine($"a = {Convert.ToString(a, 2).PadLeft(4, '0')} ({a})");
Console.WriteLine($"b = {Convert.ToString(b, 2).PadLeft(4, '0')} ({b})");
Console.WriteLine();

// AND pe biți: 1 doar unde ambii au 1
int andResult = a & b;
Console.WriteLine($"a & b  = {Convert.ToString(andResult, 2).PadLeft(4, '0')} ({andResult})");

// OR pe biți: 1 unde cel puțin unul are 1
int orResult = a | b;
Console.WriteLine($"a | b  = {Convert.ToString(orResult, 2).PadLeft(4, '0')} ({orResult})");

// XOR pe biți: 1 unde exact unul are 1
int xorResult = a ^ b;
Console.WriteLine($"a ^ b  = {Convert.ToString(xorResult, 2).PadLeft(4, '0')} ({xorResult})");

// NOT pe biți: inversează toți biții
Console.WriteLine($"~a     = {~a}");

// Deplasare la stânga și la dreapta
Console.WriteLine($"a << 2 = {Convert.ToString(a << 2, 2).PadLeft(8, '0')} ({a << 2})");
Console.WriteLine($"a >> 1 = {Convert.ToString(a >> 1, 2).PadLeft(4, '0')} ({a >> 1})");
