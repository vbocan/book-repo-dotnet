// Adnotare pe valoare
let varsta : int = 22

// Adnotare pe parametri de funcție
let salut (nume : string) : string =
    $"Bună ziua, {nume}!"

// Adnotare pe tipul de retur
let patrat (x : float) : float = x * x

printfn "%s" (salut "Ana")
printfn $"Pătratul lui 3.5: {patrat 3.5}"
