#nullable enable

string nume = "Ion";     // non-nullable — compilatorul garantează că nu e null
string? prenume = null;  // nullable — poate fi null

// Compilatorul emite avertisment dacă folosiți prenume fără verificare
// Console.WriteLine(prenume.Length);  // Avertisment CS8602

// Varianta corectă — verificare înainte de acces
if (prenume != null)
{
    Console.WriteLine($"Prenumele are {prenume.Length} caractere.");
}

// Sau cu operatorul ?. (null-conditional)
Console.WriteLine($"Lungime prenume: {prenume?.Length ?? 0}");

// Operatorul ! (null-forgiving) suprimă avertismentul
// Folosiți-l doar când ȘTIȚI că valoarea nu e null
prenume = "Vasile";
Console.WriteLine($"Prenume: {prenume!.ToUpper()}");
