// Secțiunea 13.6 - Validarea datelor: pattern complet
// Capitolul 13 - Gestionarea erorilor în stil funcțional
// Rulare: dotnet fsi fsharp/cap13-gestionarea-erorilor-functional/validarea-datelor-pattern-complet.fsx

// Builder-ul pentru computation expression-ul result { } (secțiunea 13.4.2)
type ResultBuilder() =
    member _.Bind(result, f) = Result.bind f result
    member _.Return(value) = Ok value
    member _.ReturnFrom(result) = result

let result = ResultBuilder()

// Pasul 1: tipurile de domeniu, cu constructori privați
type Nume = private Nume of string
type Email = private Email of string
type Varsta = private Varsta of int

type Utilizator =
    { Nume: Nume
      Email: Email
      Varsta: Varsta }

// Pasul 2: funcțiile de validare, singura cale de a crea valorile de domeniu
module Nume =
    let create (raw: string) =
        let trimmed = raw.Trim()
        if System.String.IsNullOrWhiteSpace(trimmed) then
            Error "Numele nu poate fi gol"
        elif trimmed.Length < 2 then
            Error "Numele trebuie să aibă cel puțin 2 caractere"
        elif trimmed.Length > 100 then
            Error "Numele nu poate depăși 100 de caractere"
        else
            Ok (Nume trimmed)

    let value (Nume n) = n

module Email =
    let create (raw: string) =
        let trimmed = raw.Trim().ToLower()
        if System.String.IsNullOrWhiteSpace(trimmed) then
            Error "Email-ul nu poate fi gol"
        elif not (trimmed.Contains("@") && trimmed.Contains(".")) then
            Error "Formatul email-ului este invalid"
        else
            Ok (Email trimmed)

    let value (Email e) = e

module Varsta =
    let create raw =
        if raw < 18 then Error "Vârsta minimă este 18 ani"
        elif raw > 120 then Error "Vârsta nu poate depăși 120 ani"
        else Ok (Varsta raw)

    let value (Varsta v) = v

// Pasul 3: compunerea validărilor cu result { }
let creeazaUtilizator numeRaw emailRaw varstaRaw =
    result {
        let! nume = Nume.create numeRaw
        let! email = Email.create emailRaw
        let! varsta = Varsta.create varstaRaw
        return { Nume = nume; Email = email; Varsta = varsta }
    }

// Harness-ul de testare: date brute, ca într-un formular
let teste =
    [ ("Ana Popescu", "ana@upt.ro", 22)
      ("", "ana@upt.ro", 22)
      ("Ion", "invalid", 25)
      ("Maria", "maria@email.com", 15) ]

for (nume, email, varsta) in teste do
    match creeazaUtilizator nume email varsta with
    | Ok u ->
        printfn "  (%s, %s, %d) -> Ok: %s, %s, %d ani"
            nume email varsta (Nume.value u.Nume) (Email.value u.Email) (Varsta.value u.Varsta)
    | Error e ->
        printfn "  (%s, %s, %d) -> Eroare: %s" nume email varsta e
