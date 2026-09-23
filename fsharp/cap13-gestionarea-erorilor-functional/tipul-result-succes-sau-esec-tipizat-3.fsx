let valideazaVarsta varsta : Result<int, string> =
    if varsta < 18 then Error "Vârsta minimă este 18 ani"
    elif varsta > 120 then Error "Vârsta nu poate depăși 120 ani"
    else Ok varsta

let valideazaEmail (email: string) : Result<string, string> =
    if System.String.IsNullOrWhiteSpace(email) then
        Error "Adresa de email nu poate fi goală"
    elif not (email.Contains("@")) then
        Error "Adresa de email trebuie să conțină '@'"
    else
        Ok (email.Trim().ToLower())

printfn "%A" (valideazaVarsta 25)
printfn "%A" (valideazaVarsta 15)
printfn "%A" (valideazaEmail "Ana@UPT.ro")
printfn "%A" (valideazaEmail "invalid")
