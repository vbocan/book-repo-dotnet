let expandeaza n =
    [ for i in 1 .. n -> i ]

let numere = [ for n in [3; 1; 4] do yield! expandeaza n ]
printfn "Expandat: %A" numere
