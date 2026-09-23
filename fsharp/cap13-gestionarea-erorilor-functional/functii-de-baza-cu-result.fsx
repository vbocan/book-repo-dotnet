let parseazaInt (s: string) : Result<int, string> =
    match System.Int32.TryParse(s) with
    | true, n -> Ok n
    | false, _ -> Error $"'{s}' nu este un număr valid"

let imparteSecurizat x y : Result<float, string> =
    if y = 0.0 then Error "Împărțire la zero"
    else Ok (x / y)

let valideazaEmail (email: string) : Result<string, string> =
    if System.String.IsNullOrWhiteSpace(email) then
        Error "Email-ul nu poate fi gol"
    elif not (email.Contains("@") && email.Contains(".")) then
        Error "Formatul email-ului este invalid"
    else
        Ok (email.Trim().ToLower())

// Testare parseazaInt
printfn "=== parseazaInt ==="
for t in ["42"; "abc"; "100"; ""] do
    printfn "  '%s' -> %A" t (parseazaInt t)

// Testare imparteSecurizat
printfn "\n=== imparteSecurizat ==="
printfn "  10 / 3 = %A" (imparteSecurizat 10.0 3.0)
printfn "  10 / 0 = %A" (imparteSecurizat 10.0 0.0)

// Testare valideazaEmail
printfn "\n=== valideazaEmail ==="
for e in ["Ana@UPT.ro"; "invalid"; ""; "test@email.com"] do
    printfn "  '%s' -> %A" e (valideazaEmail e)
