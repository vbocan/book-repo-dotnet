let valideazaNume (nume: string) : Result<string, string> =
    if System.String.IsNullOrWhiteSpace(nume) then
        Error "Numele nu poate fi gol"
    elif nume.Length < 2 then
        Error "Numele trebuie să aibă cel puțin 2 caractere"
    else
        Ok (nume.Trim())

let valideazaVarsta varsta : Result<int, string> =
    if varsta < 18 then Error "Vârsta minimă este 18 ani"
    elif varsta > 120 then Error "Vârsta nu poate depăși 120 ani"
    else Ok varsta

type Utilizator = { Nume: string; Varsta: int }

let creeazaUtilizator numeRaw varstaRaw =
    valideazaNume numeRaw
    |> Result.bind (fun numeValid ->
        valideazaVarsta varstaRaw
        |> Result.map (fun varstaValida ->
            { Nume = numeValid; Varsta = varstaValida }))

printfn "%A" (creeazaUtilizator "Ana" 25)
printfn "%A" (creeazaUtilizator "" 25)
printfn "%A" (creeazaUtilizator "Ion" 15)
