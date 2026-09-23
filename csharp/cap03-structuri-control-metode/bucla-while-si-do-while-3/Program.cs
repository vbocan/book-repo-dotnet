int numarSecret = 7;
int incercare;

do
{
    Console.Write("Ghiciți numărul (1-10): ");
    incercare = int.Parse(Console.ReadLine()!);

    if (incercare < numarSecret)
        Console.WriteLine("Prea mic!");
    else if (incercare > numarSecret)
        Console.WriteLine("Prea mare!");

} while (incercare != numarSecret);

Console.WriteLine("Felicitări! Ați ghicit!");
