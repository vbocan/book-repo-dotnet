var cerc = new Cerc { Raza = 5, Culoare = "Roșu" };
var dreptunghi = new Dreptunghi { Latime = 4, Inaltime = 7, Culoare = "Albastru" };

cerc.AfiseazaInfo();
dreptunghi.AfiseazaInfo();

Console.WriteLine($"Cerc: raza = {cerc.Raza}");
Console.WriteLine($"Dreptunghi: {dreptunghi.Latime} x {dreptunghi.Inaltime}");

class FormaGeometrica
{
    public string Culoare { get; set; } = "Negru";

    public void AfiseazaInfo()
    {
        Console.WriteLine($"Formă geometrică de culoare {Culoare}");
    }
}

class Cerc : FormaGeometrica
{
    public double Raza { get; set; }
}

class Dreptunghi : FormaGeometrica
{
    public double Latime { get; set; }
    public double Inaltime { get; set; }
}
