type Angajat = { Nume: string; Departament: string; Salariu: decimal; AnAngajare: int }

let csvAngajati = [|
    "Nume,Departament,Salariu,AnAngajare"
    "Ana Popescu,IT,7500,2020";       "Mihai Ionescu,HR,5500,2019"
    "Elena Dragomir,IT,8200,2018";    "Andrei Munteanu,Financiar,6800,2021"
    "Maria Luca,IT,7000,2022";        "Cristian Popa,HR,5800,2020"
    "Ioana Stoica,Financiar,7200,2019"; "Dan Marinescu,IT,9000,2017"
|]

csvAngajati
|> Array.skip 1
|> Array.map (fun linie ->
    let c = linie.Split(',')
    { Nume = c.[0]; Departament = c.[1]
      Salariu = decimal c.[2]; AnAngajare = int c.[3] })
|> Array.groupBy (fun a -> a.Departament)
|> Array.map (fun (dept, ang) ->
    let salarii = ang |> Array.map (fun a -> a.Salariu)
    dept, ang.Length, Array.average (salarii |> Array.map float),
    Array.max salarii, Array.sum salarii,
    ang |> Array.sortByDescending (fun a -> a.Salariu))
|> Array.sortByDescending (fun (_, _, _, _, fond, _) -> fond)
|> Array.iter (fun (dept, nr, med, max, fond, ang) ->
    printfn "=== %s === (%d angajați, medie: %.0f, fond: %.0f RON)" dept nr med fond
    ang |> Array.iter (fun a ->
        printfn "  %s — %.0f RON (din %d)" a.Nume a.Salariu a.AnAngajare))
