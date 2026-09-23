let cautaIndex element lista =
    match List.tryFindIndex (fun x -> x = element) lista with
    | Some i -> ValueSome i
    | None -> ValueNone

let rezultat = cautaIndex 7 [3; 5; 7; 9]
match rezultat with
| ValueSome idx -> printfn $"Găsit la indexul {idx}"
| ValueNone -> printfn "Negăsit"
