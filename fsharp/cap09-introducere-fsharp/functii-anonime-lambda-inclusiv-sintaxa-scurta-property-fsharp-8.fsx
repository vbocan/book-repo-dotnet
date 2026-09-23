// Lambda cu un parametru
let dublu = fun x -> x * 2

// Lambda cu doi parametri
let aduna = fun x y -> x + y

// Utilizare directă cu List.map
let numere = [1; 2; 3; 4; 5]
let duble = numere |> List.map (fun x -> x * 2)
let pare = numere |> List.filter (fun x -> x % 2 = 0)

printfn $"Duble: %A{duble}"
printfn $"Pare: %A{pare}"
