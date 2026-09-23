let text = "to be or not to be that is the question"

let cuvinte = text.Split(' ') |> Array.toList
let cuvinteUnice = cuvinte |> Set.ofList
let frecvente =
    cuvinte
    |> List.fold (fun acc c ->
        acc |> Map.add c (1 + (acc |> Map.tryFind c |> Option.defaultValue 0))
    ) Map.empty

printfn "Total cuvinte: %d" cuvinte.Length
printfn "Cuvinte unice: %d" (Set.count cuvinteUnice)
printfn "Cele mai frecvente:"
frecvente
|> Map.toList
|> List.sortByDescending snd
|> List.take 3
|> List.iter (fun (c, n) -> printfn "  %-6s: %d" c n)
