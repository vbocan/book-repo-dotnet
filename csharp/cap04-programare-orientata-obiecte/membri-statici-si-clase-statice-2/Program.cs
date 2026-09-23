Console.WriteLine($"90° = {MathHelper.GradeLaRadiani(90):F4} rad");
Console.WriteLine($"π rad = {MathHelper.RadianiLaGrade(Math.PI):F1}°");

var (min, max) = MathHelper.GasesteExtreme(3.14, 2.71, 1.41, 1.73, 0.58);
Console.WriteLine($"Min: {min:F2}, Max: {max:F2}");

class MathHelper
{
    public static double RadianiLaGrade(double radiani) => radiani * 180.0 / Math.PI;

    public static double GradeLaRadiani(double grade) => grade * Math.PI / 180.0;

    public static (double min, double max) GasesteExtreme(params double[] valori)
    {
        if (valori.Length == 0)
            throw new ArgumentException("Tabloul nu poate fi gol.");

        double min = valori[0], max = valori[0];
        foreach (var v in valori)
        {
            if (v < min) min = v;
            if (v > max) max = v;
        }
        return (min, max);
    }
}
