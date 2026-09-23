var punct = new Punct2D(3, 4);
Console.WriteLine($"Punct: {punct}, distanța la origine: {punct.DistantaOrigine():F2}");

struct Punct2D(double x, double y)
{
    public double X { get; } = x;
    public double Y { get; } = y;

    public double DistantaOrigine() => Math.Sqrt(X * X + Y * Y);

    public override string ToString() => $"({X:F1}, {Y:F1})";
}
