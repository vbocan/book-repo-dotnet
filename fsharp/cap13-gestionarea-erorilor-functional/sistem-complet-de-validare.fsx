// Exercițiul 5 - Sistem complet de validare
// Capitolul 13 - Gestionarea erorilor în stil funcțional
// Rulare: dotnet fsi fsharp/cap13-gestionarea-erorilor-functional/sistem-complet-de-validare.fsx

type ResultBuilder() =
    member _.Bind(result, f) = Result.bind f result
    member _.Return(value) = Ok value
    member _.ReturnFrom(result) = result

let result = ResultBuilder()

// Tipurile de domeniu: single-case DU cu constructori privați
type Nume = private Nume of string
type Email = private Email of string
type Varsta = private Varsta of int
type NumarTelefon = private NumarTelefon of string

type Persoana =
    { Nume: Nume
      Email: Email
      Varsta: Varsta
      Telefon: NumarTelefon }

module Nume =
    let create (raw: string) =
        let n = raw.Trim()
        if n = "" then Error "Numele nu poate fi gol"
        elif n.Length < 2 then Error "Numele trebuie să aibă cel puțin 2 caractere"
        else Ok (Nume n)

    let value (Nume n) = n

module Email =
    let create (raw: string) =
        let e = raw.Trim().ToLower()
        if e = "" then Error "Email-ul nu poate fi gol"
        elif not (e.Contains("@") && e.Contains(".")) then Error "Format email invalid"
        else Ok (Email e)

    let value (Email e) = e

module Varsta =
    // Datele vin dintr-un formular, deci vârsta sosește ca text
    let create (raw: string) =
        match System.Int32.TryParse(raw.Trim()) with
        | false, _ -> Error $"Vârsta '{raw}' nu este un număr"
        | true, v when v < 18 -> Error "Vârsta minimă este 18 ani"
        | true, v when v > 120 -> Error "Vârsta nu poate depăși 120 ani"
        | true, v -> Ok (Varsta v)

    let value (Varsta v) = v

module NumarTelefon =
    // Spațiile, cratimele și punctele sunt permise la introducere și sunt eliminate
    let create (raw: string) =
        let cifre = raw |> String.filter (fun c -> c <> ' ' && c <> '-' && c <> '.')
        if not (cifre |> String.forall System.Char.IsDigit) then
            Error "Telefonul poate conține doar cifre"
        elif cifre.Length < 10 then
            Error "Telefonul trebuie să aibă cel puțin 10 cifre"
        else
            Ok (NumarTelefon cifre)

    let value (NumarTelefon t) = t

// Pipeline-ul result { } cu patru pași: prima eroare oprește construirea
let creeazaPersoana nume email varsta telefon =
    result {
        let! n = Nume.create nume
        let! e = Email.create email
        let! v = Varsta.create varsta
        let! t = NumarTelefon.create telefon
        return { Nume = n; Email = e; Varsta = v; Telefon = t }
    }

let formulare =
    [ ("Ana Popescu", "Ana@UPT.ro", "22", "0721 123 456") // valid
      ("   ", "ion@upt.ro", "25", "0722000111") // nume gol
      ("Ion Marin", "ion.upt.ro", "25", "0722000111") // email fără @
      ("Maria Pop", "maria@upt.ro", "16", "0733000222") // vârstă sub 18
      ("Dan Rus", "dan@upt.ro", "30", "07441") ] // telefon prea scurt

printfn "=== Validare completă ==="
for (nume, email, varsta, telefon) in formulare do
    match creeazaPersoana nume email varsta telefon with
    | Ok p ->
        printfn "  OK: %s | %s | %d ani | tel: %s"
            (Nume.value p.Nume) (Email.value p.Email) (Varsta.value p.Varsta) (NumarTelefon.value p.Telefon)
    | Error mesaj ->
        printfn "  EROARE: %s" mesaj
