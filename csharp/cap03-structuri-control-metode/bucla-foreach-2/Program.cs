string text = "Salut";
int contorVocale = 0;

foreach (char c in text.ToLower())
{
    if ("aeiouăâî".Contains(c))
    {
        contorVocale++;
    }
}

Console.WriteLine($"Textul \"{text}\" conține {contorVocale} vocale.");
