Console.WriteLine("Numere de la 1 la 10 care nu sunt multipli de 3:");

for (int i = 1; i <= 10; i++)
{
    if (i % 3 == 0)
        continue;

    Console.Write($"{i} ");
}
Console.WriteLine();
