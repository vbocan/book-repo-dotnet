// Capitolul 7 - Gestionarea erorilor și excepțiilor
// Exercițiul 3 - Excepții personalizate pentru un domeniu bancar
//
// Ierarhia de excepții:
//   ContBancarException                 (baza; păstrează IBAN-ul)
//   ├── SoldInsuficientException        (sold curent, sumă solicitată, diferență)
//   ├── ContInactivException
//   └── LimitaZilnicaDepasitaException  (limită, sumă tranzacționată, sumă disponibilă)
//
// Rulare: dotnet run --project csharp/cap07-gestionarea-erorilor/exceptii-personalizate-pentru-un-domeniu-bancar

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var cont = new ContBancar("RO49AAAA1B31007593840000", "Maria Ionescu", 3000m, limitaZilnica: 2000m);
Console.WriteLine(cont);
Console.WriteLine();

void Depunere(decimal suma)
{
    cont.Depune(suma);
    Console.WriteLine($"  + Depunere {suma:F2} lei → sold: {cont.Sold:F2} lei");
}

void Retragere(decimal suma)
{
    cont.Retrage(suma);
    Console.WriteLine($"  - Retragere {suma:F2} lei → sold: {cont.Sold:F2} lei");
}

Depunere(1000m);
Retragere(500m);
Retragere(1000m);

Console.WriteLine();
Console.WriteLine($"Încercare retragere 600 lei (limita zilnică: {cont.LimitaZilnica} lei):");
try
{
    cont.Retrage(600m);
}
catch (LimitaZilnicaDepasitaException ex)
{
    Console.WriteLine($"  Eroare: {ex.Message}");
    Console.WriteLine($"  Mai puteți retrage azi: {ex.SumaDisponibila:F2} lei");
}

Console.WriteLine();
Console.WriteLine("Încercare retragere 5000 lei:");
try
{
    cont.Retrage(5000m);
}
catch (SoldInsuficientException ex)
{
    Console.WriteLine($"  Eroare: {ex.Message}");
    Console.WriteLine($"  Diferență: {ex.SumaSolicitata - ex.SoldCurent:F2} lei");
}

Console.WriteLine();
cont.Dezactiveaza();
Console.WriteLine("Cont dezactivat. Încercare depunere:");
try
{
    cont.Depune(100m);
}
catch (ContBancarException ex)   // prinde orice eroare de domeniu, inclusiv ContInactivException
{
    Console.WriteLine($"  Eroare: {ex.Message}");
}

// ===== Contul bancar =====

class ContBancar(string iban, string titular, decimal soldInitial, decimal limitaZilnica)
{
    public string Iban { get; } = iban;
    public string Titular { get; } = titular;
    public decimal Sold { get; private set; } = soldInitial;
    public bool Activ { get; private set; } = true;
    public decimal LimitaZilnica { get; } = limitaZilnica;

    // Suma retrasă în ziua curentă. Pentru un rezultat reproductibil, exemplul
    // simulează o singură zi; o implementare reală ar reseta contorul la schimbarea datei.
    public decimal RetrasAzi { get; private set; }

    public void Depune(decimal suma)
    {
        VerificaSuma(suma);
        VerificaActiv();
        Sold += suma;
    }

    public void Retrage(decimal suma)
    {
        VerificaSuma(suma);
        VerificaActiv();
        if (suma > Sold)
            throw new SoldInsuficientException(Iban, Sold, suma);
        if (RetrasAzi + suma > LimitaZilnica)
            throw new LimitaZilnicaDepasitaException(Iban, LimitaZilnica, RetrasAzi, suma);

        Sold -= suma;
        RetrasAzi += suma;
    }

    public void Dezactiveaza() => Activ = false;

    private static void VerificaSuma(decimal suma)
    {
        if (suma <= 0)
            throw new ArgumentOutOfRangeException(nameof(suma), suma, "Suma trebuie să fie pozitivă.");
    }

    private void VerificaActiv()
    {
        if (!Activ)
            throw new ContInactivException(Iban);
    }

    public override string ToString() =>
        $"Cont: {Titular} ({Iban}) — sold: {Sold:F2} lei, activ: {(Activ ? "da" : "nu")}";
}

// ===== Excepțiile de domeniu =====

class ContBancarException : Exception
{
    public string? Iban { get; }

    public ContBancarException()
        : base("Operație invalidă pe cont bancar.") { }

    public ContBancarException(string message)
        : base(message) { }

    public ContBancarException(string message, Exception innerException)
        : base(message, innerException) { }

    public ContBancarException(string iban, string message)
        : base(message)
    {
        Iban = iban;
    }
}

class SoldInsuficientException(string iban, decimal soldCurent, decimal sumaSolicitata)
    : ContBancarException(iban,
        $"Sold insuficient: disponibil {soldCurent:F2} lei, solicitat {sumaSolicitata:F2} lei.")
{
    public decimal SoldCurent { get; } = soldCurent;
    public decimal SumaSolicitata { get; } = sumaSolicitata;
}

class ContInactivException(string iban)
    : ContBancarException(iban, $"Contul {iban} este inactiv. Operațiunile nu sunt permise.");

class LimitaZilnicaDepasitaException(string iban, decimal limita, decimal tranzactionatAzi,
                                     decimal sumaSolicitata)
    : ContBancarException(iban,
        $"Limita zilnică depășită: limita {limita:F2} lei, tranzacționat azi {tranzactionatAzi:F2} lei, " +
        $"solicitat {sumaSolicitata:F2} lei.")
{
    public decimal Limita { get; } = limita;
    public decimal TranzactionatAzi { get; } = tranzactionatAzi;
    public decimal SumaSolicitata { get; } = sumaSolicitata;
    public decimal SumaDisponibila => Limita - TranzactionatAzi;
}
