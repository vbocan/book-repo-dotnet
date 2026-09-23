// Tema 2 — Evaluator de expresii
// Capitolul 11: Tipuri algebrice în F#
// Rulare: dotnet fsi fsharp/cap11-tipuri-algebrice-fsharp/tema-pentru-acasa-2.fsx

type Expr =
    | Numar of float
    | Adunare of Expr * Expr
    | Inmultire of Expr * Expr
    | Negare of Expr

let rec evalueaza expr =
    match expr with
    | Numar n -> n
    | Adunare(s, d) -> evalueaza s + evalueaza d
    | Inmultire(s, d) -> evalueaza s * evalueaza d
    | Negare e -> -(evalueaza e)

let rec afiseaza expr =
    match expr with
    | Numar n -> $"{n}"
    | Adunare(s, d) -> $"({afiseaza s} + {afiseaza d})"
    | Inmultire(s, d) -> $"({afiseaza s} * {afiseaza d})"
    | Negare e -> $"(-{afiseaza e})"

// Simplificare: întâi subexpresiile, apoi regulile aplicate nodului curent
let rec simplifica expr =
    match expr with
    | Numar _ -> expr
    | Adunare(s, d) ->
        match simplifica s, simplifica d with
        | Numar 0.0, e
        | e, Numar 0.0 -> e // 0 + e = e + 0 = e
        | s', d' -> Adunare(s', d')
    | Inmultire(s, d) ->
        // Înmulțirea cu 0 produce 0 fără a mai simplifica celălalt operand
        match s, d with
        | Numar 0.0, _
        | _, Numar 0.0 -> Numar 0.0
        | _ ->
            match simplifica s, simplifica d with
            | Numar 0.0, _
            | _, Numar 0.0 -> Numar 0.0
            | Numar 1.0, e
            | e, Numar 1.0 -> e // 1 * e = e * 1 = e
            | s', d' -> Inmultire(s', d')
    | Negare e ->
        match simplifica e with
        | Negare interior -> interior // -(-e) = e
        | e' -> Negare e'

let expresii =
    [ Adunare(Numar 3.0, Inmultire(Numar 4.0, Numar 5.0))
      Inmultire(Adunare(Numar 2.0, Numar 3.0), Negare(Numar 4.0))
      Adunare(Numar 0.0, Inmultire(Numar 1.0, Numar 7.0))
      Inmultire(Numar 0.0, Adunare(Numar 100.0, Numar 200.0))
      Negare(Negare(Numar 42.0)) ]

printfn "=== Evaluator de expresii ==="
for e in expresii do
    printfn "  %s = %.1f" (afiseaza e) (evalueaza e)
    let simplificata = simplifica e
    // Egalitatea structurală a DU-urilor spune dacă simplificarea a schimbat ceva
    if simplificata <> e then
        printfn "    → simplificat: %s = %.1f" (afiseaza simplificata) (evalueaza simplificata)
