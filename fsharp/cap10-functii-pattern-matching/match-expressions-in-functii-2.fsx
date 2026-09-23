type Rezultat = Succes of string | Eroare of string

let mesaje = [Succes "Date salvate"; Eroare "Fișier inexistent"; Succes "Email trimis"]

mesaje |> List.iter (function
    | Succes msg -> printfn "[OK] %s" msg
    | Eroare msg -> printfn "[EROARE] %s" msg
)
