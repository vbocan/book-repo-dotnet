// Capitolul 5 - Moștenire, interfețe și polimorfism
// Exercițiul 5 - Ierarhie de vehicule (temă de casă)
//
// Ierarhia Vehicul -> Automobil, Motocicleta, Camion, cu interfețele
// ITransport și IAsigurabil și record-uri pentru specificații.
// Principii SOLID aplicate:
//   SRP - fiecare tip are o singură responsabilitate (record-urile descriu
//         specificațiile, clasele modelează vehiculele, funcțiile locale
//         AfiseazaInfoAsigurare / AfiseazaInfoTransport se ocupă de afișare);
//   ISP - ITransport și IAsigurabil sunt separate: Motocicleta implementează
//         doar IAsigurabil;
//   DIP - funcțiile de afișare depind de interfețe, nu de tipuri concrete.
//   (OCP și LSP sunt respectate de asemenea: un vehicul nou se adaugă printr-o
//   clasă nouă, iar bucla principală lucrează doar cu tipul de bază.)
//
// Regulile de calcul al primei (ilustrative):
//   Automobil:   800 RON + 2.5 RON/CP;       risc A sub 100 CP, B sub 200 CP, altfel C
//   Motocicletă: 500 RON + 3 RON/CP, plus 100 RON pentru categoria Sport;
//                risc C pentru Sport, altfel B
//   Camion:      1100 RON + 50 RON pe tona de sarcină utilă; risc C
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/ierarhie-de-vehicule-tema-de-casa

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

List<Vehicul> flota =
[
    new Automobil(new SpecificatiiVehicul("Toyota", "Corolla", 2022),
                  new SpecificatiiMotor(140, "Hybrid"), locuri: 5, capacitateKg: 450),
    new Motocicleta(new SpecificatiiVehicul("Yamaha", "MT-07", 2023),
                    new SpecificatiiMotor(73, "Benzină"), categorie: "Sport"),
    new Camion(new SpecificatiiVehicul("Mercedes", "Actros", 2020),
               new SpecificatiiMotor(530, "Diesel"), locuri: 2, sarcinaUtilaKg: 18000),
    new Automobil(new SpecificatiiVehicul("Dacia", "Sandero", 2024),
                  new SpecificatiiMotor(90, "GPL"), locuri: 5, capacitateKg: 400)
];

Console.WriteLine("=== Flota de vehicule ===");
Console.WriteLine();

decimal totalPrime = 0;
foreach (var vehicul in flota)
{
    Console.WriteLine(vehicul.Descriere());

    if (vehicul is IAsigurabil asigurabil)
    {
        AfiseazaInfoAsigurare(asigurabil);
        totalPrime += asigurabil.CalculeazaPrima();
    }

    if (vehicul is ITransport transport)
    {
        AfiseazaInfoTransport(transport);
    }

    Console.WriteLine();
}

Console.WriteLine($"Total prime asigurare: {totalPrime:N2} RON");

// DIP: funcțiile de afișare cunosc doar abstracțiunile
static void AfiseazaInfoAsigurare(IAsigurabil a)
{
    Console.WriteLine($"  Prima asigurare: {a.CalculeazaPrima():N2} RON");
    string descriere = a.CategorieRisc switch
    {
        CategorieRisc.A => "risc scăzut",
        CategorieRisc.B => "risc mediu",
        CategorieRisc.C => "risc ridicat",
        _ => "necunoscut"
    };
    Console.WriteLine($"  Categorie risc: {a.CategorieRisc} ({descriere})");
}

static void AfiseazaInfoTransport(ITransport t)
{
    Console.WriteLine($"  Transport: {t.DescriereTransport}");
}

// Record-uri pentru specificații: date imutabile, egalitate după valoare
record SpecificatiiVehicul(string Marca, string Model, int AnFabricatie);
record SpecificatiiMotor(int CaiPutere, string Combustibil);

enum CategorieRisc { A, B, C }

// ISP: două interfețe mici, focalizate
interface ITransport
{
    int NumarLocuri { get; }
    string DescriereTransport { get; }
}

interface IAsigurabil
{
    decimal CalculeazaPrima();
    CategorieRisc CategorieRisc { get; }
}

abstract class Vehicul(SpecificatiiVehicul specificatii, SpecificatiiMotor motor)
{
    public SpecificatiiVehicul Specificatii { get; } = specificatii;
    public SpecificatiiMotor Motor { get; } = motor;

    // Fiecare tip concret își spune numele afișat
    public abstract string Tip { get; }

    public virtual string Descriere() =>
        $"{Tip}: {Specificatii.Marca} {Specificatii.Model} ({Specificatii.AnFabricatie}), " +
        $"{Motor.CaiPutere} CP, {Motor.Combustibil}";
}

class Automobil(SpecificatiiVehicul specificatii, SpecificatiiMotor motor, int locuri, int capacitateKg)
    : Vehicul(specificatii, motor), ITransport, IAsigurabil
{
    public int NumarLocuri { get; } = locuri;
    public int CapacitateKg { get; } = capacitateKg;

    public override string Tip => "Automobil";

    public string DescriereTransport => $"{NumarLocuri} locuri, capacitate {CapacitateKg} kg";

    public override string Descriere() => $"{base.Descriere()}, {DescriereTransport}";

    public decimal CalculeazaPrima() => 800m + 2.5m * Motor.CaiPutere;

    public CategorieRisc CategorieRisc => Motor.CaiPutere switch
    {
        < 100 => CategorieRisc.A,
        < 200 => CategorieRisc.B,
        _ => CategorieRisc.C
    };
}

// Motocicleta nu transportă marfă: implementează doar IAsigurabil (ISP)
class Motocicleta(SpecificatiiVehicul specificatii, SpecificatiiMotor motor, string categorie)
    : Vehicul(specificatii, motor), IAsigurabil
{
    public string Categorie { get; } = categorie;

    public override string Tip => $"Motocicletă ({Categorie})";

    private bool EsteSport => Categorie == "Sport";

    public decimal CalculeazaPrima() =>
        500m + 3m * Motor.CaiPutere + (EsteSport ? 100m : 0m);

    public CategorieRisc CategorieRisc => EsteSport ? CategorieRisc.C : CategorieRisc.B;
}

class Camion(SpecificatiiVehicul specificatii, SpecificatiiMotor motor, int locuri, int sarcinaUtilaKg)
    : Vehicul(specificatii, motor), ITransport, IAsigurabil
{
    public int NumarLocuri { get; } = locuri;
    public int SarcinaUtilaKg { get; } = sarcinaUtilaKg;

    public override string Tip => "Camion";

    public string DescriereTransport => $"{NumarLocuri} locuri, sarcină utilă {SarcinaUtilaKg} kg";

    public override string Descriere() => $"{base.Descriere()}, {DescriereTransport}";

    public decimal CalculeazaPrima() => 1100m + 50m * SarcinaUtilaKg / 1000m;

    public CategorieRisc CategorieRisc => CategorieRisc.C;
}
