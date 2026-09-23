var registru = new RegistruStudenti();
registru.Adauga(new Student("Maria Popescu", "AC-2023-001", 3, 9.25));
registru.Adauga(new Student("Andrei Ionescu", "AC-2023-002", 3, 7.80));
registru.Adauga(new Student("Elena Dumitrescu", "AC-2023-003", 3, 9.60));
registru.Adauga(new Student("Ion Marinescu", "AC-2023-004", 3, 8.50));

registru.AfiseazaToti();

Console.WriteLine($"\nStudenți bursieri (media ≥ 9.00):");
foreach (var s in registru.StudentiBursieri(9.00))
{
    Console.WriteLine($"  {s.Nume}: {s.Medie:F2}");
}

var cautat = registru.CautaDupaMatricol("AC-2023-002");
Console.WriteLine($"\nCăutare AC-2023-002: {cautat}");

// Demonstrare imutabilitate cu with
var promovat = cautat! with { AnStudiu = 4 };
Console.WriteLine($"Promovat: {promovat}");

public record Student(string Nume, string NumarMatricol, int AnStudiu, double Medie);

class RegistruStudenti
{
    private List<Student> _studenti = [];

    public void Adauga(Student student) => _studenti.Add(student);

    public Student? CautaDupaMatricol(string matricol) =>
        _studenti.Find(s => s.NumarMatricol == matricol);

    public List<Student> StudentiBursieri(double pragMedie) =>
        _studenti.FindAll(s => s.Medie >= pragMedie);

    public void AfiseazaToti()
    {
        Console.WriteLine($"Registru: {_studenti.Count} studenți");
        foreach (var s in _studenti)
        {
            Console.WriteLine($"  [{s.NumarMatricol}] {s.Nume}, " +
                $"anul {s.AnStudiu}, media {s.Medie:F2}");
        }
    }
}
