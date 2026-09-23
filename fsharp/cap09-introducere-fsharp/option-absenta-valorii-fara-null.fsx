// Funcție care caută un element într-o listă
let cautaStudent nume studenti =
    studenti |> List.tryFind (fun s -> s = nume)

let studenti = ["Ana"; "Ion"; "Maria"; "Vlad"]

// Căutare cu succes
let rezultat1 = cautaStudent "Maria" studenti
// Căutare fără succes
let rezultat2 = cautaStudent "Elena" studenti

printfn $"Căutare Maria: %A{rezultat1}"
printfn $"Căutare Elena: %A{rezultat2}"
