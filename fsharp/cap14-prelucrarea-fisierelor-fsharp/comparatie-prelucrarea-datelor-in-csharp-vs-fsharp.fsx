type Vanzare = { Produs: string; Regiune: string; Cantitate: int; PretUnitar: decimal }

let csvVanzari = [|
    "Produs,Regiune,Cantitate,PretUnitar"
    "Laptop,Vest,5,3500"; "Monitor,Vest,10,1200"
    "Laptop,Est,3,3500";  "Tastatură,Nord,25,250"
    "Mouse,Est,35,120";   "Monitor,Nord,6,1200"
|]

csvVanzari
|> Array.skip 1
|> Array.map (fun linie ->
    let c = linie.Split(',')
    { Produs = c.[0]; Regiune = c.[1]
      Cantitate = int c.[2]; PretUnitar = decimal c.[3] })
|> Array.groupBy (fun v -> v.Regiune)
|> Array.map (fun (reg, vanzari) ->
    reg, vanzari |> Array.sumBy (fun v -> v.Cantitate * int v.PretUnitar), vanzari.Length)
|> Array.sortByDescending (fun (_, total, _) -> total)
|> Array.iter (fun (reg, total, nr) ->
    printfn "  %-8s %10d RON  (%d tranzacții)" reg total nr)
