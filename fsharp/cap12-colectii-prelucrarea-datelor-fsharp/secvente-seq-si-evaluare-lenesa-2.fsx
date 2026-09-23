let numerePare = Seq.initInfinite (fun i -> i * 2)

let primele10Pare = numerePare |> Seq.take 10 |> Seq.toList
printfn "Primele 10 numere pare: %A" primele10Pare

// Secvență infinită: puterile lui 2
let puteriLui2 = Seq.unfold (fun stare -> Some(stare, stare * 2L)) 1L

let primele15 = puteriLui2 |> Seq.take 15 |> Seq.toList
printfn "Puterile lui 2: %A" primele15
