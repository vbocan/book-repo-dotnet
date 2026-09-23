var lista = new List<int>();

try
{
    // Lista este goală — nu poate avea un prim element
    var enumerator = lista.GetEnumerator();
    enumerator.MoveNext();
    // Forțăm o operație pe o coadă goală pentru a ilustra excepția
    var coada = new Queue<int>();
    int element = coada.Dequeue(); // InvalidOperationException!
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Excepție: {ex.GetType().Name}");
    Console.WriteLine($"Mesaj: {ex.Message}");
}
