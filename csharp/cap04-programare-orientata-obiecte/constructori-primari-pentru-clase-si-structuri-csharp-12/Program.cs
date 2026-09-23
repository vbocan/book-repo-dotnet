// Varianta cu constructor primar (C# 12)

var student = new Student("Elena", 3);
student.Afiseaza();

class Student(string nume, int anStudiu)
{
    public string Nume { get; } = nume;
    public int AnStudiu { get; } = anStudiu;

    public void Afiseaza() => Console.WriteLine($"{Nume}, anul {AnStudiu}");
}
