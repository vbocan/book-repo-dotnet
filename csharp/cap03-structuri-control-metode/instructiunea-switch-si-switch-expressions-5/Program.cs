object valoare = 3.14;

string descriere = valoare switch
{
    int i => $"Număr întreg: {i}",
    double d => $"Număr real: {d}",
    string s => $"Șir de caractere: \"{s}\"",
    _ => "Tip necunoscut"
};

Console.WriteLine(descriere);
