type Student = { Nume: string; AnStudiu: int; Medie: float }

let csvLinii = [|
    "Nume,AnStudiu,Medie"
    "Ana Popescu,3,9.20"
    "Mihai Ionescu,2,7.30"
    "Elena Dragomir,3,9.50"
    "Andrei Munteanu,2,8.10"
    "Maria Luca,3,6.80"
    "Cristian Popa,2,5.90"
    "Ioana Stoica,3,8.75"
    "Dan Marinescu,2,9.00"
|]

let studenti =
    csvLinii
    |> Array.skip 1                       // ignorăm header-ul
    |> Array.map (fun linie ->
        let p = linie.Split(',')
        { Nume = p.[0].Trim()
          AnStudiu = int p.[1]
          Medie = float p.[2] })

printfn "=== Toți studenții ==="
studenti
|> Array.iter (fun s ->
    printfn "  %-20s anul %d  media %.2f" s.Nume s.AnStudiu s.Medie)
