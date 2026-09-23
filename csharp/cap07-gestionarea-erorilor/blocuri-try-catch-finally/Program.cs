try
{
    string continut = File.ReadAllText("config.txt");
    int valoare = int.Parse(continut.Trim());
    Console.WriteLine($"Valoarea citită: {valoare}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Fișierul nu a fost găsit: {ex.FileName}");
}
catch (FormatException ex)
{
    Console.WriteLine($"Conținutul nu este un număr valid: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"Eroare la citirea fișierului: {ex.Message}");
}
finally
{
    Console.WriteLine("Operație de citire finalizată.");
}
