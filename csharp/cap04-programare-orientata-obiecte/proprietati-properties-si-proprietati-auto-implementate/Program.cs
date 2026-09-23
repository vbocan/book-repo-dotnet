var dreptunghi = new Dreptunghi();
dreptunghi.Lungime = 10;
dreptunghi.Latime = 5;

Console.WriteLine($"Dreptunghi: {dreptunghi.Lungime} × {dreptunghi.Latime}");
Console.WriteLine($"Aria: {dreptunghi.Arie}");
Console.WriteLine($"Perimetrul: {dreptunghi.Perimetru}");

class Dreptunghi
{
    private double _lungime;
    private double _latime;

    public double Lungime
    {
        get { return _lungime; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Lungime),
                    "Lungimea trebuie să fie pozitivă.");
            _lungime = value;
        }
    }

    public double Latime
    {
        get { return _latime; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Latime),
                    "Lățimea trebuie să fie pozitivă.");
            _latime = value;
        }
    }

    public double Arie => _lungime * _latime; // proprietate calculată (read-only)

    public double Perimetru => 2 * (_lungime + _latime);
}
