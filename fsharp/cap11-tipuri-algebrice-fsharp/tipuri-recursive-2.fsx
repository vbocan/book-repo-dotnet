type Expresie =
    | Numar of float
    | Adunare of Expresie * Expresie
    | Inmultire of Expresie * Expresie
    | Negare of Expresie

let rec evalueaza expr =
    match expr with
    | Numar n -> n
    | Adunare(stanga, dreapta) -> evalueaza stanga + evalueaza dreapta
    | Inmultire(stanga, dreapta) -> evalueaza stanga * evalueaza dreapta
    | Negare e -> -(evalueaza e)

let rec afiseaza expr =
    match expr with
    | Numar n -> $"{n}"
    | Adunare(s, d) -> $"({afiseaza s} + {afiseaza d})"
    | Inmultire(s, d) -> $"({afiseaza s} * {afiseaza d})"
    | Negare e -> $"(-{afiseaza e})"

// Expresia: (3 + 4) * (-(2))
let expresie =
    Inmultire(
        Adunare(Numar 3.0, Numar 4.0),
        Negare(Numar 2.0))

printfn "Expresie: %s" (afiseaza expresie)
printfn "Rezultat: %.1f" (evalueaza expresie)

// Expresia: 5 + 3 * 2
let expresie2 =
    Adunare(
        Numar 5.0,
        Inmultire(Numar 3.0, Numar 2.0))

printfn "Expresie: %s" (afiseaza expresie2)
printfn "Rezultat: %.1f" (evalueaza expresie2)
