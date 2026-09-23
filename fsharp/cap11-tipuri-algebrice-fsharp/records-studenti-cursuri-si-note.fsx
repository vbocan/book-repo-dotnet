// Exercițiul 1 — Records: studenți, cursuri și note
// Capitolul 11: Tipuri algebrice în F#
// Rulare: dotnet fsi fsharp/cap11-tipuri-algebrice-fsharp/records-studenti-cursuri-si-note.fsx

type Student = { Nume: string; AnStudiu: int; Medie: float }
type Curs = { Denumire: string; Credite: int }
type Nota = { Student: Student; Curs: Curs; Valoare: int }

// Instanțiere: tipul este dedus din numele câmpurilor
let ana = { Nume = "Ana Popescu"; AnStudiu = 3; Medie = 9.50 }
let ion = { Nume = "Ion Marinescu"; AnStudiu = 3; Medie = 7.50 }

let dotnet = { Denumire = "Programare .NET"; Credite = 5 }
let bazeDeDate = { Denumire = "Baze de date"; Credite = 5 }

let note =
    [ { Student = ana; Curs = dotnet; Valoare = 10 }
      { Student = ana; Curs = bazeDeDate; Valoare = 9 }
      { Student = ion; Curs = dotnet; Valoare = 8 }
      { Student = ion; Curs = bazeDeDate; Valoare = 7 } ]

let descrieNota nota =
    $"{nota.Student.Nume} — {nota.Curs.Denumire}: {nota.Valoare}"

let descrieStudent s =
    sprintf "%s, anul %d, media %.2f" s.Nume s.AnStudiu s.Medie

printfn "=== Catalog ==="
for nota in note do
    printfn "  %s" (descrieNota nota)

// Copiere cu modificare: originalul rămâne neschimbat
let anaAnul4 = { ana with AnStudiu = 4; Medie = 9.65 }

printfn "\n=== Promovare ==="
printfn "  Înainte: %s" (descrieStudent ana)
printfn "  După:    %s" (descrieStudent anaAnul4)

// Egalitate structurală: două record-uri cu aceleași câmpuri sunt egale
let ana2 = { Nume = "Ana Popescu"; AnStudiu = 3; Medie = 9.50 }

printfn "\n=== Comparare structurală ==="
printfn "  ana = ana2: %b" (ana = ana2)
printfn "  ana = anaAnul4: %b" (ana = anaAnul4)

printfn "\n=== Note descrescător ==="
for nota in note |> List.sortByDescending (fun n -> n.Valoare) do
    printfn "  %s" (descrieNota nota)

printfn "\n=== Medii ==="
for (student, noteStudent) in note |> List.groupBy (fun n -> n.Student) do
    let media = noteStudent |> List.averageBy (fun n -> float n.Valoare)
    printfn "  %s: %.2f" student.Nume media
