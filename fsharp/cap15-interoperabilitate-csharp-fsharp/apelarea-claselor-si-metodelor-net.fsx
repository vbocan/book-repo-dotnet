open System
open System.Collections.Generic

let lista = List<int>()
lista.Add(1)
lista.Add(2)
lista.Add(3)

printfn "Lista .NET: %A" (lista |> Seq.toList)
printfn "Număr elemente: %d" lista.Count

// Conversia la secvență F# pentru operații funcționale
let suma = lista |> Seq.sum
let dubla = lista |> Seq.map (fun x -> x * 2) |> Seq.toList
printfn "Suma: %d" suma
printfn "Dubla: %A" dubla
