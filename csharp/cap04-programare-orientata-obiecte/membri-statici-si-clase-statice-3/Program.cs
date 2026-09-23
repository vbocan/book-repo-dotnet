Console.WriteLine($"25°C = {Conversii.CelsiusLaFahrenheit(25):F1}°F");
Console.WriteLine($"98.6°F = {Conversii.FahrenheitLaCelsius(98.6):F1}°C");
Console.WriteLine($"100 km = {Conversii.KmLaMile(100):F2} mile");

static class Conversii
{
    public static double CelsiusLaFahrenheit(double celsius) =>
        celsius * 9.0 / 5.0 + 32;

    public static double FahrenheitLaCelsius(double fahrenheit) =>
        (fahrenheit - 32) * 5.0 / 9.0;

    public static double KmLaMile(double km) => km * 0.621371;

    public static double MileLaKm(double mile) => mile * 1.60934;
}
