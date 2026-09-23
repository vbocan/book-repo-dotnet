string[] valori = ["42", "3.14", "abc", "", "99"];

foreach (string val in valori)
{
    try
    {
        int numar = int.Parse(val);
        Console.WriteLine($"\"{val}\" → {numar}");
    }
    catch (FormatException)
    {
        Console.WriteLine($"\"{val}\" → format invalid");
    }
}
