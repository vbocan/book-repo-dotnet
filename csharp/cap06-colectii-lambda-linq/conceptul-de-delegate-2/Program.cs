static void TrimiteEmail(string mesaj) =>
    Console.WriteLine($"  [Email] {mesaj}");

static void TrimiteSMS(string mesaj) =>
    Console.WriteLine($"  [SMS] {mesaj}");

static void ScrieInLog(string mesaj) =>
    Console.WriteLine($"  [Log] {mesaj}");

NotificareEveniment notificare = TrimiteEmail;
notificare += TrimiteSMS;
notificare += ScrieInLog;

Console.WriteLine("Trimitere notificări:");
notificare("Comanda a fost procesată.");

Console.WriteLine("\nDupă eliminarea SMS:");
notificare -= TrimiteSMS;
notificare?.Invoke("Livrare confirmată.");  // după -=, delegatul poate deveni null

delegate void NotificareEveniment(string mesaj);
