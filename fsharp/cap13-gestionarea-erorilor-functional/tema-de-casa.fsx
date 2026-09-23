type ResultBuilder() =
    member _.Bind(result, f) = Result.bind f result
    member _.Return(value) = Ok value
    member _.ReturnFrom(result) = result

let result = ResultBuilder()

let parseazaFloat (s: string) =
    match System.Double.TryParse(s, System.Globalization.CultureInfo.InvariantCulture) with
    | true, n -> Ok n
    | false, _ -> Error $"'{s}' nu este un număr valid"

let parseazaOperator op =
    match op with
    | "+" -> Ok (+)
    | "-" -> Ok (-)
    | "*" -> Ok (*)
    | "/" -> Ok (/)
    | _ -> Error $"Operator necunoscut: '{op}'"

let calculeaza (expresie: string) =
    result {
        let parti = expresie.Trim().Split(' ')
        do! if parti.Length = 3 then Ok () else Error $"Format invalid: '{expresie}'"
        let! a = parseazaFloat parti[0]
        let! op = parseazaOperator parti[1]
        let! b = parseazaFloat parti[2]
        do! if parti[1] = "/" && b = 0.0 then Error "Împărțire la zero" else Ok ()
        return op a b
    }

printfn "=== Calculator CLI ==="
let expresii = ["10 + 3"; "7.5 * 2"; "20 / 4"; "10 / 0"; "abc + 3"; "5 % 2"; "42"]
for e in expresii do
    match calculeaza e with
    | Ok rez -> printfn "  %s = %.2f" e rez
    | Error msg -> printfn "  %s -> Eroare: %s" e msg
