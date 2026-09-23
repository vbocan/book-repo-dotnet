int dimensiune = 5;
Console.WriteLine($"Tabla înmulțirii (1-{dimensiune}):");
Console.WriteLine(new string('-', 30));

for (int i = 1; i <= dimensiune; i++)
{
    for (int j = 1; j <= dimensiune; j++)
    {
        Console.Write($"{i * j,4}");
    }
    Console.WriteLine();
}
