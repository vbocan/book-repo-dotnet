int valoare = 42;
object box = valoare;      // boxing: int → object (alocare pe heap)
int valoareExtrasa = (int)box; // unboxing: object → int

Console.WriteLine($"Original: {valoare}");
Console.WriteLine($"Boxed: {box}");
Console.WriteLine($"Unboxed: {valoareExtrasa}");
Console.WriteLine($"Tipul boxed: {box.GetType().Name}");
