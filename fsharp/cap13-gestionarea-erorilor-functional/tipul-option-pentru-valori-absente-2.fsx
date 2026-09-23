let optionToResult eroare opt =
    match opt with
    | Some v -> Ok v
    | None -> Error eroare

let numere = Map.ofList [("unu", 1); ("doi", 2); ("trei", 3)]

let cautaCuEroare cheie =
    numere
    |> Map.tryFind cheie
    |> optionToResult $"Cheia '{cheie}' nu a fost găsită"

printfn "%A" (cautaCuEroare "doi")
printfn "%A" (cautaCuEroare "patru")
