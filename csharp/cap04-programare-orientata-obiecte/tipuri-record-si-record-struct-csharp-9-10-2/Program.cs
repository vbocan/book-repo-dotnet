var timisoara = new Coordonate(45.7489, 21.2087);
var bucuresti = timisoara with { Latitudine = 44.4268, Longitudine = 26.1025 };
var altPunctTimisoara = timisoara with { Longitudine = 21.2200 };

Console.WriteLine($"Timișoara: {timisoara}");
Console.WriteLine($"București: {bucuresti}");
Console.WriteLine($"Alt punct: {altPunctTimisoara}");

public record Coordonate(double Latitudine, double Longitudine);
