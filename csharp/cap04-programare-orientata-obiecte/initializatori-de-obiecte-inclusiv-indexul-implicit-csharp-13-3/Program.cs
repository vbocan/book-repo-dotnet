var grafic = new GraficZilnic
{
    [8] = "Curs Programare .NET",
    [10] = "Laborator",
    [13] = "Pauza de prânz",
    [14] = "Proiect echipă",
    [^2] = "Lectură"          // C# 13: ora 22 (24 - 2)
};

Console.WriteLine("Program de astăzi:");
grafic.AfiseazaProgram();

class GraficZilnic
{
    private string[] _activitati = new string[24];

    public int Length => _activitati.Length;

    public string this[int ora]
    {
        get => _activitati[ora] ?? "Liber";
        set => _activitati[ora] = value;
    }

    public void AfiseazaProgram()
    {
        for (int i = 0; i < 24; i++)
        {
            if (_activitati[i] is not null)
                Console.WriteLine($"  {i:D2}:00 — {_activitati[i]}");
        }
    }
}
