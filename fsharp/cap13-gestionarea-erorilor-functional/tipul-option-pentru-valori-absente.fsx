type StudentInfo = { Id: int; Nume: string }

// Tipul StudentInfo trebuie definit înaintea funcției,
// astfel încât compilatorul să poată infera tipul parametrului studenti
let cautaStudent id studenti =
    studenti |> List.tryFind (fun s -> s.Id = id)

let studenti =
    [ { Id = 1; Nume = "Ana" }
      { Id = 2; Nume = "Ion" }
      { Id = 3; Nume = "Maria" } ]

let afiseazaRezultat id =
    match studenti |> List.tryFind (fun s -> s.Id = id) with
    | Some s -> printfn "  Găsit: %s" s.Nume
    | None -> printfn "  Studentul cu ID=%d nu există" id

afiseazaRezultat 2
afiseazaRezultat 5
