let numere = [1; 2; 3; 4; 5]

let patrate = numere |> List.map (fun x -> x * x)
printfn "Pătrate: %A" patrate

let nume = ["ana"; "ion"; "maria"]
let capitalizate = nume |> List.map (fun s -> s[0..0].ToUpper() + s[1..])
printfn "Capitalizate: %A" capitalizate
