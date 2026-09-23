let aduna x y = x + y

// Aplicare completă — returnează un int
let rezultat = aduna 3 5
printfn "aduna 3 5 = %d" rezultat

// Aplicare parțială — returnează o funcție int -> int
let aduna10 = aduna 10
printfn "aduna10 7 = %d" (aduna10 7)
printfn "aduna10 25 = %d" (aduna10 25)
