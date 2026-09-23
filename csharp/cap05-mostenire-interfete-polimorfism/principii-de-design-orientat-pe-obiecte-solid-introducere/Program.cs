// Putem schimba implementarea fără a modifica RaportService
var serviciu = new RaportService(new SqlDatabase());
serviciu.GenereazaRaport("Raport lunar");

var serviciu2 = new RaportService(new FisierDatabase());
serviciu2.GenereazaRaport("Raport anual");

interface IDatabase
{
    void Salveaza(string date);
}

class RaportService(IDatabase db)
{
    public void GenereazaRaport(string continut)
    {
        Console.WriteLine($"Generez raportul: {continut}");
        db.Salveaza(continut);
    }
}

class SqlDatabase : IDatabase
{
    public void Salveaza(string date) => Console.WriteLine($"SQL: salvez \"{date}\"");
}

class FisierDatabase : IDatabase
{
    public void Salveaza(string date) => Console.WriteLine($"Fișier: salvez \"{date}\"");
}
