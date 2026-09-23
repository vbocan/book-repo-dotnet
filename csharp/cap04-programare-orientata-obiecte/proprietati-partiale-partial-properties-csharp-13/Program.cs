// Fișier: Persoana.cs (scris de programator: declarația)

// Fișier: Persoana.g.cs (implementarea, produsă de obicei de un source generator)

var persoana = new PersoanaPartiala { Nume = "  Ana Marin  ", Varsta = 25 };
Console.WriteLine($"{persoana.Nume}, {persoana.Varsta} ani");

partial class PersoanaPartiala
{
    public partial string Nume { get; set; }
    public partial int Varsta { get; set; }
}

partial class PersoanaPartiala
{
    public partial string Nume
    {
        get => field;
        set => field = value?.Trim() ?? "";
    } = "";

    public partial int Varsta
    {
        get => field;
        set => field = value >= 0 ? value
            : throw new ArgumentOutOfRangeException(nameof(Varsta));
    }
}
