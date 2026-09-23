let (|Intreg|_|) (text: string) =
    match System.Int32.TryParse(text) with
    | (true, valoare) -> Some valoare
    | _ -> None

let (|Real|_|) (text: string) =
    match System.Double.TryParse(text, System.Globalization.CultureInfo.InvariantCulture) with
    | (true, valoare) -> Some valoare
    | _ -> None

let parseaza text =
    match text with
    | Intreg n -> $"Întreg: {n}"
    | Real r -> $"Real: {r}"
    | _ -> $"Nu este un număr: '{text}'"

let teste = ["42"; "3.14"; "abc"; "100"; "2.718"]
teste |> List.iter (fun t -> printfn "%s" (parseaza t))
