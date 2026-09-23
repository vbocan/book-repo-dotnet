var adresa = new Adresa
{
    Strada = "Bulevardul Vasile Pârvan 2",
    Oras = "Timișoara",
    Judet = "Timiș",
    CodPostal = "300223"
};

Console.WriteLine(adresa);

class Adresa
{
    public string Strada { get; set; } = "";
    public string Oras { get; set; } = "";
    public string Judet { get; set; } = "";
    public string CodPostal { get; set; } = "";

    public override string ToString() =>
        $"{Strada}, {Oras}, {Judet} {CodPostal}";
}
