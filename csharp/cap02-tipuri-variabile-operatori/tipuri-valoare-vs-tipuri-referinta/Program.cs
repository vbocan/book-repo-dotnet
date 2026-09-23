// --- Tipuri valoare: copierea creează valori independente ---
int x = 10;
int y = x;     // y primește o COPIE a lui x
y = 99;        // modificarea lui y NU afectează x

Console.WriteLine($"Tip valoare:");
Console.WriteLine($"  x = {x}");  // 10
Console.WriteLine($"  y = {y}");  // 99
Console.WriteLine();

// --- Tipuri referință: copierea copiază referința ---
int[] arr1 = { 1, 2, 3 };
int[] arr2 = arr1;    // arr2 referă ACELAȘI tablou
arr2[0] = 99;         // modificarea prin arr2 AFECTEAZĂ arr1

Console.WriteLine($"Tip referință:");
Console.WriteLine($"  arr1[0] = {arr1[0]}");  // 99!
Console.WriteLine($"  arr2[0] = {arr2[0]}");  // 99
Console.WriteLine($"  Sunt același obiect: {ReferenceEquals(arr1, arr2)}");
