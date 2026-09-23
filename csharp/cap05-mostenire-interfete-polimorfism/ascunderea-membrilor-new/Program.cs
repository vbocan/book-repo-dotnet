Masina masina = new Masina();
masina.Porneste();
masina.Opreste();

Console.WriteLine();

// Aceeași instanță, dar referință de tip Vehicul
Vehicul vehicul = masina;
vehicul.Porneste();
vehicul.Opreste();

class Vehicul
{
    public virtual void Porneste()
    {
        Console.WriteLine("Vehiculul pornește.");
    }

    public void Opreste()
    {
        Console.WriteLine("Vehiculul se oprește.");
    }
}

class Masina : Vehicul
{
    public override void Porneste()
    {
        Console.WriteLine("Mașina pornește motorul cu combustie.");
    }

    // Ascundere (hiding), nu suprascriere
    public new void Opreste()
    {
        Console.WriteLine("Mașina se oprește și activează frâna de mână.");
    }
}
