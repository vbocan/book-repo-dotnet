// Capitolul 7 - Gestionarea erorilor și excepțiilor
// Exercițiul 5b - Calculator cu gestionarea completă a erorilor (temă de casă)
//
// Expresiile au forma <operand><operator><operand>, cu operanzi întregi.
//   - operand invalid          → FormatException
//   - operator necunoscut      → ArgumentException
//   - împărțire / rest la zero → DivideByZeroException
//   - depășire aritmetică      → OverflowException, tratată prin fallback:
//                                operația se reface în virgulă mobilă (double)
//
// Rulare: dotnet run --project csharp/cap07-gestionarea-erorilor/5b-calculator-cu-gestionarea-completa-a-erorilor

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

static (int Stang, char Operator, int Drept) Parseaza(string expresie)
{
    ArgumentException.ThrowIfNullOrWhiteSpace(expresie);

    // Operatorul este primul caracter care nu este literă sau cifră
    // (de la poziția 1, ca un eventual semn „-" al primului operand să fie ignorat)
    int poz = 1;
    while (poz < expresie.Length && char.IsLetterOrDigit(expresie[poz]))
        poz++;
    if (poz >= expresie.Length - 1)
        throw new FormatException($"Expresia nu are forma <operand><operator><operand>: '{expresie}'");

    string stang = expresie[..poz].Trim();
    string drept = expresie[(poz + 1)..].Trim();

    if (!int.TryParse(stang, out int a))
        throw new FormatException($"Operandul stâng nu este valid: '{stang}'");
    if (!int.TryParse(drept, out int b))
        throw new FormatException($"Operandul drept nu este valid: '{drept}'");

    return (a, expresie[poz], b);
}

static double Calculeaza(int a, char op, int b)
{
    try
    {
        // checked: depășirea domeniului int aruncă OverflowException,
        // în loc să producă în tăcere un rezultat greșit
        return op switch
        {
            '+' => checked(a + b),
            '-' => checked(a - b),
            '*' => checked(a * b),
            '/' => b == 0 ? throw new DivideByZeroException("Împărțire la zero.") : checked(a / b),
            '%' => b == 0 ? throw new DivideByZeroException("Împărțire la zero.") : a % b,
            _ => throw new ArgumentException($"Operator necunoscut: '{op}'", nameof(op)),
        };
    }
    catch (OverflowException)
    {
        // Fallback: rezultatul nu încape în int, așa că refacem calculul cu double
        return op switch
        {
            '+' => (double)a + b,
            '-' => (double)a - b,
            '*' => (double)a * b,
            '/' => (double)a / b,   // singurul caz posibil: int.MinValue / -1
            _ => 0,                 // int.MinValue % -1: restul este matematic 0
        };
    }
}

string[] expresii = ["10+5", "100/0", "7*6", "abc+3", "2^4", "15%4", "999999999*999999999"];

foreach (string expresie in expresii)
{
    try
    {
        var (a, op, b) = Parseaza(expresie);
        Console.WriteLine($"{expresie} = {Calculeaza(a, op, b)}");
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"{expresie} = eroare format: {ex.Message}");
    }
    catch (Exception ex) when (ex is DivideByZeroException or ArgumentException)
    {
        Console.WriteLine($"{expresie} = eroare: {ex.Message}");
    }
}
