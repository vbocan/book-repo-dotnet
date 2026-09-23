// Deconstrucția unui tuplu
let (nume, varsta, medie) = ("Ana Popescu", 22, 9.5)
printfn $"Nume: {nume}, Vârsta: {varsta}, Media: {medie}"

// Ignorarea unor componente cu _
let (oras, _, populatie) = ("Timișoara", "Timiș", 250_849)
printfn $"{oras} are {populatie} locuitori"

// Funcție care returnează un tuplu
let minMax lista =
    (List.min lista, List.max lista)

let (minim, maxim) = minMax [3; 7; 1; 9; 4]
printfn $"Min: {minim}, Max: {maxim}"
