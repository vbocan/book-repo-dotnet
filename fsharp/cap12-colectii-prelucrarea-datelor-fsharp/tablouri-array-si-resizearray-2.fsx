let numere = [| 1 .. 20 |]

let sumaPatratelorPare =
    numere
    |> Array.filter (fun x -> x % 2 = 0)
    |> Array.map (fun x -> x * x)
    |> Array.sum

printfn "Suma pătratelor pare din 1..20: %d" sumaPatratelorPare
