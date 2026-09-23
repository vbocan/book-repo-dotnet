var cont = new ContBancar("Maria Ionescu", 1000m);
cont.Afiseaza();
cont.Depune(500m);

class ContBancar
{
    private string _titular;
    private decimal _sold;

    public ContBancar(string titular, decimal soldInitial)
    {
        _titular = titular;
        _sold = soldInitial;
    }

    public void Depune(decimal suma)
    {
        _sold += suma;
        Console.WriteLine($"Depunere: {suma:F2} RON. Sold nou: {_sold:F2} RON.");
    }

    public void Afiseaza()
    {
        Console.WriteLine($"Titular: {_titular}, Sold: {_sold:F2} RON");
    }
}
