// Capitolul 7 - Gestionarea erorilor și excepțiilor
// Exercițiul 5c - Bibliotecă de validare cu excepții personalizate (temă de casă)
//
// Ierarhia de excepții:
//   ValidareException              (baza; valoarea invalidă și motivul)
//   ├── EmailInvalidException
//   ├── TelefonInvalidException
//   └── VarstaInvalidaException
//
// Clasa statică Validator aruncă excepția specifică fiecărei reguli încălcate;
// programul principal decide ce face cu ea (aici, o afișează).
//
// Rulare: dotnet run --project csharp/cap07-gestionarea-erorilor/5c-biblioteca-de-validare-cu-exceptii-personalizate

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Rulează o validare și afișează ✓ (valoare acceptată) sau ✗ (mesajul excepției)
static void Verifica(string valoare, Action<string> validare)
{
    try
    {
        validare(valoare);
        Console.WriteLine($"  ✓ {valoare}");
    }
    catch (ValidareException ex)
    {
        Console.WriteLine($"  ✗ {ex.Message}");
    }
}

Console.WriteLine("=== Validare Email ===");
string[] emailuri =
    ["ion.popescu@gmail.com", "invalid", "lipseste@domeniu", "@fara-parte-locala.com", "", "dublu@@aron.com"];
foreach (string email in emailuri)
    Verifica(email, e => Validator.ValideazaEmail(e));

Console.WriteLine();
Console.WriteLine("=== Validare Telefon ===");
string[] telefoane = ["+40 721 123 456", "0721123456", "123", "+40-abc-def-ghi", "0721 123 456 789 012 345"];
foreach (string telefon in telefoane)
    Verifica(telefon, t => Validator.ValideazaTelefon(t));

Console.WriteLine();
Console.WriteLine($"=== Validare Vârsta ({Validator.VarstaMinima}–{Validator.VarstaMaxima}) ===");
string[] varste = ["25", "abc", "-5", "200", "17", "65", ""];
foreach (string varsta in varste)
    Verifica(varsta, v => Validator.ValideazaVarsta(v));

// ===== Biblioteca de validare =====

static class Validator
{
    public const int VarstaMinima = 18;
    public const int VarstaMaxima = 65;
    public const int CifreTelefonMin = 9;
    public const int CifreTelefonMax = 15;

    public static string ValideazaEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new EmailInvalidException(email, "adresa nu poate fi goală");

        int numarArond = email.Count(c => c == '@');
        if (numarArond == 0)
            throw new EmailInvalidException(email, "lipsește caracterul '@'");
        if (numarArond > 1)
            throw new EmailInvalidException(email, "format invalid (mai multe caractere '@')");

        int pozitie = email.IndexOf('@');
        string parteLocala = email[..pozitie];
        string domeniu = email[(pozitie + 1)..];

        if (parteLocala.Length == 0)
            throw new EmailInvalidException(email, "partea locală (înainte de '@') este goală");
        if (!domeniu.Contains('.'))
            throw new EmailInvalidException(email, "domeniul nu conține un punct");

        return email;
    }

    public static string ValideazaTelefon(string telefon)
    {
        if (string.IsNullOrWhiteSpace(telefon))
            throw new TelefonInvalidException(telefon, "numărul nu poate fi gol");

        // Sunt permise: un „+" inițial, cifre și separatorii spațiu sau cratimă
        string fara = telefon.StartsWith('+') ? telefon[1..] : telefon;
        if (fara.Any(c => !char.IsAsciiDigit(c) && c != ' ' && c != '-'))
            throw new TelefonInvalidException(telefon, "conține caractere non-numerice");

        int cifre = fara.Count(char.IsAsciiDigit);
        if (cifre < CifreTelefonMin || cifre > CifreTelefonMax)
            throw new TelefonInvalidException(telefon,
                $"lungime invalidă ({cifre} cifre, așteptat {CifreTelefonMin}–{CifreTelefonMax})");

        return telefon;
    }

    public static int ValideazaVarsta(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new VarstaInvalidaException(text, "valoarea nu poate fi goală");
        if (!int.TryParse(text, out int varsta))
            throw new VarstaInvalidaException(text, "nu este un număr întreg valid");
        if (varsta < VarstaMinima)
            throw new VarstaInvalidaException(varsta, $"trebuie să fie cel puțin {VarstaMinima}");
        if (varsta > VarstaMaxima)
            throw new VarstaInvalidaException(varsta, $"nu poate depăși {VarstaMaxima}");

        return varsta;
    }
}

// ===== Excepțiile de validare =====

class ValidareException : Exception
{
    public string? Valoare { get; }
    public string? Motiv { get; }

    public ValidareException()
        : base("Valoare invalidă.") { }

    public ValidareException(string message)
        : base(message) { }

    public ValidareException(string message, Exception innerException)
        : base(message, innerException) { }

    public ValidareException(string? valoare, string motiv, string message)
        : base(message)
    {
        Valoare = valoare;
        Motiv = motiv;
    }
}

class EmailInvalidException(string email, string motiv)
    : ValidareException(email, motiv, $"Adresa de email '{email}' este invalidă: {motiv}.");

class TelefonInvalidException(string telefon, string motiv)
    : ValidareException(telefon, motiv, $"Numărul de telefon '{telefon}' este invalid: {motiv}.");

class VarstaInvalidaException : ValidareException
{
    /// <summary>Vârsta numerică, dacă textul a putut fi convertit.</summary>
    public int? Varsta { get; }

    // Textul nu a putut fi convertit: îl afișăm între ghilimele
    public VarstaInvalidaException(string text, string motiv)
        : base(text, motiv, $"Vârsta '{text}' este invalidă: {motiv}.") { }

    // Numărul este valid, dar în afara intervalului permis
    public VarstaInvalidaException(int varsta, string motiv)
        : base(varsta.ToString(), motiv, $"Vârsta {varsta} este invalidă: {motiv}.")
    {
        Varsta = varsta;
    }
}
