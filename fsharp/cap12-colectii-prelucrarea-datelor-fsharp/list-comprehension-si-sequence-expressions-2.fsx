let perechi =
    [ for i in 1 .. 4 do
          for j in 1 .. 4 do
              if i <> j then yield (i, j) ]

printfn "Perechi (i ≠ j):"
perechi |> List.iter (fun (i, j) -> printf "(%d,%d) " i j)
printfn ""
printfn "Total perechi: %d" perechi.Length
