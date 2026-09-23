let (|?) opt defaultValue =
    match opt with
    | Some v -> v
    | None -> defaultValue

let studenti = Map.ofList [("Ana", 9.5); ("Ion", 7.3)]

let notaAna = Map.tryFind "Ana" studenti |? 0.0
let notaVlad = Map.tryFind "Vlad" studenti |? 0.0

printfn "Ana: %.1f" notaAna
printfn "Vlad: %.1f" notaVlad
