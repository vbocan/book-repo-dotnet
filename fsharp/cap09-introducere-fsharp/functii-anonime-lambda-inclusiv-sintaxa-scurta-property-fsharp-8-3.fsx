type Student = { Nume: string; Varsta: int; Media: float }

let studenti = [
    { Nume = "Ana"; Varsta = 22; Media = 9.5 }
    { Nume = "Ion"; Varsta = 21; Media = 8.2 }
    { Nume = "Maria"; Varsta = 23; Media = 9.8 }
    { Nume = "Vlad"; Varsta = 22; Media = 7.5 }
]

// Sintaxa tradițională
let sortatiTraditional = studenti |> List.sortBy (fun s -> s.Media)

// Sintaxa scurtă F# 8+ (_.Property)
let sortatiNou = studenti |> List.sortBy _.Media

// Extragerea numelor cu sintaxa scurtă
let nume = studenti |> List.map _.Nume

printfn "Studenți sortați după medie:"
sortatiNou |> List.iter (fun s -> printfn $"  {s.Nume}: {s.Media}")
printfn $"Nume: %A{nume}"
