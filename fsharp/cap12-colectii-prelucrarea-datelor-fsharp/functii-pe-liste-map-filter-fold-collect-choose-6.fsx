let numere = [1; 3; 2; 3; 1; 4; 2; 5]
let unice = numere |> List.distinct
printfn "Unice: %A" unice

let cuvinte = ["Ana"; "ana"; "ANA"; "Ion"; "ion"]
let uniceDupaCaz = cuvinte |> List.distinctBy (fun s -> s.ToLower())
printfn "Unice (case-insensitive): %A" uniceDupaCaz
