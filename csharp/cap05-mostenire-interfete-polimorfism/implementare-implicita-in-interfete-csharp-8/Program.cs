ILogger logger = new ConsoleLogger();
logger.Log("Aplicația a pornit.");
logger.LogEroare("Conexiunea la baza de date a eșuat.");
logger.LogAvertisment("Memoria disponibilă este sub 10%.");

interface ILogger
{
    void Log(string mesaj);

    // Metodă cu implementare implicită — adăugată ulterior
    void LogEroare(string mesaj)
    {
        Log($"[EROARE] {mesaj}");
    }

    // Altă metodă cu implementare implicită
    void LogAvertisment(string mesaj)
    {
        Log($"[AVERTISMENT] {mesaj}");
    }
}

class ConsoleLogger : ILogger
{
    // Implementează doar metoda obligatorie
    public void Log(string mesaj)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {mesaj}");
    }

    // LogEroare și LogAvertisment sunt disponibile automat
}
