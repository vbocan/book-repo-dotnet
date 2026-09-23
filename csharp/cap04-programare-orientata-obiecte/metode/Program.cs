var cerc = new Cerc { Raza = 5 };
Console.WriteLine(cerc);
Console.WriteLine($"Circumferința: {cerc.Circumferinta():F2}");
cerc.Scala(2);
Console.WriteLine($"După scalare: {cerc}");

class Cerc
{
    public double Raza { get; set; }

    public double Arie() => Math.PI * Raza * Raza;

    public double Circumferinta() => 2 * Math.PI * Raza;

    public void Scala(double factor)
    {
        Raza *= factor;
    }

    public override string ToString() =>
        $"Cerc(raza={Raza:F2}, arie={Arie():F2})";
}
