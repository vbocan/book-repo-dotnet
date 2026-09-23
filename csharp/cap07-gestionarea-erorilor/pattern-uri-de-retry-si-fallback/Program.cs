static string CitesteConfiguratie(string caleFisier, string valoareImplicita)
{
    try
    {
        return File.ReadAllText(caleFisier).Trim();
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"Configurația '{caleFisier}' nu a fost găsită. " +
                          $"Se folosește valoarea implicită: {valoareImplicita}");
        return valoareImplicita;
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Eroare la citirea configurației: {ex.Message}. " +
                          $"Se folosește valoarea implicită: {valoareImplicita}");
        return valoareImplicita;
    }
}

string conexiune = CitesteConfiguratie("connection.conf", "Server=localhost;Database=TestDB");
Console.WriteLine($"Conexiune: {conexiune}");
