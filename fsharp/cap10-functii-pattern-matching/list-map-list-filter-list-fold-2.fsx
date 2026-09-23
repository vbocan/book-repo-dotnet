let numere = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

let pare = numere |> List.filter (fun x -> x % 2 = 0)
printfn "Pare: %A" pare
