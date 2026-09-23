List<Departament> departamente =
[
    new("Inginerie", ["Ana", "Ion", "Maria"]),
    new("Marketing", ["Vlad", "Elena"]),
    new("Vânzări", ["Andrei", "Cristina", "Dan", "Laura"])
];

// SelectMany — aplatizare: toate numele într-o singură secvență
var totiAngajatii = departamente.SelectMany(d => d.Angajati);
Console.WriteLine($"Toți angajații: {string.Join(", ", totiAngajatii)}");
Console.WriteLine($"Total: {totiAngajatii.Count()}");

// SelectMany cu proiecție care păstrează contextul
var angajatiCuDepartament = departamente.SelectMany(
    d => d.Angajati,
    (departament, angajat) => new { Angajat = angajat, Departament = departament.Nume }
);

Console.WriteLine("\nAngajați cu departamente:");
foreach (var a in angajatiCuDepartament)
    Console.WriteLine($"  {a.Angajat} — {a.Departament}");

record Departament(string Nume, List<string> Angajati);
