let valideazaNume (nume: string) =
    if System.String.IsNullOrWhiteSpace(nume) then Error "Numele nu poate fi gol"
    elif nume.Length < 2 then Error "Numele trebuie să aibă cel puțin 2 caractere"
    else Ok (nume.Trim())

let valideazaVarsta varsta =
    if varsta < 18 then Error "Vârsta minimă este 18 ani"
    elif varsta > 120 then Error "Vârsta nu poate depăși 120 ani"
    else Ok varsta

let valideazaEmail (email: string) =
    if System.String.IsNullOrWhiteSpace(email) then Error "Email-ul nu poate fi gol"
    elif not (email.Contains("@")) then Error "Email-ul trebuie să conțină '@'"
    else Ok (email.Trim().ToLower())

type Utilizator = { Nume: string; Varsta: int; Email: string }

let creeazaUtilizatorComplet numeRaw varstaRaw emailRaw =
    let rezultatNume = valideazaNume numeRaw
    let rezultatVarsta = valideazaVarsta varstaRaw
    let rezultatEmail = valideazaEmail emailRaw

    // Colectăm erorile
    let erori =
        [ rezultatNume |> Result.map ignore; rezultatVarsta |> Result.map ignore; rezultatEmail |> Result.map ignore ]
        |> List.choose (fun r ->
            match r with
            | Error e -> Some e
            | Ok _ -> None)

    if erori.IsEmpty then
        // Toate validările au reușit — extragem valorile
        match rezultatNume, rezultatVarsta, rezultatEmail with
        | Ok n, Ok v, Ok e -> Ok { Nume = n; Varsta = v; Email = e }
        | _ -> Error erori // nu se ajunge aici, dar fără ramură compilatorul emite FS0025
    else
        Error erori

let afiseaza rezultat =
    match rezultat with
    | Ok u -> printfn "Ok: %s, %d ani, %s" u.Nume u.Varsta u.Email
    | Error erori -> printfn "Error: %s" (String.concat "; " erori)

afiseaza (creeazaUtilizatorComplet "Ana" 25 "ana@upt.ro")
afiseaza (creeazaUtilizatorComplet "" 15 "invalid")
afiseaza (creeazaUtilizatorComplet "Ion" 200 "")
