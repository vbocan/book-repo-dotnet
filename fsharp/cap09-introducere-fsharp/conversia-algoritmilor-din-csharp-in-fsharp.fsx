// Exercițiul 9.4 — Conversia algoritmilor din C# în F#
// Capitolul 9: Introducere în F#
// Rulare: dotnet fsi fsharp/cap09-introducere-fsharp/conversia-algoritmilor-din-csharp-in-fsharp.fsx

// Factorial recursiv; int64 pentru că 15! depășește domeniul lui int
let rec factorial (n: int) : int64 =
    if n <= 1 then 1L
    else int64 n * factorial (n - 1)

// Fibonacci cu acumulatori: apelul recursiv este ultima operație (tail call)
let fibonacci n =
    let rec loop i a b =
        if i = 0 then a
        else loop (i - 1) b (a + b)
    loop n 0 1

// Verificarea primalității prin încercarea divizorilor până la radical
let estePrim n =
    if n < 2 then false
    else
        let rec verifica d =
            if d * d > n then true
            elif n % d = 0 then false
            else verifica (d + 1)
        verifica 2

let numerePrimeSub limita =
    [ 2 .. limita - 1 ] |> List.filter estePrim

// Inversarea unui șir: tabloul de caractere inversat, reconstruit ca șir
let inverseaza (s: string) =
    System.String(s.ToCharArray() |> Array.rev)

printfn "=== Factorial ==="
for n in [ 0; 1; 5; 10; 15 ] do
    printfn $"  {n}! = {factorial n}"

printfn "\n=== Fibonacci ==="
for n in [ 0; 1; 5; 10; 20 ] do
    printfn $"  F({n}) = {fibonacci n}"

printfn "\n=== Numere prime ==="
let prime = numerePrimeSub 50
// %A afișează lista completă (interpolarea simplă ar trunchia-o la primele elemente)
printfn $"  Numere prime sub 50: %A{prime}"
printfn $"  Total: {List.length prime}"

printfn "\n=== Inversare șiruri ==="
for s in [ "abcdef"; "F#"; "programare" ] do
    printfn $"  \"{s}\" → \"{inverseaza s}\""
