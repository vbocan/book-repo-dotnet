let rec estePar n =
    if n = 0 then true
    else esteImpar (n - 1)
and esteImpar n =
    if n = 0 then false
    else estePar (n - 1)

printfn "4 este par: %b" (estePar 4)
printfn "7 este impar: %b" (esteImpar 7)
