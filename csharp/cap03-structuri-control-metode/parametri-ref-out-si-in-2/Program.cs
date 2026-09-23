static bool Divide(int a, int b, out int cat, out int rest)
{
    if (b == 0)
    {
        cat = 0;
        rest = 0;
        return false;
    }

    cat = a / b;
    rest = a % b;
    return true;
}

if (Divide(17, 5, out int catul, out int restul))
{
    Console.WriteLine($"17 / 5 = {catul}, rest {restul}");
}
else
{
    Console.WriteLine("Împărțire la zero!");
}
