(int Id, string Nume, double Medie) GetStudent()
{
    return (1, "Andrei", 9.25);
}

// Deconstrucție în variabile separate
var (id, nume, medie) = GetStudent();
Console.WriteLine($"ID: {id}, Nume: {nume}, Medie: {medie}");

// Puteți ignora elemente cu _
var (_, numeStudent, _) = GetStudent();
Console.WriteLine($"Doar numele: {numeStudent}");
