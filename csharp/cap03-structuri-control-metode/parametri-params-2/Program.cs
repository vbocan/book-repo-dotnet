static void AfiseazaLista(string titlu, params string[] elemente)
{
    Console.WriteLine($"{titlu}:");
    for (int i = 0; i < elemente.Length; i++)
    {
        Console.WriteLine($"  {i + 1}. {elemente[i]}");
    }
}

AfiseazaLista("Limbaje de programare", "C#", "F#", "Python", "Java");
AfiseazaLista("Culori primare", "Roșu", "Verde", "Albastru");
