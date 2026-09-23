static void Dubleaza(ref int valoare)
{
    valoare *= 2;
}

int x = 10;
Console.WriteLine($"Înainte: x = {x}");
Dubleaza(ref x);
Console.WriteLine($"După:    x = {x}");
