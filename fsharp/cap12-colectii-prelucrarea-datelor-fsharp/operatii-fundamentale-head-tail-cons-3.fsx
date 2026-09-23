let rec sumaLista lista =
    match lista with
    | [] -> 0
    | cap :: coada -> cap + sumaLista coada

let rec afiseazaLista lista =
    match lista with
    | [] -> printfn "(sfarsit)"
    | [ultimul] -> printfn "%d (sfarsit)" ultimul
    | cap :: coada ->
        printf "%d -> " cap
        afiseazaLista coada

let numere = [1; 2; 3; 4; 5]
afiseazaLista numere
printfn "Suma: %d" (sumaLista numere)
