// Exercițiul 1: Variabile de diferite tipuri primitive
byte varsta = 22;
short anNastere = 2004;
int populatieTimisoara = 250_849;       // recensământul din 2021
long distantaLuna = 384_400_000L;       // în metri
float temperaturaMedie = 10.8f;         // grade Celsius
double pi = 3.141592653589793;
decimal soldBancar = 15_234.56m;
bool esteStudent = true;
char initiala = 'V';
string numeComplet = "Valer Bocan";

Console.WriteLine("=== Tipuri de date primitive în C# ===");
Console.WriteLine($"byte    varsta = {varsta}");
Console.WriteLine($"short   anNastere = {anNastere}");
Console.WriteLine($"int     populatieTimisoara = {populatieTimisoara}");
Console.WriteLine($"long    distantaLuna = {distantaLuna} m");
Console.WriteLine($"float   temperaturaMedie = {temperaturaMedie} °C");
Console.WriteLine($"double  pi = {pi}");
Console.WriteLine($"decimal soldBancar = {soldBancar} RON");
Console.WriteLine($"bool    esteStudent = {esteStudent}");
Console.WriteLine($"char    initiala = '{initiala}'");
Console.WriteLine($"string  numeComplet = \"{numeComplet}\"");
