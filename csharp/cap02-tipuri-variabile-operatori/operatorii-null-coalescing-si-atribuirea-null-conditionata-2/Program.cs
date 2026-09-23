List<int>? numere = null;

// Inițializează lista doar dacă e null
numere ??= new List<int>();
numere.Add(1);
numere.Add(2);

// A doua apelare nu suprascrie lista existentă
numere ??= new List<int>();  // nu face nimic, numere nu e null
numere.Add(3);

Console.WriteLine($"Elemente: {string.Join(", ", numere)}");
