let cauta cheie dictionar =
    dictionar |> Map.tryFind cheie

let note = Map.ofList [("Ana", 9.5); ("Ion", 7.3); ("Maria", 8.8)]

let afiseazaNota student =
    match cauta student note with
    | Some nota -> printfn "%s: %.1f" student nota
    | None -> printfn "%s: nu a fost găsit" student

afiseazaNota "Ana"
afiseazaNota "Ion"
afiseazaNota "Vlad"
