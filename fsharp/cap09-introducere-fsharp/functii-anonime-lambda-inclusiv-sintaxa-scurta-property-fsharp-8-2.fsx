// Pipeline de transformări cu funcții lambda
let rezultat =
    [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    |> List.filter (fun x -> x % 2 = 0)    // păstrează numerele pare
    |> List.map (fun x -> x * x)            // ridică la pătrat
    |> List.sum                              // calculează suma

printfn $"Suma pătratelor numerelor pare de la 1 la 10: {rezultat}"
