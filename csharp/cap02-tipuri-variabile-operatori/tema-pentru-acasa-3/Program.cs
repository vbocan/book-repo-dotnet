// Tema 3: Tabla înmulțirii
int numar = 7;
Console.WriteLine($"Tabla înmulțirii pentru {numar}:");

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"  {numar} x {i,2} = {numar * i,3}");
}
