let numere = [| 1; 2; 3; 4; 5 |]
let vid: int array = [| |]
let range = [| 1 .. 10 |]

// Accesul prin index
printfn "Primul: %d" numere[0]
printfn "Ultimul: %d" numere[numere.Length - 1]

// Mutabilitate: tablourile permit modificarea elementelor
numere[0] <- 99
printfn "După modificare: %A" numere
