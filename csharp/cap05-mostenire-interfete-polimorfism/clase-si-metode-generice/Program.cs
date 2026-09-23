// Capitolul 5 - Moștenire, interfețe și polimorfism
// Secțiunea 5.5.1 - Clase și metode generice (codul complet al exemplului)
//
// Stivă generică Stiva<T> peste un tablou redimensionabil, cu Push, Pop,
// Peek, Count și EsteGoala, instanțiată cu int și cu string.
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/clase-si-metode-generice

var stivaNr = new Stiva<int>();       // stivă de numere întregi
stivaNr.Push(10);
stivaNr.Push(20);
stivaNr.Push(30);

Console.WriteLine($"Vârf: {stivaNr.Peek()}");
Console.WriteLine($"Pop: {stivaNr.Pop()}");
Console.WriteLine($"Pop: {stivaNr.Pop()}");
Console.WriteLine($"Elemente rămase: {stivaNr.Count}");

Console.WriteLine();

var stivaStr = new Stiva<string>();   // stivă de șiruri
stivaStr.Push("alpha");
stivaStr.Push("beta");
stivaStr.Push("gamma");

while (!stivaStr.EsteGoala)
{
    Console.WriteLine($"Pop: {stivaStr.Pop()}");
}

class Stiva<T>
{
    private T[] _elemente;
    private int _varf;   // indexul primei poziții libere = numărul de elemente

    public Stiva(int capacitateInitiala = 4)
    {
        _elemente = new T[capacitateInitiala];
    }

    public int Count => _varf;

    public bool EsteGoala => _varf == 0;

    public void Push(T element)
    {
        if (_varf == _elemente.Length)
            Array.Resize(ref _elemente, _elemente.Length * 2);
        _elemente[_varf++] = element;
    }

    public T Pop()
    {
        if (EsteGoala) throw new InvalidOperationException("Stiva este goală.");
        T element = _elemente[--_varf];
        _elemente[_varf] = default!;   // eliberăm referința (pentru tipuri referință)
        return element;
    }

    public T Peek()
    {
        if (EsteGoala) throw new InvalidOperationException("Stiva este goală.");
        return _elemente[_varf - 1];
    }
}
