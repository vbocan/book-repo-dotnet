try
{
    int numarMare = 300;
    byte numarMic = checked((byte)numarMare);
    Console.WriteLine($"Rezultat: {numarMic}");
}
catch (OverflowException ex)
{
    Console.WriteLine($"Depășire detectată: {ex.Message}");
}
