List<Student> studenti =
[
    new("Ana Popescu", 3, 9.50),
    new("Ion Ionescu", 2, 7.30),
    new("Maria Dumitrescu", 3, 8.75),
    new("Vlad Georgescu", 1, 6.20),
    new("Elena Marinescu", 2, 9.10)
];

// Any — există cel puțin un element care satisface condiția?
bool existaBursier = studenti.Any(s => s.Medie >= 9.0);
Console.WriteLine($"Există bursieri (medie ≥ 9)? {existaBursier}");

// All — TOATE elementele satisfac condiția?
bool totiPromovati = studenti.All(s => s.Medie >= 5.0);
Console.WriteLine($"Toți promovați (medie ≥ 5)? {totiPromovati}");

bool totiExcelenti = studenti.All(s => s.Medie >= 8.5);
Console.WriteLine($"Toți excelenți (medie ≥ 8.5)? {totiExcelenti}");

// Contains — colecția conține un element specific?
var cautat = new Student("Ana Popescu", 3, 9.50);
bool contineAna = studenti.Contains(cautat);
Console.WriteLine($"Conține Ana Popescu? {contineAna}");

record Student(string Nume, int AnStudiu, double Medie);
