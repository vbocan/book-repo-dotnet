static void TransferaFonduri(string contSursa, string contDestinatie, decimal suma)
{
    ArgumentException.ThrowIfNullOrWhiteSpace(contSursa);
    ArgumentException.ThrowIfNullOrWhiteSpace(contDestinatie);

    if (suma <= 0)
        throw new ArgumentOutOfRangeException(
            nameof(suma), suma, "Suma trebuie să fie pozitivă.");

    if (contSursa == contDestinatie)
        throw new ArgumentException(
            "Contul sursă și contul destinație nu pot fi identice.",
            nameof(contSursa));

    Console.WriteLine($"Transfer {suma:F2} lei din {contSursa} în {contDestinatie}");
}

try
{
    TransferaFonduri("RO49AAAA1B31007593840000", "RO49AAAA1C41007593840001", 500m);
    TransferaFonduri("RO49AAAA1B31007593840000", "RO49AAAA1C41007593840001", -100m);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Eroare: {ex.Message}");
}
