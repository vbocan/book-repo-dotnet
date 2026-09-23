var rex = new CaineDeDresaj("Rex", "Ciobănesc German", "Căutare și salvare");
Console.WriteLine(rex);

class Animal(string nume)
{
    public string Nume { get; } = nume;
}

class Caine(string nume, string rasa) : Animal(nume)
{
    public string Rasa { get; } = rasa;

    public override string ToString()
    {
        return $"{Nume} ({Rasa})";
    }
}

class CaineDeDresaj(string nume, string rasa, string specialitate)
    : Caine(nume, rasa)
{
    public string Specialitate { get; } = specialitate;

    public override string ToString()
    {
        return $"{base.ToString()} — specialitate: {Specialitate}";
    }
}
