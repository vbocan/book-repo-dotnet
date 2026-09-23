// Tema 3 — Registru de studenți cu Option
// Capitolul 9: Introducere în F#
// Rulare: dotnet fsi fsharp/cap09-introducere-fsharp/tema-pentru-acasa-3.fsx

// Fiecare student este un tuplu (nume, an de studiu, medie)
let studenti =
    [ ("Ana Popescu", 3, 9.5)
      ("Ion Marinescu", 2, 7.5)
      ("Elena Dragomir", 3, 9.2)
      ("Vlad Ionescu", 1, 7.0)
      ("Maria Luca", 3, 8.7)
      ("Andrei Popa", 2, 6.8) ]

let descrie (nume, an, medie) =
    $"{nume} (anul {an}, media {medie})"

// Căutare parțială, insensibilă la majuscule; returnează Option
let cautaDupaNume (text: string) lista =
    lista
    |> List.tryFind (fun (nume: string, _, _) -> nume.ToLower().Contains(text.ToLower()))

// Studenții dintr-un an de studiu
let dinAnul an lista =
    lista |> List.filter (fun (_, a, _) -> a = an)

// Studentul cu media cea mai mare; None pentru lista goală
let celMaiBun lista =
    match lista with
    | [] -> None
    | _ -> Some(lista |> List.maxBy (fun (_, _, medie) -> medie))

// Media unei liste de studenți; None pentru lista goală
let mediaGrupei lista =
    match lista with
    | [] -> None
    | _ -> Some(lista |> List.averageBy (fun (_, _, medie) -> medie))

printfn "=== Registru de studenți ==="

for text in [ "elena"; "gheorghe" ] do
    printfn $"\nCăutare \"{text}\":"
    match cautaDupaNume text studenti with
    | Some student -> printfn $"  {descrie student}"
    | None -> printfn "  Nu a fost găsit."

for an in [ 3; 4 ] do
    printfn $"\nStudenți anul {an}:"
    match dinAnul an studenti with
    | [] -> printfn $"  Niciun student în anul {an}."
    | grupa ->
        for student in grupa do
            printfn $"  {descrie student}"

printfn "\nCel mai bun student:"
match celMaiBun studenti with
| Some student -> printfn $"  {descrie student}"
| None -> printfn "  Registrul este gol."

printfn "\nMedia pe an de studiu:"
let ani = studenti |> List.map (fun (_, an, _) -> an) |> List.distinct |> List.sort
for an in ani do
    let grupa = dinAnul an studenti
    let eticheta = if List.length grupa = 1 then "student" else "studenți"
    match mediaGrupei grupa with
    | Some media -> printfn "  Anul %d: media %.2f (%d %s)" an media (List.length grupa) eticheta
    | None -> ()
