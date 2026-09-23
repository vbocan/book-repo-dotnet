Stack<string> istoricPagini = new();
istoricPagini.Push("Pagina principală");
istoricPagini.Push("Catalog produse");
istoricPagini.Push("Detalii produs");
istoricPagini.Push("Coș de cumpărături");

Console.WriteLine($"Pagina curentă: {istoricPagini.Peek()}");
Console.WriteLine("Navigare înapoi:");

while (istoricPagini.Count > 1)
{
    string pagina = istoricPagini.Pop();
    Console.WriteLine($"  Părăsesc: {pagina}");
    Console.WriteLine($"  Revin la: {istoricPagini.Peek()}");
}
