static void AfiseazaMesaj(string mesaj)
{
    Console.WriteLine(mesaj);
}

static void AfiseazaSuma(int a, int b)
{
    int suma = a + b;
    Console.WriteLine($"Suma numerelor {a} și {b} este: {suma}");
}

// Testare
AfiseazaMesaj("Bun venit la Laboratorul 3!");
AfiseazaSuma(15, 27);
AfiseazaSuma(100, -30);
