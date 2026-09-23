var registru = new Registru<Produs>();
registru.Adauga(new Produs { Id = 1, Nume = "Laptop", Pret = 4500 });
registru.Adauga(new Produs { Id = 2, Nume = "Mouse", Pret = 120 });
registru.Adauga(new Produs { Id = 3, Nume = "Tastatură", Pret = 250 });

var produs = registru.GasesteDupaId(2);
Console.WriteLine($"Găsit: {produs}");
Console.WriteLine($"Total produse: {registru.Count}");

interface IEntitate
{
    int Id { get; }
}

class Registru<T> where T : class, IEntitate, new()
{
    private readonly List<T> _entitati = [];

    public void Adauga(T entitate)
    {
        _entitati.Add(entitate);
    }

    public T? GasesteDupaId(int id)
    {
        return _entitati.Find(e => e.Id == id);
    }

    public int Count => _entitati.Count;
}

class Produs : IEntitate
{
    public int Id { get; set; }
    public string Nume { get; set; } = "";
    public decimal Pret { get; set; }

    public override string ToString() => $"[{Id}] {Nume}: {Pret:N2} RON";
}
