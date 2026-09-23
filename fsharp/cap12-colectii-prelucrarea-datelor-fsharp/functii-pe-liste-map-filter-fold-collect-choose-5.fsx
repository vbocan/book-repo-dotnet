let studenti =
    [ ("Ana", 9.5); ("Ion", 7.3); ("Maria", 8.8); ("Vlad", 9.5) ]

// Sortare după notă, descrescător
let sortatiDescrescator =
    studenti |> List.sortByDescending snd

// Sortare personalizată: după notă desc, apoi după nume asc
let sortatiComplex =
    studenti
    |> List.sortWith (fun (n1, nota1) (n2, nota2) ->
        let cmpNota = compare nota2 nota1  // descrescător
        if cmpNota <> 0 then cmpNota
        else compare n1 n2)                // ascendent

printfn "După notă (desc): %A" sortatiDescrescator
printfn "Notă desc + nume asc: %A" sortatiComplex
