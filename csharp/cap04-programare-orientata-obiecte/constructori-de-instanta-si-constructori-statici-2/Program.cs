Console.WriteLine(new Vehicul());
Console.WriteLine(new Vehicul("Dacia", "Duster"));
Console.WriteLine(new Vehicul("Tesla", "Model 3", 2024));

class Vehicul
{
    public string Marca { get; set; }
    public string Model { get; set; }
    public int An { get; set; }

    public Vehicul() : this("Necunoscut", "Necunoscut", 2000)
    {
    }

    public Vehicul(string marca, string model) : this(marca, model, DateTime.Now.Year)
    {
    }

    public Vehicul(string marca, string model, int an)
    {
        Marca = marca;
        Model = model;
        An = an;
    }

    public override string ToString() => $"{Marca} {Model} ({An})";
}
