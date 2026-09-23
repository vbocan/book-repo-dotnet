HashSet<string> cursuri = ["Programare .NET", "Baze de date", "Algoritmi"];

cursuri.Add("Rețele");
cursuri.Add("Programare .NET"); // duplicat — nu se adaugă

Console.WriteLine($"Cursuri ({cursuri.Count}): {string.Join(", ", cursuri)}");

// Operații de mulțimi
HashSet<string> cursuriFacultativa = ["Rețele", "Criptografie", "IA"];

var intersectie = new HashSet<string>(cursuri);
intersectie.IntersectWith(cursuriFacultativa);
Console.WriteLine($"Comune: {string.Join(", ", intersectie)}");

var reuniune = new HashSet<string>(cursuri);
reuniune.UnionWith(cursuriFacultativa);
Console.WriteLine($"Reuniune: {string.Join(", ", reuniune)}");
