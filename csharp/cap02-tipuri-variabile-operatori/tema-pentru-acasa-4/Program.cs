// Tema 4: Suma cifrelor
int numar = 9473;
int copie = numar;
int sumaCifrelor = 0;

while (copie > 0)
{
    sumaCifrelor += copie % 10;   // extrage ultima cifră
    copie /= 10;                   // elimină ultima cifră
}

Console.WriteLine($"Suma cifrelor lui {numar}: {sumaCifrelor}");
// Verificare: 9 + 4 + 7 + 3 = 23
