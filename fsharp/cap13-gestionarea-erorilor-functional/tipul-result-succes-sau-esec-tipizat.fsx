let parseazaInt (s: string) : Result<int, string> =
    match System.Int32.TryParse(s) with
    | true, n -> Ok n
    | false, _ -> Error $"'{s}' nu este un număr valid"

// Testare
let teste = ["42"; "abc"; "100"; "3.14"; ""]
for t in teste do
    match parseazaInt t with
    | Ok n -> printfn "  '%s' -> Ok %d" t n
    | Error msg -> printfn "  '%s' -> Error: %s" t msg
