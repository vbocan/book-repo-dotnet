Console.WriteLine("Punctul de fierbere al apei:");
Console.WriteLine($"  {Temperatura.DinCelsius(100)}");

Console.WriteLine("Temperatura corpului uman:");
Console.WriteLine($"  {Temperatura.DinFahrenheit(98.6)}");

Console.WriteLine("Zero absolut:");
Console.WriteLine($"  {Temperatura.DinKelvin(0)}");

Console.WriteLine("O zi caldă de vară:");
Console.WriteLine($"  {Temperatura.DinCelsius(35)}");

class Temperatura
{
    public double Celsius { get; private set; }

    public double Fahrenheit => Celsius * 9.0 / 5.0 + 32;

    public double Kelvin => Celsius + 273.15;

    private Temperatura(double celsius)
    {
        Celsius = celsius;
    }

    // Factory methods
    public static Temperatura DinCelsius(double celsius) => new(celsius);

    public static Temperatura DinFahrenheit(double fahrenheit) =>
        new((fahrenheit - 32) * 5.0 / 9.0);

    public static Temperatura DinKelvin(double kelvin)
    {
        if (kelvin < 0)
            throw new ArgumentOutOfRangeException(nameof(kelvin),
                "Temperatura nu poate fi sub zero absolut.");
        return new(kelvin - 273.15);
    }

    public override string ToString() =>
        $"{Celsius:F1}°C / {Fahrenheit:F1}°F / {Kelvin:F1}K";
}
