int suma = 0;
int contor = 0;

Console.WriteLine("Introduceți numere (0 pentru a termina):");

Console.Write("> ");
int valoare = int.Parse(Console.ReadLine()!);

while (valoare != 0)
{
    suma += valoare;
    contor++;
    Console.Write("> ");
    valoare = int.Parse(Console.ReadLine()!);
}

if (contor > 0)
{
    Console.WriteLine($"Suma: {suma}, Media: {(double)suma / contor:F2}");
}
else
{
    Console.WriteLine("Nu ați introdus niciun număr.");
}
