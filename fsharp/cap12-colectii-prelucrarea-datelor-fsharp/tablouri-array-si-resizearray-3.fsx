let listaOriginala = [1; 2; 3; 4; 5]
let tablouDinLista = listaOriginala |> List.toArray
let listaReconstruita = tablouDinLista |> Array.toList

printfn "Tablou: %A" tablouDinLista
printfn "Lista: %A" listaReconstruita
