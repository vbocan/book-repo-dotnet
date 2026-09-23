// Tema 2: An bisect
int an = 2024;

bool esteBisect = (an % 4 == 0 && an % 100 != 0) || (an % 400 == 0);
Console.WriteLine($"Anul {an} este bisect: {esteBisect}");

// Verificare pentru mai mulți ani
int[] ani = { 1900, 2000, 2023, 2024, 2100 };
foreach (int a in ani)
{
    bool bisect = (a % 4 == 0 && a % 100 != 0) || (a % 400 == 0);
    Console.WriteLine($"  {a}: {(bisect ? "bisect" : "nu este bisect")}");
}
