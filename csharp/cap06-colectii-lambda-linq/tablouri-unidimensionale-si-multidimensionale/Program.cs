// Declarare și inițializare separată
int[] note = new int[5];
note[0] = 10;
note[1] = 8;
note[2] = 9;
note[3] = 7;
note[4] = 10;

// Inițializare directă cu valori
string[] studenti = ["Ana", "Ion", "Maria", "Vlad", "Elena"];

// Parcurgerea tabloului
for (int i = 0; i < studenti.Length; i++)
{
    Console.WriteLine($"{studenti[i]}: nota {note[i]}");
}
Console.WriteLine($"Număr studenți: {studenti.Length}");
