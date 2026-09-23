string? numeUtilizator = null;
string numeAfisat = numeUtilizator ?? "Anonim";
Console.WriteLine($"Utilizator: {numeAfisat}");

numeUtilizator = "Maria";
numeAfisat = numeUtilizator ?? "Anonim";
Console.WriteLine($"Utilizator: {numeAfisat}");

// Operatorii pot fi înlănțuiți
string? prim = null;
string? secund = null;
string? tert = "Valoare";
string final_ = prim ?? secund ?? tert ?? "Implicit";
Console.WriteLine($"Prima valoare non-null: {final_}");
