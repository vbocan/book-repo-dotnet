// Record F# — poate fi consumat direct din C# ca o clasă sealed
type StudentF = { Nume: string; An: int; Medie: float }

// Utilizarea unui record F#
let student = { Nume = "Ana"; An = 3; Medie = 9.5 }
let modificat = { student with Medie = 9.8 }
printfn "Original: %A" student
printfn "Modificat: %A" modificat
printfn "Egale: %b" (student = modificat)
