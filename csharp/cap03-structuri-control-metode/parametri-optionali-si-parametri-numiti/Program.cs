static void AfiseazaMesaj(string mesaj, int repetitii = 1, string separator = " | ")
{
    for (int i = 0; i < repetitii; i++)
    {
        if (i > 0) Console.Write(separator);
        Console.Write(mesaj);
    }
    Console.WriteLine();
}

AfiseazaMesaj("Salut");
AfiseazaMesaj("Test", 3);
AfiseazaMesaj("OK", 4, " - ");
