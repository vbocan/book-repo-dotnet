// C# — stil imperativ cu stare mutabilă
int[] numere = [1, 2, 3, 4, 5];
int suma = 0;
for (int i = 0; i < numere.Length; i++)
{
    suma += numere[i];  // modifică variabila suma la fiecare iterație
}
Console.WriteLine($"Suma: {suma}");
