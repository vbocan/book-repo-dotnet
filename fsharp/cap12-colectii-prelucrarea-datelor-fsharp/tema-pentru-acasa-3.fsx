// Temă pentru acasă, Tema 3 - Prelucrarea notelor studenților cu pipe-uri
// Capitolul 12 - Colecții și prelucrarea datelor în F#
// Rulare: dotnet fsi fsharp/cap12-colectii-prelucrarea-datelor-fsharp/tema-pentru-acasa-3.fsx

type Student =
    { Nume: string
      An: int
      Note: (string * float) list } // (materie, notă), în ordinea materiilor

let materii = [ "Matematică"; "Fizică"; "Informatică" ]

let studenti =
    [ { Nume = "Ana Popescu"; An = 3; Note = [ ("Matematică", 9.0); ("Fizică", 10.0); ("Informatică", 9.5) ] }
      { Nume = "Ion Marinescu"; An = 3; Note = [ ("Matematică", 8.0); ("Fizică", 4.0); ("Informatică", 7.0) ] }
      { Nume = "Mihai Stancu"; An = 2; Note = [ ("Matematică", 9.0); ("Fizică", 8.5); ("Informatică", 9.5) ] }
      { Nume = "Elena Voinescu"; An = 3; Note = [ ("Matematică", 10.0); ("Fizică", 9.5); ("Informatică", 10.0) ] }
      { Nume = "Maria Dragomir"; An = 2; Note = [ ("Matematică", 8.0); ("Fizică", 9.0); ("Informatică", 8.5) ] }
      { Nume = "Andrei Popa"; An = 2; Note = [ ("Matematică", 3.0); ("Fizică", 4.0); ("Informatică", 6.0) ] }
      { Nume = "Diana Rusu"; An = 3; Note = [ ("Matematică", 7.0); ("Fizică", 8.0); ("Informatică", 7.5) ] }
      { Nume = "Vlad Ionescu"; An = 2; Note = [ ("Matematică", 5.0); ("Fizică", 6.0); ("Informatică", 5.5) ] } ]

let media (s: Student) = s.Note |> List.averageBy snd

let restante (s: Student) =
    s.Note |> List.filter (fun (_, nota) -> nota < 5.0) |> List.map fst

let estePromovat (s: Student) = List.isEmpty (restante s)

let promovati =
    studenti
    |> List.filter estePromovat
    |> List.sortByDescending media

printfn "=== Studenți promovați (sortați după medie) ==="
promovati
|> List.iter (fun s -> printfn "  %s (anul %d) — media %.2f" s.Nume s.An (media s))

printfn "\n=== Studenți cu restanțe ==="
studenti
|> List.filter (estePromovat >> not)
|> List.iter (fun s ->
    printfn "  %s (anul %d) — restanțe: %s" s.Nume s.An (restante s |> String.concat ", "))

// Gruparea promovaților pe ani; fiecare grup păstrează ordinea după medie
printfn "\n=== Statistici pe ani ==="
promovati
|> List.groupBy (fun s -> s.An)
|> List.sortBy fst
|> List.iter (fun (an, grup) ->
    let mediaAnului = grup |> List.averageBy media
    printfn "  Anul %d (%d studenți promovați, media: %.2f):" an grup.Length mediaAnului
    for s in grup do
        printfn "    %s — %.2f" s.Nume (media s))

// Top 3 pe fiecare materie; la note egale, ordinea este alfabetică după nume
printfn "\n=== Top 3 pe materii ==="
for materie in materii do
    printfn "  %s:" materie
    studenti
    |> List.map (fun s -> s.Nume, s.Note |> List.find (fun (m, _) -> m = materie) |> snd)
    |> List.sortBy (fun (nume, nota) -> -nota, nume)
    |> List.truncate 3
    |> List.iteri (fun i (nume, nota) -> printfn "    %d. %s — %.1f" (i + 1) nume nota)
