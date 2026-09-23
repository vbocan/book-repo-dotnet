Console.WriteLine($"Versiune: {Configuratie.VersiuneAplicatie}");
Console.WriteLine($"Pornit la: {Configuratie.DataPornire:HH:mm:ss}");

class Configuratie
{
    public static string VersiuneAplicatie { get; private set; }
    public static DateTime DataPornire { get; private set; }

    static Configuratie()
    {
        VersiuneAplicatie = "1.0.0";
        DataPornire = DateTime.Now;
        Console.WriteLine("Configurația a fost inițializată.");
    }
}
