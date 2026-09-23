// Tema 3 — Organizare în module: sistem de studenți
// Capitolul 11: Tipuri algebrice în F#
// Rulare: dotnet fsi fsharp/cap11-tipuri-algebrice-fsharp/tema-pentru-acasa-3.fsx
//
// Un script .fsx nu poate începe cu o declarație `module` de nivel superior,
// așa că modulul Student este definit ca modul imbricat.

module Student =
    type Info =
        { Nume: string
          AnStudiu: int
          Medie: float
          Email: string }

    let pragPromovare = 5.0
    let pragBursa = 8.5

    // Creare cu validare: None dacă datele nu sunt valide
    let creeaza (nume: string) an medie (email: string) =
        if nume.Trim() = "" then None
        elif an < 1 || an > 4 then None
        elif medie < 1.0 || medie > 10.0 then None
        elif not (email.Contains("@")) then None
        else Some { Nume = nume; AnStudiu = an; Medie = medie; Email = email }

    // Formatare
    let descrie s =
        sprintf "%s (anul %d, media %.2f, %s)" s.Nume s.AnStudiu s.Medie s.Email

    let descrieScurt s = sprintf "%s — %.2f" s.Nume s.Medie

    // Filtrare
    let estePromovat s = s.Medie >= pragPromovare
    let esteBursier s = s.Medie >= pragBursa
    let promovati studenti = studenti |> List.filter estePromovat
    let bursieri studenti =
        studenti |> List.filter esteBursier |> List.sortByDescending (fun s -> s.Medie)

    let top n studenti =
        studenti |> List.sortByDescending (fun s -> s.Medie) |> List.truncate n

    let peAni studenti =
        studenti |> List.groupBy (fun s -> s.AnStudiu) |> List.sortBy fst

    let mediaGenerala studenti = studenti |> List.averageBy (fun s -> s.Medie)

// Datele de intrare; ultimele două înregistrări sunt invalide și sunt eliminate de validare
let studenti =
    [ Student.creeaza "Ana Popescu" 3 9.5 "ana@upt.ro"
      Student.creeaza "Ion Marinescu" 3 7.8 "ion@upt.ro"
      Student.creeaza "Maria Dragomir" 2 9.2 "maria@upt.ro"
      Student.creeaza "Vlad Ionescu" 2 4.5 "vlad@upt.ro"
      Student.creeaza "Elena Voinescu" 3 8.9 "elena@upt.ro"
      Student.creeaza "Andrei Popa" 2 6.3 "andrei@upt.ro"
      Student.creeaza "Fără Email" 1 8.0 "adresa-invalida"
      Student.creeaza "Medie Imposibilă" 2 12.0 "x@upt.ro" ]
    |> List.choose id

let afiseazaScurt lista =
    for s in lista do
        printfn "  %s" (Student.descrieScurt s)

printfn "=== Toți studenții ==="
for s in studenti do
    printfn "  %s" (Student.descrie s)

printfn "\n=== Promovați ==="
afiseazaScurt (Student.promovati studenti)

printfn "\n=== Bursieri ==="
afiseazaScurt (Student.bursieri studenti)

printfn "\n=== Top 3 ==="
afiseazaScurt (Student.top 3 studenti)

printfn "\n=== Pe ani de studiu ==="
for (an, grupa) in Student.peAni studenti do
    printfn "  Anul %d (%d studenți, media %.2f):" an (List.length grupa) (Student.mediaGenerala grupa)
    for s in grupa do
        printfn "    %s" (Student.descrieScurt s)

printfn "\n=== Media generală: %.2f ===" (Student.mediaGenerala studenti)
