let numere = [10; 25; 30; 45; 50]

match numere |> List.tryFind (fun x -> x > 20 && x % 2 <> 0) with
| Some n -> printfn "Primul impar > 20: %d" n
| None -> printfn "Nu există"
