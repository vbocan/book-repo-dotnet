let cuvinte = ["hello world"; "F# is great"; "collections rock"]

let cuvinteSeparate =
    cuvinte
    |> List.collect (fun s -> s.Split(' ') |> Array.toList)

printfn "Cuvinte separate: %A" cuvinteSeparate
