static T Maxim<T>(T a, T b) where T : IComparable<T>
{
    return a.CompareTo(b) >= 0 ? a : b;
}

Console.WriteLine(Maxim(10, 25));
Console.WriteLine(Maxim("abc", "xyz"));
Console.WriteLine(Maxim(3.14, 2.71));
