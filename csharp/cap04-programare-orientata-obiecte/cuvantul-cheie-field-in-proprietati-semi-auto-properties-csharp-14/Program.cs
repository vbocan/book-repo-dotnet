// Varianta 3: semi-auto property cu field (C# 14)

var produs = new Produs { Nume = "  Laptop Dell  ", Pret = 4500m };
Console.WriteLine($"Produs: [{produs.Nume}], Preț: {produs.Pret} RON");

try
{
    produs.Pret = -100;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Eroare: {ex.Message}");
}

class Produs
{
    public string Nume
    {
        get => field;
        set => field = value?.Trim()
            ?? throw new ArgumentNullException(nameof(Nume));
    } = "";

    public decimal Pret
    {
        get => field;
        set => field = value >= 0 ? value
            : throw new ArgumentOutOfRangeException(nameof(Pret));
    }
}
