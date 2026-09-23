var salut = new Salut("Bună ziua!", 3);
salut.Executa();

class Salut(string mesaj, int repetitii)
{
    public void Executa()
    {
        for (int i = 0; i < repetitii; i++)
        {
            Console.WriteLine(mesaj);
        }
    }
}
