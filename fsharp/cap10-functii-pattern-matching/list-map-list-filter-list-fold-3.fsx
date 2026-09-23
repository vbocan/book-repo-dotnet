let numere = [1; 2; 3; 4; 5]

let suma = numere |> List.fold (fun acc x -> acc + x) 0
printfn "Suma: %d" suma

let produs = numere |> List.fold (fun acc x -> acc * x) 1
printfn "Produs: %d" produs
