let texte = ["42"; "abc"; "17"; "xyz"; "8"]

let numere =
    texte
    |> List.choose (fun s ->
        match System.Int32.TryParse(s) with
        | (true, n) -> Some n
        | _ -> None)

printfn "Numere extrase: %A" numere
printfn "Suma: %d" (List.sum numere)
