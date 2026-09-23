type Student =
    { Nume: string
      AnStudiu: int
      Medie: float }

let maria = { Nume = "Maria Popescu"; AnStudiu = 3; Medie = 9.50 }
let ion = { Nume = "Ion Marinescu"; AnStudiu = 2; Medie = 8.75 }

printfn "Student: %s, anul %d, media %.2f" maria.Nume maria.AnStudiu maria.Medie
printfn "Student: %s, anul %d, media %.2f" ion.Nume ion.AnStudiu ion.Medie
