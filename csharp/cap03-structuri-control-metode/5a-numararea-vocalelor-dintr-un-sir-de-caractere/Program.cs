static int NumaraVocale(string text)
{
    int contor = 0;
    string vocale = "aeiouăâîAEIOUĂÂÎ";

    foreach (char c in text)
    {
        if (vocale.Contains(c))
        {
            contor++;
        }
    }
    return contor;
}

Console.WriteLine($"NumaraVocale(\"Programare\") = {NumaraVocale("Programare")}");
Console.WriteLine($"NumaraVocale(\"Universitatea Politehnica\") = {NumaraVocale("Universitatea Politehnica")}");
Console.WriteLine($"NumaraVocale(\"xyz\") = {NumaraVocale("xyz")}");
Console.WriteLine($"NumaraVocale(\"România\") = {NumaraVocale("România")}");
