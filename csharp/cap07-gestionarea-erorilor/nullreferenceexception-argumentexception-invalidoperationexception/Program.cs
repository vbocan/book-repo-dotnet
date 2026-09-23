string? text = null;

try
{
    int lungime = text.Length; // NullReferenceException!
}
catch (NullReferenceException ex)
{
    Console.WriteLine($"Excepție: {ex.GetType().Name}");
    Console.WriteLine($"Mesaj: {ex.Message}");
}
