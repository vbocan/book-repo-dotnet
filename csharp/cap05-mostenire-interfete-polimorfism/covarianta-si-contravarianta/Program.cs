static void AfiseazaForme(IEnumerable<FormaGeometrica> forme)
{
    foreach (var f in forme)
    {
        Console.WriteLine($"  {f} — aria: {f.CalculeazaAria():F2}");
    }
}

List<Cerc> cercuri = [new Cerc(3), new Cerc(5)];

// Covarianță: List<Cerc> → IEnumerable<FormaGeometrica>
Console.WriteLine("Cercuri afișate ca forme:");
AfiseazaForme(cercuri);

abstract class FormaGeometrica
{
    public abstract double CalculeazaAria();
}

class Cerc(double raza) : FormaGeometrica
{
    public double Raza { get; } = raza;
    public override double CalculeazaAria() => Math.PI * Raza * Raza;
    public override string ToString() => $"Cerc(r={Raza})";
}

class Dreptunghi(double l, double h) : FormaGeometrica
{
    public override double CalculeazaAria() => l * h;
    public override string ToString() => $"Dreptunghi({l}×{h})";
}
