// Capitolul 7 - Gestionarea erorilor și excepțiilor
// Exercițiul 2 - Propagarea excepțiilor și stack trace
//
// Lanțul de apeluri: ProceseazaNote → CalculeazaMedie → Imparte.
// Excepția aruncată în Imparte urcă pe stivă; ProceseazaNote o observă și o
// rearuncă cu `throw;`, deci stack trace-ul păstrează originea erorii.
//
// Experiment: în ProceseazaNote, scrieți `catch (DivideByZeroException ex)` și
// înlocuiți `throw;` cu `throw ex;`. Stack trace-ul
// este resetat în ProceseazaNote, iar ultimele două verificări afișează False.
//
// Rulare: dotnet run --project csharp/cap07-gestionarea-erorilor/propagarea-exceptiilor-si-stack-trace

// Nivelul 3: operația elementară, care detectează eroarea
static int Imparte(int deimpartit, int impartitor)
{
    if (impartitor == 0)
        throw new DivideByZeroException($"Împărțire la zero: {deimpartit} / {impartitor}");
    return deimpartit / impartitor;
}

// Nivelul 2: validează argumentele și calculează media ponderată
static int CalculeazaMedie(int[] note, int[] ponderi)
{
    if (note.Length != ponderi.Length)
        throw new ArgumentException("Tablourile trebuie să aibă aceeași lungime.");

    int suma = 0, sumaPonderi = 0;
    for (int i = 0; i < note.Length; i++)
    {
        suma += note[i] * ponderi[i];
        sumaPonderi += ponderi[i];
    }
    return Imparte(suma, sumaPonderi);
}

// Nivelul 1: observă împărțirea la zero, dar nu o poate trata, deci o propagă
static int ProceseazaNote(int[] note, int[] ponderi)
{
    try
    {
        return CalculeazaMedie(note, ponderi);
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Eroare detectată în ProceseazaNote — se propagă mai departe.");
        throw;   // păstrează stack trace-ul original
    }
}

// Cazul corect
Console.WriteLine($"Media ponderată: {ProceseazaNote([10, 8, 6], [1, 2, 1])}");
Console.WriteLine();

// Suma ponderilor este 0: excepția pornește din Imparte
try
{
    ProceseazaNote([9, 7], [0, 0]);
}
catch (DivideByZeroException ex)
{
    // Stack trace-ul conține numele metodelor, fișierele și numerele de linie;
    // verificăm doar prezența metodelor, care nu depinde de mediul de rulare.
    string stackTrace = ex.StackTrace ?? "";
    Console.WriteLine($"Excepție prinsă: {ex.Message}");
    Console.WriteLine($"Stack trace conține 'Imparte': {stackTrace.Contains("Imparte")}");
    Console.WriteLine($"Stack trace conține 'CalculeazaMedie': {stackTrace.Contains("CalculeazaMedie")}");
}
Console.WriteLine();

// Argumente inconsistente: excepția pornește din CalculeazaMedie și trece
// neatinsă prin ProceseazaNote, care prinde doar DivideByZeroException
try
{
    ProceseazaNote([9, 7, 10], [1, 1]);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Excepție prinsă: {ex.Message}");
}
