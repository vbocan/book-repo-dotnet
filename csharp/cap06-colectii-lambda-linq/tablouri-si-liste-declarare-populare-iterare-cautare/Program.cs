// Capitolul 6 - Colecții, expresii lambda și LINQ
// Exercițiul 1 - Tablouri și liste: declarare, populare, iterare, căutare
//
// Operațiile fundamentale pe un tablou de note (parcurgere, sortare, căutare,
// inversare, extragere cu range) și pe o listă de studenți (căutare, filtrare,
// sortare cu lambda).
//
// Rulare: dotnet run --project csharp/cap06-colectii-lambda-linq/tablouri-si-liste-declarare-populare-iterare-cautare

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// ===== Tablou =====
Console.WriteLine("=== Operații pe tablou ===");

int[] note = [8, 10, 7, 9, 10, 6, 8, 9, 5, 10];
Console.WriteLine($"Note: {string.Join(", ", note)}");
Console.WriteLine($"Lungime: {note.Length}");

// Sortăm o copie, ca tabloul original să rămână neschimbat
int[] sortate = [.. note];
Array.Sort(sortate);
Console.WriteLine($"Sortate: {string.Join(", ", sortate)}");

// Căutare: prima apariție a valorii 9 în tabloul sortat
Console.WriteLine($"Indexul lui 9: {Array.IndexOf(sortate, 9)}");

int[] inversate = [.. sortate];
Array.Reverse(inversate);
Console.WriteLine($"Inversate: {string.Join(", ", inversate)}");

// Range: primele 5 elemente ale tabloului inversat (cele mai mari note)
Console.WriteLine($"Primele 5: {string.Join(", ", inversate[..5])}");

// ===== List<T> =====
Console.WriteLine();
Console.WriteLine("=== Operații pe List<T> ===");

List<Student> studenti =
[
    new("Ana Popescu", 9.50),
    new("Ion Ionescu", 7.30),
    new("Maria Dumitrescu", 8.75),
    new("Vlad Georgescu", 6.20),
    new("Elena Marinescu", 9.10),
];
studenti.Add(new("Andrei Vasilescu", 8.00));
studenti.Add(new("Cristina Radu", 7.85));

Console.WriteLine($"Număr studenți: {studenti.Count}");

// Căutarea maximului printr-o parcurgere explicită
Student celMaiBun = studenti[0];
foreach (Student s in studenti)
{
    if (s.Medie > celMaiBun.Medie)
        celMaiBun = s;
}
Console.WriteLine($"Cel mai bun: {celMaiBun}");

// Filtrare cu un predicat (FindAll păstrează ordinea din listă)
List<Student> bursieri = studenti.FindAll(s => s.Medie >= 8.50);
Console.WriteLine($"Bursieri (medie ≥ 8.50): {string.Join(", ", bursieri.Select(s => s.Nume))}");

// Sortare descrescătoare după medie, cu o lambda de comparare
List<Student> clasament = [.. studenti];
clasament.Sort((a, b) => b.Medie.CompareTo(a.Medie));

Console.WriteLine();
Console.WriteLine("Clasament:");
for (int i = 0; i < clasament.Count; i++)
    Console.WriteLine($"  {i + 1}. {clasament[i].Nume}: {clasament[i].Medie:F2}");

record Student(string Nume, double Medie);
