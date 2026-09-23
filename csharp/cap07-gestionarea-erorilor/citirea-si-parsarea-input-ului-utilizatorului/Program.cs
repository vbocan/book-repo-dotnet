// Capitolul 7 - Gestionarea erorilor și excepțiilor
// Exercițiul 1 - Citirea și parsarea input-ului utilizatorului
//
// Programul cere repetat un număr întreg și apoi un număr real, tratând separat
// fiecare tip de eroare de parsare (FormatException, OverflowException).
//
// Implicit, programul rulează în mod demonstrativ: răspunsurile utilizatorului
// sunt preluate dintr-o listă fixă și afișate după prompt, reproducând sesiunea
// din carte. Pentru introducerea valorilor de la tastatură, adăugați --interactiv.
//
// Rulare:
//   dotnet run --project csharp/cap07-gestionarea-erorilor/citirea-si-parsarea-input-ului-utilizatorului
//   dotnet run --project csharp/cap07-gestionarea-erorilor/citirea-si-parsarea-input-ului-utilizatorului -- --interactiv

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

bool interactiv = args.Contains("--interactiv");
Queue<string> raspunsuriDemo = new(["abc", "3.14", "42", "xyz", "3.14"]);

// Citește un răspuns: de la tastatură sau din lista demonstrativă.
// Sfârșitul intrării (ReadLine() returnează null) este semnalat printr-o excepție.
string CitesteRaspuns(string prompt)
{
    Console.Write(prompt);
    if (interactiv)
        return Console.ReadLine() ?? throw new EndOfStreamException();

    if (!raspunsuriDemo.TryDequeue(out string? raspuns))
        throw new EndOfStreamException();
    Console.WriteLine(raspuns);   // în modul demonstrativ afișăm „ce a tastat utilizatorul"
    return raspuns;
}

int CitesteIntreg()
{
    while (true)
    {
        string text = CitesteRaspuns("Introduceți un număr întreg: ");
        try
        {
            int valoare = int.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
            Console.WriteLine($"  Ați introdus: {valoare}");
            return valoare;
        }
        catch (FormatException)
        {
            Console.WriteLine($"  Eroare: \"{text}\" nu este un număr întreg valid.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"  Eroare: \"{text}\" depășește domeniul tipului int " +
                              $"({int.MinValue}…{int.MaxValue}).");
        }
    }
}

double CitesteReal()
{
    while (true)
    {
        string text = CitesteRaspuns("Introduceți un număr real: ");
        try
        {
            double valoare = double.Parse(text, NumberStyles.Float, CultureInfo.InvariantCulture);
            // Din .NET Core 3.0, double.Parse nu mai aruncă OverflowException pentru
            // valori prea mari, ci returnează ±Infinity; tratăm cazul explicit.
            if (!double.IsFinite(valoare))
                throw new OverflowException();
            Console.WriteLine($"  Ați introdus: {valoare}");
            return valoare;
        }
        catch (FormatException)
        {
            Console.WriteLine($"  Eroare: \"{text}\" nu este un număr real valid.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"  Eroare: \"{text}\" depășește domeniul tipului double.");
        }
    }
}

try
{
    int intreg = CitesteIntreg();
    double real = CitesteReal();
    Console.WriteLine();
    Console.WriteLine($"Rezultat: {intreg} × {real} = {intreg * real:0.##########}");
}
catch (EndOfStreamException)
{
    Console.WriteLine();
    Console.WriteLine("Intrarea s-a încheiat înainte ca ambele valori să fie introduse.");
}
