// Capitolul 5 - Moștenire, interfețe și polimorfism
// Exercițiul 4 - Membri de extensie pentru tipuri fundamentale
//
// Blocuri extension (C# 14) care adaugă proprietăți și metode tipurilor
// int, string și DateTime.
//
// Notă: vârsta se calculează față de data curentă (DateTime.Today), deci
// ultima linie depinde de momentul rulării, așa cum precizează și cartea.
//
// Rulare: dotnet run --project csharp/cap05-mostenire-interfete-polimorfism/membri-de-extensie-pentru-tipuri-fundamentale

Console.WriteLine("=== Extensii int ===");
for (int i = 0; i <= 5; i++)
{
    Console.WriteLine($"{i} în cuvinte: {i.InCuvinte}");
}
Console.WriteLine($"8 este între 1 și 10? {8.EsteIntre(1, 10)}");
Console.WriteLine($"25 este între 1 și 10? {25.EsteIntre(1, 10)}");

Console.WriteLine();
Console.WriteLine("=== Extensii string ===");
string text = "programare orientată pe obiecte";
Console.WriteLine($"Original: \"{text}\"");
Console.WriteLine($"Capitalizat: \"{text.Capitalizat}\"");
Console.WriteLine($"Număr vocale: {text.NumarVocale}");

Console.WriteLine();
Console.WriteLine("=== Extensii DateTime ===");
var dataNasterii = new DateTime(2003, 7, 15);
Console.WriteLine($"Data nașterii: {dataNasterii.FormatRomanesc}");
Console.WriteLine($"Vârsta: {dataNasterii.Varsta} ani");

static class IntExtensions
{
    private static readonly string[] Cuvinte =
        ["zero", "unu", "doi", "trei", "patru", "cinci", "șase", "șapte", "opt", "nouă", "zece"];

    extension(int n)
    {
        // Proprietate de extensie: numerele 0-10 scrise în cuvinte
        public string InCuvinte =>
            n >= 0 && n < Cuvinte.Length ? Cuvinte[n] : n.ToString();

        public bool EsteIntre(int minim, int maxim) => n >= minim && n <= maxim;
    }
}

static class StringExtensions
{
    private const string Vocale = "aeiouăâîAEIOUĂÂÎ";

    extension(string s)
    {
        // Prima literă majusculă, restul textului neschimbat
        public string Capitalizat =>
            s.Length == 0 ? s : char.ToUpper(s[0]) + s[1..];

        public int NumarVocale
        {
            get
            {
                int numar = 0;
                foreach (char c in s)
                {
                    if (Vocale.Contains(c)) numar++;
                }
                return numar;
            }
        }
    }
}

static class DateTimeExtensions
{
    private static readonly string[] Luni =
        ["ianuarie", "februarie", "martie", "aprilie", "mai", "iunie",
         "iulie", "august", "septembrie", "octombrie", "noiembrie", "decembrie"];

    extension(DateTime data)
    {
        // Formatare cu numele lunii în română, independentă de cultura sistemului
        public string FormatRomanesc => $"{data.Day} {Luni[data.Month - 1]} {data.Year}";

        // Vârsta în ani împliniți, față de data curentă
        public int Varsta
        {
            get
            {
                DateTime azi = DateTime.Today;
                int varsta = azi.Year - data.Year;
                if (data.Date > azi.AddYears(-varsta)) varsta--;   // ziua de naștere nu a trecut încă
                return varsta;
            }
        }
    }
}
