// Operator de aplicare sigură pe Option
let (|>?) opt f =
    match opt with
    | Some v -> Some (f v)
    | None -> None

// Operator de concatenare cu separator
let (</>) (a: string) (b: string) = a + "/" + b

let cale = "usr" </> "local" </> "bin"
printfn "Cale: %s" cale

let rezultat = Some 5 |>? (fun x -> x * 2) |>? (fun x -> x + 1)
printfn "Option pipeline: %A" rezultat

let rezultatNone: int option = None |>? (fun x -> x * 2)
printfn "None pipeline: %A" rezultatNone
