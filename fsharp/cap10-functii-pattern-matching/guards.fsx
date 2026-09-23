let clasificaNumar x =
    match x with
    | n when n < -100 -> "foarte mic"
    | n when n < 0 -> "negativ"
    | 0 -> "zero"
    | n when n <= 100 -> "pozitiv mic"
    | n when n <= 1000 -> "pozitiv mediu"
    | _ -> "foarte mare"

let teste = [-500; -42; 0; 7; 250; 5000]
teste |> List.iter (fun n -> printfn "%6d -> %s" n (clasificaNumar n))
