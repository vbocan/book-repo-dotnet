Console.WriteLine($"ParseSauZero(\"42\") = {int.ParseSauZero("42")}");
Console.WriteLine($"ParseSauZero(\"abc\") = {int.ParseSauZero("abc")}");

static class IntFactory
{
    extension(int)   // membri statici — doar tipul receptor
    {
        public static int ParseSauZero(string s) =>
            int.TryParse(s, out int v) ? v : 0;
    }
}
