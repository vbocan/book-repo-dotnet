// Exercițiul 4 — Tipuri recursive: arbore binar de căutare
// Capitolul 11: Tipuri algebrice în F#
// Rulare: dotnet fsi fsharp/cap11-tipuri-algebrice-fsharp/tipuri-recursive-arbore-binar-de-cautare.fsx

type ArboreBinar<'T> =
    | Frunza
    | Nod of valoare: 'T * stanga: ArboreBinar<'T> * dreapta: ArboreBinar<'T>

// Inserarea produce un arbore nou; arborele inițial rămâne neschimbat
let rec insereaza valoare arbore =
    match arbore with
    | Frunza -> Nod(valoare, Frunza, Frunza)
    | Nod(v, stanga, dreapta) ->
        if valoare < v then Nod(v, insereaza valoare stanga, dreapta)
        elif valoare > v then Nod(v, stanga, insereaza valoare dreapta)
        else arbore // valorile duplicate sunt ignorate

let rec cauta valoare arbore =
    match arbore with
    | Frunza -> false
    | Nod(v, stanga, dreapta) ->
        if valoare = v then true
        elif valoare < v then cauta valoare stanga
        else cauta valoare dreapta

let rec inOrdine arbore =
    match arbore with
    | Frunza -> []
    | Nod(v, stanga, dreapta) -> inOrdine stanga @ [ v ] @ inOrdine dreapta

let rec preOrdine arbore =
    match arbore with
    | Frunza -> []
    | Nod(v, stanga, dreapta) -> [ v ] @ preOrdine stanga @ preOrdine dreapta

let rec dimensiune arbore =
    match arbore with
    | Frunza -> 0
    | Nod(_, stanga, dreapta) -> 1 + dimensiune stanga + dimensiune dreapta

let rec inaltime arbore =
    match arbore with
    | Frunza -> 0
    | Nod(_, stanga, dreapta) -> 1 + max (inaltime stanga) (inaltime dreapta)

let valori = [ 50; 30; 70; 20; 40; 60; 80; 10; 35; 45 ]
let arbore = valori |> List.fold (fun acc v -> insereaza v acc) Frunza

printfn "=== Arbore binar de căutare ==="
printfn "Valori inserate: %A" valori
printfn "In-ordine (sortat): %A" (inOrdine arbore)
printfn "Pre-ordine: %A" (preOrdine arbore)
printfn "Dimensiune: %d noduri" (dimensiune arbore)
printfn "Înălțime: %d niveluri" (inaltime arbore)

printfn "\n=== Căutare ==="
for v in [ 40; 55; 10; 90 ] do
    printfn "  %d: %s" v (if cauta v arbore then "găsit" else "negăsit")
