int numar = 14;
string descriere = numar switch
{
    < 0 => "negativ",
    0 => "zero",
    var n when n % 2 == 0 => "pozitiv și par",
    _ => "pozitiv și impar"
};

Console.WriteLine($"{numar} este {descriere}");
