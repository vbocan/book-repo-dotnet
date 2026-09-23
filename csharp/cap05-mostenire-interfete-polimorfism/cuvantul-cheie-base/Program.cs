var cerc = new Cerc(5, "Roșu");
Console.WriteLine(cerc.Descriere());

class FormaGeometrica
{
    public string Culoare { get; set; }

    public FormaGeometrica(string culoare)
    {
        Culoare = culoare;
    }

    public virtual string Descriere()
    {
        return $"Formă de culoare {Culoare}";
    }
}

class Cerc : FormaGeometrica
{
    public double Raza { get; set; }

    public Cerc(double raza, string culoare) : base(culoare)
    {
        Raza = raza;
    }

    public override string Descriere()
    {
        // Apelăm versiunea din clasa de bază și adăugăm informații
        return base.Descriere() + $", cerc cu raza {Raza}";
    }
}
