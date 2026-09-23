string text = "Programare orientată pe obiecte în C#";
Console.WriteLine($"Text: \"{text}\"");
Console.WriteLine($"Număr cuvinte: {text.NumarCuvinte}");
Console.WriteLine($"Inversat: \"{text.Inversat}\"");
Console.WriteLine($"Trunchiat: \"{text.Trunchiaza(20)}\"");

Console.WriteLine();

string email1 = "student@example.com";
string email2 = "invalid-email";
Console.WriteLine($"\"{email1}\" este email? {email1.EsteEmail()}");
Console.WriteLine($"\"{email2}\" este email? {email2.EsteEmail()}");

static class StringExtensions
{
    extension(string s)
    {
        public int NumarCuvinte =>
            s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        public string Inversat
        {
            get
            {
                char[] caractere = s.ToCharArray();
                Array.Reverse(caractere);
                return new string(caractere);
            }
        }

        public string Trunchiaza(int lungimeMaxima)
        {
            if (s.Length <= lungimeMaxima) return s;
            return s[..lungimeMaxima] + "…";
        }

        public bool EsteEmail()
        {
            int indexAt = s.IndexOf('@');
            if (indexAt <= 0 || indexAt >= s.Length - 1) return false;
            int indexPunct = s.LastIndexOf('.');
            return indexPunct > indexAt + 1 && indexPunct < s.Length - 1;
        }
    }
}
