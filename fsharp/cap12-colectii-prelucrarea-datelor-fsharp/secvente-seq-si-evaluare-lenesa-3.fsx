let rezultat =
    seq { 1 .. 1_000_000 }
    |> Seq.filter (fun x -> x % 7 = 0)
    |> Seq.map (fun x -> x * x)
    |> Seq.take 5
    |> Seq.toList

printfn "Primele 5 pătrate ale multiplilor de 7: %A" rezultat
