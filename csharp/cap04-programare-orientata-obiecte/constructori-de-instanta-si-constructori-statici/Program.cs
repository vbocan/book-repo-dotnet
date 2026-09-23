var s1 = new Student();
var s2 = new Student("Maria", 3);
var s3 = new Student("Andrei", 2, 8.75);

Console.WriteLine(s1);
Console.WriteLine(s2);
Console.WriteLine(s3);

class Student
{
    public string Nume { get; set; }
    public int AnStudiu { get; set; }
    public double Medie { get; set; }

    // Constructor fără parametri
    public Student()
    {
        Nume = "Necunoscut";
        AnStudiu = 1;
        Medie = 0;
    }

    // Constructor cu parametri
    public Student(string nume, int anStudiu)
    {
        Nume = nume;
        AnStudiu = anStudiu;
        Medie = 0;
    }

    // Constructor complet
    public Student(string nume, int anStudiu, double medie)
    {
        Nume = nume;
        AnStudiu = anStudiu;
        Medie = medie;
    }

    public override string ToString() =>
        $"{Nume}, anul {AnStudiu}, media {Medie:F2}";
}
