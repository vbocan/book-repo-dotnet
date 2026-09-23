// Capitolul 7 - Gestionarea erorilor și excepțiilor
// Exercițiul 4 - Refactorizarea codului cu gestionare incorectă a erorilor
//
// Problemele versiunii originale și corecturile:
//   1-3. ImparteNumere returna -1 pentru orice eroare, prinzând Exception.
//        -1 este un rezultat valid (de ex. -5 / 5), iar apelantul nu putea afla
//        ce s-a întâmplat. Acum metoda validează intrările și aruncă excepții
//        specifice (FormatException, DivideByZeroException) cu mesaje precise;
//        decizia de tratare aparține apelantului.
//   4-5. ScrieInFisier înghițea IOException după afișarea mesajului, iar apelantul
//        credea că scrierea a reușit. Acum metoda nu prinde nimic din ce nu poate
//        trata: excepțiile de I/O se propagă, iar apelantul le raportează.
//
// Rulare: dotnet run --project csharp/cap07-gestionarea-erorilor/refactorizarea-codului-cu-gestionare-incorecta-a-erorilor

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

static int ImparteNumere(string aStr, string bStr)
{
    // TryParse evită excepția internă; aruncăm noi una cu un mesaj care spune
    // exact care argument este greșit
    if (!int.TryParse(aStr, out int a))
        throw new FormatException($"Primul argument (\"{aStr}\") nu este un număr întreg valid.");
    if (!int.TryParse(bStr, out int b))
        throw new FormatException($"Al doilea argument (\"{bStr}\") nu este un număr întreg valid.");
    if (b == 0)
        throw new DivideByZeroException("Împărțire la zero.");

    return a / b;
}

static void ScrieInFisier(string cale, string continut)
{
    ArgumentException.ThrowIfNullOrWhiteSpace(cale);

    // Creăm directorul dacă lipsește; orice IOException sau
    // UnauthorizedAccessException ajunge la apelant
    string? director = Path.GetDirectoryName(cale);
    if (!string.IsNullOrEmpty(director))
        Directory.CreateDirectory(director);

    File.WriteAllText(cale, continut);
}

(string A, string B)[] perechi = [("10", "3"), ("abc", "5"), ("10", "0"), ("8", "xyz")];
List<string> rezultate = [];

foreach (var (a, b) in perechi)
{
    string linie;
    try
    {
        linie = $"{a} / {b} = {ImparteNumere(a, b)}";
    }
    catch (Exception ex) when (ex is FormatException or DivideByZeroException)
    {
        linie = $"{a} / {b} → eroare: {ex.Message}";
    }
    Console.WriteLine(linie);
    rezultate.Add(linie);
}

Console.WriteLine();

// Fișierul se scrie lângă executabil, ca rularea să nu depindă de directorul curent;
// în mesaj afișăm calea relativă
string caleRelativa = "output/rezultat.txt";
string caleCompleta = Path.Combine(AppContext.BaseDirectory, caleRelativa);
try
{
    ScrieInFisier(caleCompleta, string.Join(Environment.NewLine, rezultate));
    Console.WriteLine($"Fișierul '{caleRelativa}' a fost scris cu succes.");
}
catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
{
    Console.WriteLine($"Scrierea fișierului '{caleRelativa}' a eșuat: {ex.Message}");
}
