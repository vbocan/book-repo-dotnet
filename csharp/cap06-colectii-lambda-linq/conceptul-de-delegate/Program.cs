// Declararea unui tip delegate

// Metode compatibile cu delegate-ul
static double Aduna(double a, double b) => a + b;
static double Inmulteste(double a, double b) => a * b;
static double Putere(double a, double b) => Math.Pow(a, b);

// Instanțierea delegate-ului
OperatieMatematica operatie = Aduna;
Console.WriteLine($"Adunare: {operatie(3, 4)}");

operatie = Inmulteste;
Console.WriteLine($"Înmulțire: {operatie(3, 4)}");

operatie = Putere;
Console.WriteLine($"Putere: {operatie(3, 4)}");

delegate double OperatieMatematica(double a, double b);
