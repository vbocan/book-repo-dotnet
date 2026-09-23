open System.IO

// Scrierea unui fișier
File.WriteAllLines("studenti.txt",
    [| "Ana Popescu,9.50"
       "Ion Marinescu,7.80"
       "Maria Dragomir,9.20" |])

// Citirea și procesarea funcțională
let studenti =
    File.ReadAllLines("studenti.txt")
    |> Array.map (fun linie ->
        let parti = linie.Split(',')
        (parti[0], float parti[1]))

for (nume, medie) in studenti do
    printfn "  %s — media %.2f" nume medie

let medieGenerala = studenti |> Array.averageBy snd
printfn "Media generală: %.2f" medieGenerala

// Curățare
File.Delete("studenti.txt")
