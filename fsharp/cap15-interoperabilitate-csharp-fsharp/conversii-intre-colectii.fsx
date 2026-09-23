open System.Collections.Generic

// F# list -> Array (pentru C#)
let listaFS = [ 1; 2; 3; 4; 5 ]
let arrayPentruCS = List.toArray listaFS
printfn "F# list -> Array: %A" arrayPentruCS

// Array -> F# list (de la C#)
let arrayDinCS = [| 10; 20; 30 |]
let listaInapoi = Array.toList arrayDinCS
printfn "Array -> F# list: %A" listaInapoi

// .NET List<T> -> F# list
let listaDotNet = List<string>()
listaDotNet.Add("Ana")
listaDotNet.Add("Ion")
listaDotNet.Add("Maria")

let listaFSharp = listaDotNet |> Seq.toList
printfn ".NET List<T> -> F# list: %A" listaFSharp

// F# list -> .NET List<T>
let rezultatDotNet = ResizeArray(listaFS)
printfn "F# list -> .NET List<T>: Count=%d" rezultatDotNet.Count

// Seq funcționează ca punte universală
let secventa: seq<int> = seq { 1 .. 5 }
let caArray = secventa |> Seq.toArray
let caLista = secventa |> Seq.toList
let caDotNetList = ResizeArray(secventa)
printfn "\nSeq ca punte universală:"
printfn "  -> Array: %A" caArray
printfn "  -> F# list: %A" caLista
printfn "  -> .NET List: Count=%d" caDotNetList.Count
