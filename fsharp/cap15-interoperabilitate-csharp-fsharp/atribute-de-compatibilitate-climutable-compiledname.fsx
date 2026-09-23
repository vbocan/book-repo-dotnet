// Fără [<CLIMutable>] — C# nu poate crea instanța cu constructor fără parametri
type StudentImutabil = { Nume: string; AnStudiu: int; Medie: float }

// Cu [<CLIMutable>] — C# poate folosi constructor fără parametri + setteri
[<CLIMutable>]
type Student = { Nume: string; AnStudiu: int; Medie: float }

// În F#, comportamentul este identic — imutabil
let ana = { Nume = "Ana Popescu"; AnStudiu = 3; Medie = 9.50 }
let anaProm = { ana with AnStudiu = 4 }
printfn "%s — anul %d, media %.2f" anaProm.Nume anaProm.AnStudiu anaProm.Medie
