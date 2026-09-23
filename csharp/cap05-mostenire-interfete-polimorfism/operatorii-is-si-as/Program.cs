FormaGeometrica forma = new Dreptunghi(5, 5);

// Verificare de tip cu pattern variable
if (forma is Dreptunghi d)
{
    Console.WriteLine($"Dreptunghi: {d.Latime} x {d.Inaltime}");
    Console.WriteLine($"Este pătrat? {d.EstePatrat()}");
}

if (forma is Cerc c)
{
    Console.WriteLine($"Cerc cu raza {c.Raza}");
}
else
{
    Console.WriteLine("Forma nu este un cerc.");
}

abstract class FormaGeometrica
{
    public abstract double CalculeazaAria();
}

class Cerc(double raza) : FormaGeometrica
{
    public double Raza { get; } = raza;
    public override double CalculeazaAria() => Math.PI * Raza * Raza;
}

class Dreptunghi(double latime, double inaltime) : FormaGeometrica
{
    public double Latime { get; } = latime;
    public double Inaltime { get; } = inaltime;
    public override double CalculeazaAria() => Latime * Inaltime;

    public bool EstePatrat() => Latime == Inaltime;
}
