type Student =
    { Nume: string
      AnStudiu: int
      Medie: float }

let studenti =
    [ { Nume = "Vlad"; AnStudiu = 3; Medie = 8.50 }
      { Nume = "Ana"; AnStudiu = 3; Medie = 9.80 }
      { Nume = "Ion"; AnStudiu = 2; Medie = 7.90 }
      { Nume = "Ana"; AnStudiu = 2; Medie = 9.10 } ]

let sortati = studenti |> List.sort

for s in sortati do
    printfn "%s (anul %d) — media %.2f" s.Nume s.AnStudiu s.Medie
