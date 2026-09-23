let aduna a b = a + b        // int -> int -> int (implicit)
let rezultat = aduna 3 5
printfn $"Adunare int: {rezultat}"

let adunaFloat a b = a + b   // float -> float -> float (inferat din utilizare)
let rezultatF = adunaFloat 3.0 5.0
printfn $"Adunare float: {rezultatF}"
