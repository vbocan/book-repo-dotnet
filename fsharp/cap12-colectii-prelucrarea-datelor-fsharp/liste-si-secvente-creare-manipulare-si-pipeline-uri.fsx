// Creare liste
let numere = [1 .. 10]
let pare = [2 .. 2 .. 20]
let desc = [10 .. -1 .. 1]

printfn "Numere: %A" numere
printfn "Pare: %A" pare
printfn "Descrescător: %A" desc

// Cons și concatenare
let extins = 0 :: numere
let unit = [100; 200] @ numere
printfn "Cu 0 în față: %A" extins
printfn "Concatenat: %A" unit

// Pipeline: procesarea temperaturilor
let temperaturi = [23.5; 18.2; 31.0; 15.8; 27.3; 22.1; 35.6; 19.4; 28.7; 16.3]

let statistica =
    let peste25 = temperaturi |> List.filter (fun t -> t > 25.0)
    let media = temperaturi |> List.average
    let minima = temperaturi |> List.min
    let maxima = temperaturi |> List.max
    (media, minima, maxima, List.length peste25)

let (media, minima, maxima, nrPeste25) = statistica
printfn "\nStatistică temperaturi:"
printfn "  Media: %.1f°C" media
printfn "  Min: %.1f°C, Max: %.1f°C" minima maxima
printfn "  Zile peste 25°C: %d" nrPeste25

// Secvența Fibonacci (leneșă, infinită)
let fibonacci =
    Seq.unfold (fun (a, b) -> Some(a, (b, a + b))) (0, 1)

let primele20Fib = fibonacci |> Seq.take 20 |> Seq.toList
printfn "\nPrimii 20 termeni Fibonacci: %A" primele20Fib

// Secvență: numere prime (sită simplificată)
let estePrim n =
    if n < 2 then false
    else
        let limita = int (sqrt (float n))
        seq { 2 .. limita } |> Seq.forall (fun d -> n % d <> 0)

let prime = seq { 2 .. 100 } |> Seq.filter estePrim |> Seq.toList
printfn "Prime până la 100: %A" prime
