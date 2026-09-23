// Lambda cu un singur parametru — parantezele sunt opționale
Func<int, int> dublu = n => n * 2;

// Lambda cu doi parametri — parantezele sunt obligatorii
Func<int, int, int> suma = (a, b) => a + b;

// Lambda fără parametri
Func<DateTime> acum = () => DateTime.Now;

// Lambda cu corp de instrucțiuni (statement body)
Func<int, string> clasificare = n =>
{
    if (n >= 9) return "Excelent";
    if (n >= 7) return "Bine";
    if (n >= 5) return "Suficient";
    return "Insuficient";
};

Console.WriteLine($"Dublu de 7: {dublu(7)}");
Console.WriteLine($"Suma 3 + 5: {suma(3, 5)}");
Console.WriteLine($"Acum: {acum()}");
Console.WriteLine($"Nota 8: {clasificare(8)}");
Console.WriteLine($"Nota 4: {clasificare(4)}");
