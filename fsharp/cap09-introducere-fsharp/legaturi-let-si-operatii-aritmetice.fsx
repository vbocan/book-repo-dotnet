// Exercițiul 9.1 — Legături let și operații aritmetice

// Valori de diferite tipuri
let nume = "Programare .NET"     // string
let an = 2026                    // int
let pi = 3.14159                 // float (System.Double)
let activ = true                 // bool

// Operații aritmetice
let a = 17
let b = 5
let suma = a + b
let diferenta = a - b
let produs = a * b
let cat = a / b          // împărțire întreagă
let rest = a % b

printfn "=== Legături let și aritmetică ==="
printfn $"Curs: {nume}, An: {an}"
printfn "pi = %g, activ = %b" pi activ
printfn $"{a} + {b} = {suma}"
printfn $"{a} - {b} = {diferenta}"
printfn $"{a} * {b} = {produs}"
printfn $"{a} / {b} = {cat} (rest {rest})"

// Conversii explicite
let x = 7
let y = float x + 0.5
printfn $"\nConversie: int {x} -> float {y}"

// Operații cu șiruri
let prenume = "Ana"
let mesaj = $"Bună ziua, {prenume}! Bine ați venit la cursul de {nume}."
printfn $"\n{mesaj}"
printfn $"Lungime mesaj: {mesaj.Length} caractere"
printfn $"Majuscule: {prenume.ToUpper()}"
