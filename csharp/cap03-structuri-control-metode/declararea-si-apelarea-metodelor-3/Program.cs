static double CalculeazaAriaDreptunghi(double lungime, double latime)
{
    return lungime * latime;
}

static double CalculeazaPerimetruDreptunghi(double lungime, double latime)
{
    return 2 * (lungime + latime);
}

static void AfiseazaInfoDreptunghi(double lungime, double latime)
{
    double aria = CalculeazaAriaDreptunghi(lungime, latime);
    double perimetru = CalculeazaPerimetruDreptunghi(lungime, latime);

    Console.WriteLine($"Dreptunghi {lungime} x {latime}:");
    Console.WriteLine($"  Aria = {aria:F2}");
    Console.WriteLine($"  Perimetrul = {perimetru:F2}");
}

AfiseazaInfoDreptunghi(10, 5);
AfiseazaInfoDreptunghi(3.5, 2.8);
