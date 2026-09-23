// Exercițiul 3 - Computation expressions (result { } și option { })
// Capitolul 13 - Gestionarea erorilor în stil funcțional
// Rulare: dotnet fsi fsharp/cap13-gestionarea-erorilor-functional/computation-expressions-result-si-option.fsx

// ---------- Builder-ul result { } ----------
type ResultBuilder() =
    member _.Bind(result, f) = Result.bind f result
    member _.Return(value) = Ok value
    member _.ReturnFrom(result) = result

let result = ResultBuilder()

// ---------- Builder-ul option { } ----------
type OptionBuilder() =
    member _.Bind(opt, f) =
        match opt with
        | Some v -> f v
        | None -> None
    member _.Return(value) = Some value
    member _.ReturnFrom(opt) = opt

let option = OptionBuilder()

// ---------- Scenariul 1: fluxul de înregistrare ----------
type Utilizator = { Nume: string; Varsta: int; Email: string }

let valideazaNume (nume: string) =
    if System.String.IsNullOrWhiteSpace(nume) then Error "Numele nu poate fi gol"
    elif nume.Trim().Length < 2 then Error "Numele trebuie să aibă cel puțin 2 caractere"
    else Ok (nume.Trim())

let valideazaVarsta varsta =
    if varsta < 18 then Error "Vârsta minimă este 18 ani"
    elif varsta > 120 then Error "Vârsta nu poate depăși 120 ani"
    else Ok varsta

let valideazaEmail (email: string) =
    if email.Contains("@") && email.Contains(".") then Ok (email.Trim().ToLower())
    else Error "Format email invalid"

let inregistreaza nume varsta email =
    result {
        let! n = valideazaNume nume
        let! v = valideazaVarsta varsta
        let! e = valideazaEmail email
        return { Nume = n; Varsta = v; Email = e }
    }

// %A ar afișa record-ul pe mai multe rânduri, așa că afișăm câmpurile explicit
let afiseazaInregistrare rezultat =
    match rezultat with
    | Ok u -> printfn "  Ok { Nume = %A; Varsta = %d; Email = %A }" u.Nume u.Varsta u.Email
    | Error e -> printfn "  Error %A" e

printfn "=== Înregistrare cu result CE ==="
afiseazaInregistrare (inregistreaza "Ana Popescu" 22 "ana@upt.ro")
afiseazaInregistrare (inregistreaza "" 25 "ion@upt.ro")
afiseazaInregistrare (inregistreaza "Mihai" 15 "mihai@upt.ro")
afiseazaInregistrare (inregistreaza "Maria" 30 "maria-la-upt")

// ---------- Scenariul 2: preț cu discount, prin două căutări înlănțuite ----------
let inventar = Map.ofList [ ("A01", "Laptop"); ("A02", "Mouse"); ("A03", "Tastatură") ]
let preturi = Map.ofList [ ("Laptop", 3500.0); ("Mouse", 75.0); ("Tastatură", 250.0) ]
let discounturi = Map.ofList [ ("Laptop", 10.0); ("Tastatură", 5.0) ] // procente

let pretCuDiscount cod =
    option {
        let! produs = inventar |> Map.tryFind cod
        let! discount = discounturi |> Map.tryFind produs
        let! pret = preturi |> Map.tryFind produs
        return (produs, pret, discount, pret - pret * discount / 100.0)
    }

printfn "\n=== Căutare cu option CE ==="
for cod in [ "A01"; "A02"; "A99" ] do
    match pretCuDiscount cod with
    | Some (produs, pret, discount, final) ->
        printfn "  %s -> %s: %.0f RON - %.0f%% = %.0f RON" cod produs pret discount final
    | None ->
        printfn "  %s -> Nu s-a găsit produsul sau discount-ul" cod
