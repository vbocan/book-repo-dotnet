let numere = [1 .. 20]

let rezultat =
    numere
    |> List.filter (fun x -> x % 2 = 0)  // păstrează numerele pare
    |> List.map (fun x -> x * x)          // ridică la pătrat
    |> List.fold (fun acc x -> acc + x) 0 // calculează suma

printfn "Suma pătratelor numerelor pare din 1..20: %d" rezultat
