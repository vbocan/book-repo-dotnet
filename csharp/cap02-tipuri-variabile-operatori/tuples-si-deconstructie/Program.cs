// Tuplu fără nume — elementele se accesează prin Item1, Item2 etc.
(int, string, double) student = (1, "Maria", 9.75);
Console.WriteLine($"ID: {student.Item1}, Nume: {student.Item2}, Medie: {student.Item3}");

// Tuplu cu nume — mult mai lizibil
(int Id, string Nume, double Medie) studentNume = (2, "Ion", 8.50);
Console.WriteLine($"ID: {studentNume.Id}, Nume: {studentNume.Nume}, Medie: {studentNume.Medie}");
