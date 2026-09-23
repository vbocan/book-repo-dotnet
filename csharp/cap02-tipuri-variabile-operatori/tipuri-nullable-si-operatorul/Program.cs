int? varsta = null;      // Nullable<int>
double? medie = null;    // Nullable<double>
bool? aAcceptat = null;  // Nullable<bool>

Console.WriteLine($"Vârsta are valoare: {varsta.HasValue}");

varsta = 22;
Console.WriteLine($"Vârsta are valoare: {varsta.HasValue}");
Console.WriteLine($"Vârsta: {varsta.Value}");

// Accesarea .Value când HasValue este false aruncă InvalidOperationException
medie = 9.75;
Console.WriteLine($"Media: {medie}");  // ToString() funcționează direct

// Operatorul ?? oferă o valoare implicită dacă variabila este null
int varstaCerta = varsta ?? 0;
double medieCerta = medie ?? 0.0;
bool aAcceptatCert = aAcceptat ?? false;

Console.WriteLine($"Vârsta certă: {varstaCerta}");
Console.WriteLine($"Media certă: {medieCerta}");
Console.WriteLine($"A acceptat cert: {aAcceptatCert}");
