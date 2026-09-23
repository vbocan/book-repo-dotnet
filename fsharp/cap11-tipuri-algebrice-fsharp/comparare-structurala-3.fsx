type Student =
    { Nume: string
      AnStudiu: int
      Medie: float }

let studenti =
    [ { Nume = "Vlad"; AnStudiu = 3; Medie = 8.50 }
      { Nume = "Ana"; AnStudiu = 3; Medie = 9.80 }
      { Nume = "Ion"; AnStudiu = 2; Medie = 7.90 } ]

// Sortare descrescătoare după medie
let topStudenti = studenti |> List.sortByDescending (fun s -> s.Medie)

printfn "Top studenți:"
for s in topStudenti do
    printfn "  %s — %.2f" s.Nume s.Medie
