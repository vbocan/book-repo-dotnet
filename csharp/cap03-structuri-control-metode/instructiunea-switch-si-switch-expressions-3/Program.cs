int nota = 8;
string calificativ = nota switch
{
    >= 9 => "Excelent",
    >= 7 => "Bine",
    >= 5 => "Suficient",
    _ => "Insuficient"
};

Console.WriteLine($"Nota {nota}: {calificativ}");
