List<int> numere = [1, 2, 3, 4, 5];

// Interogarea NU se execută aici — doar se definește
var pare = numere.Where(n => n % 2 == 0);

// Modificăm sursa ÎNAINTE de iterare
numere.Add(6);
numere.Add(8);

// Interogarea se execută ACUM, reflectând modificările
Console.WriteLine($"Numere pare: {string.Join(", ", pare)}");
