type StareSemafor =
    | Rosu
    | Galben
    | Verde

let durata stare =
    match stare with
    | Rosu -> 30
    | Galben -> 5
    | Verde -> 25

let urmatoarea stare =
    match stare with
    | Rosu -> Verde
    | Verde -> Galben
    | Galben -> Rosu

let mutable stare = Rosu

for _ in 1..6 do
    printfn "Semafor: %A (durată: %d secunde)" stare (durata stare)
    stare <- urmatoarea stare
