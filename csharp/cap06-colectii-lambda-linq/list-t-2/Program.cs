List<int> numere = [15, 3, 28, 7, 42, 11, 36, 5, 19, 50];

// Find — primul element care satisface condiția
int primulPeste20 = numere.Find(n => n > 20);
Console.WriteLine($"Primul peste 20: {primulPeste20}");

// FindAll — toate elementele care satisfac condiția
List<int> pare = numere.FindAll(n => n % 2 == 0);
Console.WriteLine($"Numere pare: {string.Join(", ", pare)}");

// FindIndex — indexul primului element
int indexPrim = numere.FindIndex(n => n > 30);
Console.WriteLine($"Indexul primului element > 30: {indexPrim}");

// Exists — verifică dacă există cel puțin un element
bool existaNegativ = numere.Exists(n => n < 0);
Console.WriteLine($"Există numere negative? {existaNegativ}");

// RemoveAll — elimină toate elementele care satisfac condiția
int eliminate = numere.RemoveAll(n => n < 10);
Console.WriteLine($"Eliminate {eliminate} elemente sub 10.");
Console.WriteLine($"Rămase: {string.Join(", ", numere)}");
