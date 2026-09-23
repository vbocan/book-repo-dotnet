// Capitolul 5 - Moștenire, interfețe și polimorfism
// Exercițiul 3 - Colecție generică cu constrângeri
//
// Colectie<T> cere T : IEquatable<T>, astfel încât Contine() și Elimina()
// compară elementele prin Equals(T), fără boxing pentru tipurile valoare.
// Colecția nu păstrează ordinea: Elimina() mută ultimul element în locul
// celui eliminat (operație în timp constant).
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/colectie-generica-cu-constrangeri

var numere = new Colectie<int>();
numere.Adauga(10);
numere.Adauga(20);
numere.Adauga(30);
numere.Adauga(40);
numere.Adauga(50);

Console.WriteLine($"Numere: {numere}");
Console.WriteLine($"Conține 30? {numere.Contine(30)}");
Console.WriteLine($"Conține 99? {numere.Contine(99)}");
numere.Elimina(30);
Console.WriteLine($"După eliminarea lui 30: {numere}");
Console.WriteLine($"Count: {numere.Count}");

Console.WriteLine();

var cuvinte = new Colectie<string>();
cuvinte.Adauga("alpha");
cuvinte.Adauga("beta");
cuvinte.Adauga("gamma");

Console.WriteLine($"Cuvinte: {cuvinte}");
Console.WriteLine($"Conține \"beta\"? {cuvinte.Contine("beta")}");
Console.WriteLine($"Element la index 1: {cuvinte[1]}");

class Colectie<T> where T : IEquatable<T>
{
    private T[] _elemente = new T[4];

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _elemente[index];
        }
    }

    public void Adauga(T element)
    {
        if (Count == _elemente.Length)
            Array.Resize(ref _elemente, _elemente.Length * 2);
        _elemente[Count++] = element;
    }

    public bool Contine(T element) => IndexOf(element) >= 0;

    // Elimină prima apariție; ultimul element îi ia locul
    public bool Elimina(T element)
    {
        int index = IndexOf(element);
        if (index < 0) return false;

        Count--;
        _elemente[index] = _elemente[Count];
        _elemente[Count] = default!;   // eliberăm poziția rămasă liberă
        return true;
    }

    private int IndexOf(T element)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_elemente[i].Equals(element))   // IEquatable<T>.Equals(T)
                return i;
        }
        return -1;
    }

    public override string ToString()
    {
        var parti = new string[Count];
        for (int i = 0; i < Count; i++)
        {
            parti[i] = _elemente[i].ToString() ?? "";
        }
        return $"[{string.Join(", ", parti)}]";
    }
}
