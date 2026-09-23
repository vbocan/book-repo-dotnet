string nume = "Maria";
int varsta = 22;
double medie = 9.45;

string mesaj = $"{nume} are {varsta} de ani și media {medie:F2}.";
Console.WriteLine(mesaj);

// Expresii arbitrare în interpolări
Console.WriteLine($"Anul nașterii: aproximativ {DateTime.Now.Year - varsta}");
Console.WriteLine($"Numele are {nume.Length} caractere.");
