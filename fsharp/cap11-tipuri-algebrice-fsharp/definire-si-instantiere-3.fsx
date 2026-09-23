type Adresa =
    { Strada: string
      Oras: string
      CodPostal: string }

type StudentComplet =
    { Nume: string
      AnStudiu: int
      Medie: float
      Adresa: Adresa
      Telefon: string option }

let student =
    { Nume = "Elena Voinescu"
      AnStudiu = 3
      Medie = 9.25
      Adresa = { Strada = "Bd. V. Pârvan 2"; Oras = "Timișoara"; CodPostal = "300223" }
      Telefon = Some "0721123456" }

printfn "%s locuiește în %s" student.Nume student.Adresa.Oras

match student.Telefon with
| Some tel -> printfn "Telefon: %s" tel
| None -> printfn "Fără telefon"
