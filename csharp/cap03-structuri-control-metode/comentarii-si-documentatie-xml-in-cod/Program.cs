/// <summary>
/// Calculează indicele de masă corporală (IMC) pe baza greutății și înălțimii.
/// </summary>
/// <param name="greutateKg">Greutatea persoanei în kilograme.</param>
/// <param name="inaltimeM">Înălțimea persoanei în metri.</param>
/// <returns>Valoarea IMC ca număr real.</returns>
/// <example>
/// <code>
/// double imc = CalculeazaIMC(75, 1.80);
/// Console.WriteLine(imc); // 23.148148148148145
/// </code>
/// </example>
static double CalculeazaIMC(double greutateKg, double inaltimeM)
{
    if (inaltimeM <= 0)
        throw new ArgumentException("Înălțimea trebuie să fie pozitivă.", nameof(inaltimeM));

    return greutateKg / (inaltimeM * inaltimeM);
}

double imc = CalculeazaIMC(75, 1.80);
string categorie = imc switch
{
    < 18.5 => "Subponderal",
    < 25 => "Normal",
    < 30 => "Supraponderal",
    _ => "Obezitate"
};

Console.WriteLine($"IMC: {imc:F2} — {categorie}");
