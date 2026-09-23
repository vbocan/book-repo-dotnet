let matriceIdentitate n =
    [| for i in 0 .. n - 1 ->
           [| for j in 0 .. n - 1 ->
                  if i = j then 1 else 0 |] |]

let identitate = matriceIdentitate 4
printfn "Matrice identitate 4×4:"
for rand in identitate do
    rand |> Array.iter (fun v -> printf "%2d " v)
    printfn ""
