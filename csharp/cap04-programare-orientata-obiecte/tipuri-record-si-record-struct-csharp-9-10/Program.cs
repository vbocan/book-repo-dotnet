var s1 = new Student("Maria", 3);
var s2 = new Student("Maria", 3);
var s3 = new Student("Andrei", 2);

Console.WriteLine(s1);
Console.WriteLine($"s1 == s2? {s1 == s2}");
Console.WriteLine($"s1 == s3? {s1 == s3}");

public record Student(string Nume, int AnStudiu);
