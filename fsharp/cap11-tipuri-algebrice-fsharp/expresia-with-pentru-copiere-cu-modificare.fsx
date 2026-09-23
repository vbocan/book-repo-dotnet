type Student =
    { Nume: string
      AnStudiu: int
      Medie: float }

let maria = { Nume = "Maria Popescu"; AnStudiu = 3; Medie = 9.50 }

// Maria trece în anul 4 cu o medie actualizată
let mariaAnul4 = { maria with AnStudiu = 4; Medie = 9.65 }

printfn "Original: %s, anul %d, media %.2f" maria.Nume maria.AnStudiu maria.Medie
printfn "Actualizat: %s, anul %d, media %.2f" mariaAnul4.Nume mariaAnul4.AnStudiu mariaAnul4.Medie
printfn "Sunt același obiect? %b" (obj.ReferenceEquals(maria, mariaAnul4))
