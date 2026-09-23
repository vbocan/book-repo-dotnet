Console.Write("Introduceți un număr pozitiv: ");
string input = Console.ReadLine()!;

if (int.TryParse(input, out int numar))
{
    if (numar > 0)
    {
        Console.WriteLine($"Ați introdus numărul pozitiv: {numar}");
    }
    else
    {
        Console.WriteLine("Numărul trebuie să fie strict pozitiv.");
    }
}
else
{
    Console.WriteLine("Intrarea nu este un număr valid.");
}
