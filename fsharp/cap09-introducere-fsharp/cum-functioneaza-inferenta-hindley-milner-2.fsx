// Compilatorul inferă toate tipurile automat
let procesare lista =
    lista
    |> List.filter (fun x -> x > 0)
    |> List.map (fun x -> x * 2)
    |> List.sum

let rezultat = procesare [3; -1; 4; -2; 5]
printfn $"Rezultat procesare: {rezultat}"
