// Capitolul 4 - Programare orientată pe obiecte în C#
// Exercițiul 5a - Cont bancar cu tranzacții (temă de casă)
//
// Clasa ContBancar păstrează într-o listă internă istoricul tranzacțiilor;
// soldul poate fi modificat doar prin Depune() și Retrage().
//
// Rulare: dotnet run --project csharp/cap04-programare-orientata-obiecte/5a-cont-bancar-cu-tranzactii

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var cont = new ContBancar("Maria Ionescu", 1000m);
cont.Depune(500m);
cont.Retrage(200m);
cont.Retrage(2000m);   // respinsă: sold insuficient
cont.Depune(300m);
cont.AfiseazaIstoric();

class ContBancar
{
    private readonly List<string> _istoric = [];

    public string Titular { get; }
    public decimal Sold { get; private set; }

    public ContBancar(string titular, decimal soldInitial)
    {
        if (soldInitial < 0)
            throw new ArgumentOutOfRangeException(nameof(soldInitial));
        Titular = titular;
        Sold = soldInitial;
        _istoric.Add($"Deschidere cont: {Sold:F2} RON");
    }

    public void Depune(decimal suma)
    {
        if (suma <= 0)
            throw new ArgumentOutOfRangeException(nameof(suma), "Suma trebuie să fie pozitivă.");
        Sold += suma;
        _istoric.Add($"Depunere: +{suma:F2} RON → Sold: {Sold:F2} RON");
    }

    // Returnează false (și consemnează respingerea) dacă soldul nu ajunge
    public bool Retrage(decimal suma)
    {
        if (suma <= 0)
            throw new ArgumentOutOfRangeException(nameof(suma), "Suma trebuie să fie pozitivă.");
        if (suma > Sold)
        {
            _istoric.Add($"Retragere respinsă: {suma:F2} RON (sold insuficient)");
            return false;
        }
        Sold -= suma;
        _istoric.Add($"Retragere: -{suma:F2} RON → Sold: {Sold:F2} RON");
        return true;
    }

    public void AfiseazaIstoric()
    {
        Console.WriteLine($"Istoric cont — {Titular}:");
        foreach (var tranzactie in _istoric)
        {
            Console.WriteLine($"  {tranzactie}");
        }
        Console.WriteLine($"  Sold curent: {Sold:F2} RON");
    }
}
