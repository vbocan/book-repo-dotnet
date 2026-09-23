static void IncearcaModificare(int x)
{
    x = 100;
    Console.WriteLine($"  În metodă: x = {x}");
}

int numar = 42;
Console.WriteLine($"Înainte de apel: numar = {numar}");
IncearcaModificare(numar);
Console.WriteLine($"După apel: numar = {numar}");
