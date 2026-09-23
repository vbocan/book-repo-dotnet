string[] caiDeFisier = [
    "raport.txt",
    "/cale/inexistenta/fisier.dat",
    "date_importante.csv"
];

foreach (string cale in caiDeFisier)
{
    try
    {
        string continut = File.ReadAllText(cale);
        Console.WriteLine($"{cale}: {continut.Length} caractere citite");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"{cale}: fișierul nu există");
    }
    catch (DirectoryNotFoundException)
    {
        Console.WriteLine($"{cale}: directorul nu există");
    }
    catch (IOException ex)
    {
        Console.WriteLine($"{cale}: eroare I/O — {ex.Message}");
    }
}
