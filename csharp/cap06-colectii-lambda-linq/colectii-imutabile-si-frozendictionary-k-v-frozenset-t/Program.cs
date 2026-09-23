using System.Collections.Immutable;

ImmutableList<string> limbi = ["Română", "Engleză", "Franceză"];

// Adăugarea returnează o nouă listă — originala rămâne neschimbată
ImmutableList<string> limbiExtinse = limbi.Add("Germană");

Console.WriteLine($"Original: {string.Join(", ", limbi)}");
Console.WriteLine($"Extins: {string.Join(", ", limbiExtinse)}");
