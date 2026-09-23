// Capitolul 4 - Programare orientată pe obiecte în C#
// Exercițiul 4 - Model de clase: sistem de bibliotecă
//
// Autor este un record (date imutabile, egalitate după valoare), iar Carte
// și Biblioteca sunt clase, deoarece starea lor se schimbă (împrumut/returnare).
//
// Rulare: dotnet run --project csharp/cap04-programare-orientata-obiecte/model-de-clase-sistem-de-biblioteca

var eminescu = new Autor("Mihai", "Eminescu");
var orwell = new Autor("George", "Orwell");
var hesse = new Autor("Hermann", "Hesse");

var biblioteca = new Biblioteca("Biblioteca Centrală UPT");
biblioteca.Adauga(new Carte("Poezii", eminescu, 1883));
biblioteca.Adauga(new Carte("1984", orwell, 1949));
biblioteca.Adauga(new Carte("Lupul de stepă", hesse, 1927));
biblioteca.Adauga(new Carte("Ferma animalelor", orwell, 1945));

biblioteca.AfiseazaCatalog();
Console.WriteLine();

Carte? carte = biblioteca.Imprumuta("1984");
if (carte is not null)
{
    Console.WriteLine($"Împrumutată: {carte}");
}
Console.WriteLine();

Console.WriteLine($"Cărți disponibile: {biblioteca.NumarDisponibile}");
biblioteca.AfiseazaCatalog();
Console.WriteLine();

if (carte is not null)
{
    carte.Returneaza();
    Console.WriteLine("După returnare:");
    Console.WriteLine(carte);
}

// Record: proprietăți init-only, egalitate după valoare
record Autor(string Prenume, string Nume)
{
    public string NumeComplet => $"{Prenume} {Nume}";
}

class Carte
{
    public string Titlu { get; }
    public Autor Autor { get; }
    public int AnPublicare { get; }
    public bool EsteDisponibila { get; private set; } = true;

    public Carte(string titlu, Autor autor, int anPublicare)
    {
        Titlu = titlu;
        Autor = autor;
        AnPublicare = anPublicare;
    }

    public bool Imprumuta()
    {
        if (!EsteDisponibila) return false;
        EsteDisponibila = false;
        return true;
    }

    public void Returneaza() => EsteDisponibila = true;

    public override string ToString() =>
        $"\"{Titlu}\" de {Autor.NumeComplet} ({AnPublicare}) — " +
        (EsteDisponibila ? "disponibilă" : "împrumutată");
}

class Biblioteca
{
    private readonly List<Carte> _carti = [];

    public string Nume { get; }

    public Biblioteca(string nume) => Nume = nume;

    public int NumarCarti => _carti.Count;

    public int NumarDisponibile
    {
        get
        {
            int numar = 0;
            foreach (var carte in _carti)
            {
                if (carte.EsteDisponibila) numar++;
            }
            return numar;
        }
    }

    public void Adauga(Carte carte) => _carti.Add(carte);

    public Carte? CautaDupaTitlu(string titlu)
    {
        foreach (var carte in _carti)
        {
            if (carte.Titlu == titlu) return carte;
        }
        return null;
    }

    // Returnează cartea împrumutată sau null dacă nu există / nu e disponibilă
    public Carte? Imprumuta(string titlu)
    {
        Carte? carte = CautaDupaTitlu(titlu);
        return carte is not null && carte.Imprumuta() ? carte : null;
    }

    public void AfiseazaCatalog()
    {
        Console.WriteLine($"=== Biblioteca \"{Nume}\" — {NumarCarti} cărți ===");
        foreach (var carte in _carti)
        {
            Console.WriteLine($"  {carte}");
        }
    }
}
