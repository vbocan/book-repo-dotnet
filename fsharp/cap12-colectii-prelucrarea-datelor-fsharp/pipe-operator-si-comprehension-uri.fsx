// Exercițiul 4 - Pipe operator și comprehension-uri
// Capitolul 12 - Colecții și prelucrarea datelor în F#
// Rulare: dotnet fsi fsharp/cap12-colectii-prelucrarea-datelor-fsharp/pipe-operator-si-comprehension-uri.fsx

// Notele sub formă de tupluri (student, materie, notă)
let note =
    [ ("Ana", "Matematică", 9.0); ("Ana", "Fizică", 10.0); ("Ana", "Informatică", 10.0)
      ("Maria", "Matematică", 8.0); ("Maria", "Fizică", 9.0); ("Maria", "Informatică", 9.0)
      ("Ion", "Matematică", 7.0); ("Ion", "Fizică", 6.0); ("Ion", "Informatică", 8.0) ]

// Pipeline multi-pas: grupare după o cheie -> medie pe grup -> sortare descrescătoare
let mediiDupa cheie =
    note
    |> List.groupBy cheie
    |> List.map (fun (k, grup) -> k, grup |> List.averageBy (fun (_, _, nota) -> nota))
    |> List.sortByDescending snd

printfn "=== Medii pe studenți ==="
mediiDupa (fun (student, _, _) -> student)
|> List.iter (fun (student, medie) -> printfn "  %s: %.2f" student medie)

printfn "\n=== Medii pe materii ==="
mediiDupa (fun (_, materie, _) -> materie)
|> List.iter (fun (materie, medie) -> printfn "  %s: %.2f" materie medie)

// List comprehension imbricat: tabla înmulțirii ca listă de liste
let tabla = [ for i in 1..5 -> [ for j in 1..5 -> i * j ] ]

printfn "\n=== Tabla înmulțirii (1..5) ==="
for rand in tabla do
    rand |> List.map (sprintf "%3d") |> String.concat "" |> printfn "%s"

// Comprehension cu două generatoare: produsul cartezian culori × valori
let culori = [ "♠"; "♥"; "♦"; "♣" ]
let valori = [ "A"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"; "10"; "J"; "Q"; "K" ]

let pachet = [ for c in culori do for v in valori -> v + c ]

printfn "\nPachet complet (%d cărți):" pachet.Length
pachet
|> List.chunkBySize valori.Length
|> List.iter (fun rand ->
    let linie = rand |> List.map (sprintf "%-5s") |> String.concat ""
    printfn "%s" (linie.TrimEnd()))
