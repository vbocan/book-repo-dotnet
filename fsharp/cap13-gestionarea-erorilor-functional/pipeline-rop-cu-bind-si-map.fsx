let parseazaInt (s: string) =
    match System.Int32.TryParse(s) with
    | true, n -> Ok n
    | false, _ -> Error $"'{s}' nu este un număr valid"

let valideazaPozitiv n =
    if n > 0 then Ok n
    else Error $"{n} nu este un număr pozitiv"

let valideazaInterval min max n =
    if n >= min && n <= max then Ok n
    else Error $"{n} nu este în intervalul [{min}, {max}]"

// Pipeline: parsează -> verifică pozitiv -> verifică interval -> calculează pătrat
let proceseazaNumar (input: string) =
    parseazaInt input
    |> Result.bind valideazaPozitiv
    |> Result.bind (valideazaInterval 1 100)
    |> Result.map (fun n -> n * n)

let teste = ["25"; "-5"; "abc"; "200"; "7"]
printfn "=== Pipeline de validare ==="
for t in teste do
    printfn "  '%s' -> %A" t (proceseazaNumar t)
