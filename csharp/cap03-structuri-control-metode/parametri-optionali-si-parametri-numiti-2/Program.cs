static void CreazaCont(string nume, string email, string rol = "utilizator")
{
    Console.WriteLine($"Cont creat: {nume}, {email}, rol: {rol}");
}

// Apel standard
CreazaCont("Maria Ionescu", "maria@exemplu.ro");

// Apel cu parametri numiți — ordinea nu contează
CreazaCont(email: "andrei@exemplu.ro", nume: "Andrei Popescu", rol: "admin");

// Combinat: argumente poziționale + numite
CreazaCont("Elena Popa", "elena@exemplu.ro", rol: "moderator");
