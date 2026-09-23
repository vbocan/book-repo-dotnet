using System.Text;
using System.Diagnostics;

// Comparație de performanță: string vs StringBuilder
const int N = 100_000;

// Varianta cu string (lentă)
Stopwatch sw = Stopwatch.StartNew();
string rezultat = "";
for (int i = 0; i < N; i++)
    rezultat += "a";
sw.Stop();
Console.WriteLine($"String concatenation: {sw.ElapsedMilliseconds} ms, lungime: {rezultat.Length}");

// Varianta cu StringBuilder (rapidă)
sw.Restart();
StringBuilder sb = new StringBuilder();
for (int i = 0; i < N; i++)
    sb.Append('a');
string rezultat2 = sb.ToString();
sw.Stop();
Console.WriteLine($"StringBuilder: {sw.ElapsedMilliseconds} ms, lungime: {rezultat2.Length}");
