// Exercițiul 3 — Single-case DU: tipuri wrapper pentru un sistem de înregistrare
// Capitolul 11: Tipuri algebrice în F#
// Rulare: dotnet fsi fsharp/cap11-tipuri-algebrice-fsharp/single-case-du-tipuri-wrapper-pentru-un-sistem-de-inregistrare.fsx

open System

// Fiecare wrapper are constructorul privat și un modul companion cu validare
type Email = private Email of string

module Email =
    let create (adresa: string) =
        if adresa.Contains("@") && adresa.Contains(".") then Some(Email adresa)
        else None

    let value (Email e) = e

type Parola = private Parola of string

module Parola =
    // Minimum 8 caractere, cel puțin o majusculă și o cifră
    let create (text: string) =
        if text.Length >= 8 && Seq.exists Char.IsUpper text && Seq.exists Char.IsDigit text then
            Some(Parola text)
        else
            None

type IdStudent = private IdStudent of string

module IdStudent =
    // Format: CTI-<an>-<număr de ordine pe 4 cifre>
    let create (an: int) (numar: int) = IdStudent(sprintf "CTI-%d-%04d" an numar)

    let value (IdStudent id) = id

type StudentInregistrat =
    { Nume: string
      Email: Email
      Parola: Parola
      Id: IdStudent }

// Fiecare cerere primește un număr de ordine, chiar dacă este respinsă
let inregistreaza numarCerere (nume: string) (email: string) (parola: string) =
    match Email.create email, Parola.create parola with
    | None, _ -> printfn "  Email invalid: %s" email
    | Some _, None -> printfn "  Parolă invalidă (min. 8 caractere, o majusculă, o cifră)"
    | Some e, Some p ->
        let student =
            { Nume = nume
              Email = e
              Parola = p
              Id = IdStudent.create 2025 numarCerere }
        printfn "  Înregistrare reușită: %s (%s) — ID: %s"
            student.Nume (Email.value student.Email) (IdStudent.value student.Id)

let cereri =
    [ ("Ana Popescu", "ana@upt.ro", "Parola2025")
      ("Ion Marinescu", "ion_invalid", "Parola2025")
      ("Maria Dragomir", "maria@upt.ro", "scurta")
      ("Vlad Ionescu", "vlad@upt.ro", "Securitate9") ]

printfn "=== Sistem de înregistrare ==="
cereri
|> List.iteri (fun i (nume, email, parola) -> inregistreaza (i + 1) nume email parola)

// Linia de mai jos nu compilează: un string nu poate fi folosit acolo unde se cere Email
// Email.value "ana@upt.ro"
