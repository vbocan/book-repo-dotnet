type Email = private Email of string

module Email =
    let create (adresa: string) =
        if adresa.Contains("@") && adresa.Contains(".") then
            Some(Email adresa)
        else
            None

    let value (Email e) = e

match Email.create "student@upt.ro" with
| Some email -> printfn "Email valid: %s" (Email.value email)
| None -> printfn "Email invalid"

match Email.create "invalid" with
| Some email -> printfn "Email valid: %s" (Email.value email)
| None -> printfn "Email invalid"
