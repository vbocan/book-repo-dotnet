static void ProceseazaFisier(string caleFisier)
{
    try
    {
        string continut = File.ReadAllText(caleFisier);
        int numar = int.Parse(continut.Trim());
        Console.WriteLine($"Valoare: {numar}");
    }
    catch (Exception ex) when (ex is IOException or FormatException)
    {
        // Înlănțuim excepția originală ca inner exception
        throw new InvalidOperationException(
            $"Nu s-a putut procesa fișierul '{caleFisier}'.", ex);
    }
}

try
{
    ProceseazaFisier("inexistent.txt");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Eroare: {ex.Message}");
    Console.WriteLine($"Cauza: {ex.InnerException?.GetType().Name} — {ex.InnerException?.Message}");
}
