// Exercițiul 9.3 — Tipul Option și funcții sigure
// Capitolul 9: Introducere în F#
// Rulare: dotnet fsi fsharp/cap09-introducere-fsharp/tipul-option-si-functii-sigure.fsx

// Împărțire sigură: None la împărțirea cu zero, în loc de excepție
let imparteSigur a b =
    if b = 0 then None
    else Some(a / b)

// Căutare sigură: List.tryFind returnează Some element sau None
let cautaSigur element lista =
    lista |> List.tryFind (fun x -> x = element)

// Primul element, fără excepție pentru lista goală
let primulSigur lista =
    match lista with
    | [] -> None
    | primul :: _ -> Some primul

// Afișarea unei valori opționale prin pattern matching.
// Interpolarea simplă ({opt}) ar apela ToString(), care pentru None produce un șir gol.
let descrieOptiune opt =
    match opt with
    | Some valoare -> $"Some({valoare})"
    | None -> "None"

printfn "=== Tipul Option ==="
for (a, b) in [ (10, 3); (15, 5); (7, 0) ] do
    match imparteSigur a b with
    | Some rezultat -> printfn $"  {a} / {b} = {rezultat}"
    | None -> printfn $"  {a} / {b} = imposibil (împărțire la zero)"

printfn "\n--- Căutare în listă ---"
let fructe = [ "măr"; "pară"; "cireașă"; "prună" ]
for fruct in [ "cireașă"; "banană" ] do
    match cautaSigur fruct fructe with
    | Some _ -> printfn $"  \"{fruct}\" găsit în listă"
    | None -> printfn $"  \"{fruct}\" nu există în listă"

printfn "\n--- Primul element ---"
let afiseazaPrimul (lista: int list) =
    match primulSigur lista with
    | Some primul -> printfn $"  Primul: {primul}"
    | None -> printfn "  Lista este goală!"

afiseazaPrimul [ 7; 3; 9 ]
afiseazaPrimul []

printfn "\n--- Funcții Option ---"
let valoare = Some 9
let absenta: int option = None

printfn $"  defaultValue 0 (Some 9) = {Option.defaultValue 0 valoare}"
printfn $"  defaultValue 0 None = {Option.defaultValue 0 absenta}"
printfn "  map (*2) (Some 9) = %s" (descrieOptiune (Option.map (fun x -> x * 2) valoare))
printfn "  map (*2) None = %s" (descrieOptiune (Option.map (fun x -> x * 2) absenta))
