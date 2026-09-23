// Fără pipe: citire de la interior spre exterior
let rezultatFaraPipe =
    List.sum (List.map (fun x -> x * x) (List.filter (fun x -> x % 2 = 0) [1; 2; 3; 4; 5]))

// Cu pipe: citire de sus în jos
let rezultatCuPipe =
    [1; 2; 3; 4; 5]
    |> List.filter (fun x -> x % 2 = 0)
    |> List.map (fun x -> x * x)
    |> List.sum

printfn "Fără pipe: %d" rezultatFaraPipe
printfn "Cu pipe: %d" rezultatCuPipe
