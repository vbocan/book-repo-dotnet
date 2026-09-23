let patrate = seq { for i in 1 .. 10 do yield i * i }

printfn "Primele 5 pătrate: %A" (patrate |> Seq.take 5 |> Seq.toList)
printfn "Toate: %A" (patrate |> Seq.toList)
