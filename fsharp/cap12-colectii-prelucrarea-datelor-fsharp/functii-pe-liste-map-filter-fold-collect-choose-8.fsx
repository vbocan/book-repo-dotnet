type Student = { Nume: string; An: int; Medie: float }

let studenti =
    [ { Nume = "Ana Popescu"; An = 3; Medie = 9.50 }
      { Nume = "Ion Marinescu"; An = 3; Medie = 4.80 }
      { Nume = "Maria Dragomir"; An = 2; Medie = 9.20 }
      { Nume = "Vlad Ionescu"; An = 2; Medie = 6.30 }
      { Nume = "Elena Voinescu"; An = 3; Medie = 8.90 }
      { Nume = "Andrei Popa"; An = 2; Medie = 7.40 }
      { Nume = "Diana Rusu"; An = 3; Medie = 5.20 } ]

// Pipeline: studenții promovați din anul 3, sortați după medie, formatați
let rezultat =
    studenti
    |> List.filter (fun s -> s.An = 3 && s.Medie >= 5.0)
    |> List.sortByDescending (fun s -> s.Medie)
    |> List.map (fun s -> $"{s.Nume}: {s.Medie:F2}")

printfn "Studenți promovați din anul 3:"
rezultat |> List.iter (printfn "  %s")

// Media pe ani de studiu
printfn "\nMedia pe ani:"
studenti
|> List.groupBy (fun s -> s.An)
|> List.sortBy fst
|> List.iter (fun (an, studsAn) ->
    let medie = studsAn |> List.averageBy (fun s -> s.Medie)
    printfn "  Anul %d: %.2f (%d studenți)" an medie studsAn.Length)
