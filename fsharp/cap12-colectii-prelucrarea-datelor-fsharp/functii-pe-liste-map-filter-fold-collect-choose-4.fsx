let cuvinte = ["ana"; "ion"; "ada"; "iris"; "alex"; "ioana"]

let grupate =
    cuvinte
    |> List.groupBy (fun s -> s.[0])

for (litera, grup) in grupate do
    printfn "  '%c': %A" litera grup
