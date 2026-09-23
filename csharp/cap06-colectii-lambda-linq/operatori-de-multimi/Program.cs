int[] setA = [1, 2, 3, 4, 5, 5, 3]; // conține duplicate
int[] setB = [4, 5, 6, 7, 8];

// Distinct — elimină duplicatele
var fărăDuplicate = setA.Distinct();
Console.WriteLine($"A fără duplicate: {string.Join(", ", fărăDuplicate)}");

// Union — reuniune (fără duplicate)
var reuniune = setA.Union(setB);
Console.WriteLine($"A ∪ B: {string.Join(", ", reuniune)}");

// Intersect — intersecție (elemente comune)
var intersectie = setA.Intersect(setB);
Console.WriteLine($"A ∩ B: {string.Join(", ", intersectie)}");

// Except — diferență (elemente din A care nu sunt în B)
var diferenta = setA.Except(setB);
Console.WriteLine($"A \\ B: {string.Join(", ", diferenta)}");

// DistinctBy (.NET 6+)
List<Produs> produse =
[
    new("Laptop", "Electronice"),
    new("Telefon", "Electronice"),
    new("Tricou", "Îmbrăcăminte"),
    new("Pantaloni", "Îmbrăcăminte")
];

var unicePerCategorie = produse.DistinctBy(p => p.Categorie);
Console.WriteLine($"\nUn produs per categorie:");
foreach (var p in unicePerCategorie)
    Console.WriteLine($"  {p.Nume} ({p.Categorie})");

record Produs(string Nume, string Categorie);
