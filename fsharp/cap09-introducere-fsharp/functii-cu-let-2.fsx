let aduna x y = x + y

// Aplicare parțială — fixăm primul argument
let aduna5 = aduna 5  // aduna5 are tipul int -> int

printfn $"aduna5 3 = {aduna5 3}"
printfn $"aduna5 10 = {aduna5 10}"
