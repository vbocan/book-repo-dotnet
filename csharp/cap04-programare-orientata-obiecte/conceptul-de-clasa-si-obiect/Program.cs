// Crearea obiectelor (instanțierea clasei)
Masina masina1 = new Masina();
masina1.Marca = "Dacia";
masina1.AnFabricatie = 2023;

Masina masina2 = new Masina();
masina2.Marca = "BMW";
masina2.AnFabricatie = 2021;

masina1.Afiseaza();
masina2.Afiseaza();

class Masina
{
    public string Marca = "Necunoscut";
    public int AnFabricatie;

    public void Afiseaza()
    {
        Console.WriteLine($"{Marca}, fabricată în {AnFabricatie}");
    }
}
