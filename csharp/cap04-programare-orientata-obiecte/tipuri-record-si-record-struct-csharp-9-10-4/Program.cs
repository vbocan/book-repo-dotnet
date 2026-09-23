var laptop = new Produs("Laptop Dell", 4500m) { Categorie = "Electronice" };
Console.WriteLine($"{laptop.Nume}: {laptop.Pret} RON (cu TVA: {laptop.PretCuTVA:F2} RON)");
Console.WriteLine($"Categorie: {laptop.Categorie}");

public record Produs(string Nume, decimal Pret)
{
    public decimal PretCuTVA => Pret * 1.21m; // cota standard de TVA: 21%

    public string Categorie { get; init; } = "General";
}
