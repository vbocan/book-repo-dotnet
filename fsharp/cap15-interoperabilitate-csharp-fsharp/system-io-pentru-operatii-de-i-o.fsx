open System.IO

// Pregătirea datelor de test
let continutCSV = [|
    "Nume,An,Medie"
    "Ana Popescu,3,9.50"
    "Ion Marinescu,3,7.80"
    "Maria Dragomir,2,9.20"
    "Vlad Ionescu,2,4.50"
    "Elena Voinescu,3,8.90"
|]
File.WriteAllLines("catalog.csv", continutCSV)

// Citirea și procesarea funcțională a fișierului CSV
type StudentCSV = { Nume: string; An: int; Medie: float }

let studenti =
    File.ReadAllLines("catalog.csv")
    |> Array.skip 1  // Sare peste antet
    |> Array.map (fun linie ->
        let p = linie.Split(',')
        { Nume = p[0]; An = int p[1]; Medie = float p[2] })

let promovati =
    studenti
    |> Array.filter (fun s -> s.Medie >= 5.0)
    |> Array.sortByDescending (fun s -> s.Medie)

printfn "=== Studenți promovați (din CSV) ==="
for s in promovati do
    printfn "  %s — anul %d, media %.2f" s.Nume s.An s.Medie

// Scriere rezultate într-un fișier nou
let liniiRezultat =
    promovati
    |> Array.map (fun s -> $"{s.Nume},{s.An},{s.Medie:F2}")
    |> Array.append [| "Nume,An,Medie" |]

File.WriteAllLines("promovati.csv", liniiRezultat)
printfn "Fișier 'promovati.csv' scris (%d studenți)" promovati.Length

// Curățare
File.Delete("catalog.csv")
File.Delete("promovati.csv")
