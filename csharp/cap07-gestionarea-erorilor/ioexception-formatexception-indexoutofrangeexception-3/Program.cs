string input = "abc";

if (int.TryParse(input, out int rezultat))
{
    Console.WriteLine($"Parsare reușită: {rezultat}");
}
else
{
    Console.WriteLine($"Nu s-a putut parsa \"{input}\" ca număr întreg.");
}
