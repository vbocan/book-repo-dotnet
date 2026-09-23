byte b = 200;
short s = b;      // byte → short: implicit, fără pierdere
int i = s;        // short → int: implicit
long l = i;       // int → long: implicit
float f = l;      // long → float: implicit (dar poate pierde precizie!)
double d = f;     // float → double: implicit

Console.WriteLine($"byte: {b}, short: {s}, int: {i}");
Console.WriteLine($"long: {l}, float: {f}, double: {d}");
