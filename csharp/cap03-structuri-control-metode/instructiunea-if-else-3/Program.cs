Console.Write("Introduceți nota (1-10): ");
int nota = int.Parse(Console.ReadLine()!);

if (nota >= 9)
{
    Console.WriteLine("Excelent!");
}
else if (nota >= 7)
{
    Console.WriteLine("Bine.");
}
else if (nota >= 5)
{
    Console.WriteLine("Suficient.");
}
else
{
    Console.WriteLine("Insuficient — trebuie să refaceți examenul.");
}
