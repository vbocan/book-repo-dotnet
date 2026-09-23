let afiseazaPrimul lista =
    match List.tryHead lista with
    | Some v -> printfn "Primul element: %d" v
    | None -> printfn "Lista este vidă"

afiseazaPrimul [1; 2; 3]
afiseazaPrimul []
