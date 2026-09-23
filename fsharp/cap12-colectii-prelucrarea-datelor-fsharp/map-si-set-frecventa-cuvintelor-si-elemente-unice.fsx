let text =
    "programarea functionala este un stil de programare care pune accentul \
     pe functii pure si pe imutabilitate programarea functionala evita \
     efectele secundare si starea mutabila"

let cuvinte = text.Split(' ') |> Array.toList

// Map: frecvența cuvintelor
let frecvente =
    cuvinte
    |> List.fold (fun (acc: Map<string, int>) cuvant ->
        let count = acc |> Map.tryFind cuvant |> Option.defaultValue 0
        acc |> Map.add cuvant (count + 1)
    ) Map.empty

printfn "=== Frecvența cuvintelor ==="
frecvente
|> Map.toList
|> List.sortByDescending snd
|> List.iter (fun (cuvant, nr) -> printfn "  %-20s: %d" cuvant nr)

// Top 5 cele mai frecvente cuvinte
printfn "\n=== Top 5 ==="
frecvente
|> Map.toList
|> List.sortByDescending snd
|> List.take 5
|> List.iteri (fun i (c, n) -> printfn "  %d. %s (%d)" (i + 1) c n)

// Set: cuvinte unice, ordonate
let cuvinteUnice = cuvinte |> Set.ofList
printfn "\n=== Cuvinte unice (%d din %d total) ===" (Set.count cuvinteUnice) cuvinte.Length
cuvinteUnice |> Set.iter (fun c -> printf "%s " c)
printfn ""

// Operații pe mulțimi
let cuvinteScurte = cuvinteUnice |> Set.filter (fun c -> c.Length <= 3)
let cuvinteLungi = cuvinteUnice |> Set.filter (fun c -> c.Length >= 8)

printfn "\nCuvinte scurte (≤3 caractere): %A" cuvinteScurte
printfn "Cuvinte lungi (≥8 caractere): %A" cuvinteLungi
