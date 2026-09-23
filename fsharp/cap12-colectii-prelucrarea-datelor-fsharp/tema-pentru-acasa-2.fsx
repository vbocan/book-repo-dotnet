// Temă pentru acasă, Tema 2 - Operații pe matrice (codul prezentat în carte)
// Capitolul 12 - Colecții și prelucrarea datelor în F#
// Rulare: dotnet fsi fsharp/cap12-colectii-prelucrarea-datelor-fsharp/tema-pentru-acasa-2.fsx

// Tipul matrice: tablou de tablouri
type Matrice = float array array

let afiseazaMatrice (nume: string) (m: Matrice) =
    printfn "%s:" nume
    for rand in m do
        rand |> Array.iter (fun v -> printf "%8.1f" v)
        printfn ""
    printfn ""

let transpune (m: Matrice) : Matrice =
    let randuri = m.Length
    let coloane = m[0].Length
    [| for j in 0 .. coloane - 1 ->
           [| for i in 0 .. randuri - 1 -> m[i][j] |] |]

let inmulteste (a: Matrice) (b: Matrice) : Matrice =
    let randuri = a.Length
    let coloane = b[0].Length
    let k = a[0].Length
    [| for i in 0 .. randuri - 1 ->
           [| for j in 0 .. coloane - 1 ->
                  Array.init k (fun p -> a[i][p] * b[p][j]) |> Array.sum |] |]

let a: Matrice = [| [| 1.0; 2.0; 3.0 |]; [| 4.0; 5.0; 6.0 |] |]
let b: Matrice = [| [| 7.0; 8.0 |]; [| 9.0; 10.0 |]; [| 11.0; 12.0 |] |]

afiseazaMatrice "A (2×3)" a
afiseazaMatrice "Transpusa A (3×2)" (transpune a)
afiseazaMatrice "B (3×2)" b
afiseazaMatrice "A × B (2×2)" (inmulteste a b)

// Verificare: A × I = A
let identitate: Matrice = [| [| 1.0; 0.0; 0.0 |]; [| 0.0; 1.0; 0.0 |]; [| 0.0; 0.0; 1.0 |] |]
afiseazaMatrice "A × I (trebuie = A)" (inmulteste a identitate)
