// Tema 1 — Joc de cărți
// Capitolul 11: Tipuri algebrice în F#
// Rulare: dotnet fsi fsharp/cap11-tipuri-algebrice-fsharp/tema-pentru-acasa.fsx

type Culoare =
    | Inima
    | Romb
    | Trefla
    | Pica

type Rang =
    | As
    | Doi
    | Trei
    | Patru
    | Cinci
    | Sase
    | Sapte
    | Opt
    | Noua
    | Zece
    | Valet
    | Dama
    | Rege

type Carte = Culoare * Rang
type Mana = Carte list

let culori = [ Inima; Romb; Trefla; Pica ]
let ranguri = [ As; Doi; Trei; Patru; Cinci; Sase; Sapte; Opt; Noua; Zece; Valet; Dama; Rege ]

// Pachetul complet: fiecare culoare combinată cu fiecare rang
let pachetComplet () : Carte list =
    [ for c in culori do
          for r in ranguri do
              yield (c, r) ]

// As = 11, figuri = 10, restul valoarea nominală
let valoareRang rang =
    match rang with
    | As -> 11
    | Doi -> 2
    | Trei -> 3
    | Patru -> 4
    | Cinci -> 5
    | Sase -> 6
    | Sapte -> 7
    | Opt -> 8
    | Noua -> 9
    | Zece -> 10
    | Valet | Dama | Rege -> 10

let valoareMana (mana: Mana) =
    mana |> List.sumBy (fun (_, rang) -> valoareRang rang)

let simbolCuloare culoare =
    match culoare with
    | Inima -> "♥"
    | Romb -> "♦"
    | Trefla -> "♣"
    | Pica -> "♠"

let simbolRang rang =
    match rang with
    | As -> "A"
    | Valet -> "J"
    | Dama -> "Q"
    | Rege -> "K"
    | _ -> string (valoareRang rang)

let afiseazaCarte ((culoare, rang): Carte) = simbolRang rang + simbolCuloare culoare

let afiseazaMana (mana: Mana) =
    mana |> List.map afiseazaCarte |> String.concat " "

let pachet = pachetComplet ()
printfn "Pachet complet: %d cărți" (List.length pachet)

// Mâini fixe, pentru un rezultat reproductibil (un joc real ar amesteca pachetul)
let mana1: Mana = [ (Trefla, Cinci); (Pica, Doi); (Romb, Noua); (Pica, Sapte); (Romb, Sase) ]
let mana2: Mana = [ (Pica, Sase); (Trefla, As); (Inima, Trei); (Romb, Doi); (Pica, Valet) ]

let v1 = valoareMana mana1
let v2 = valoareMana mana2

printfn "\nMâna 1: %s (valoare: %d)" (afiseazaMana mana1) v1
printfn "Mâna 2: %s (valoare: %d)" (afiseazaMana mana2) v2

if v1 > v2 then printfn "Mâna 1 câștigă!"
elif v2 > v1 then printfn "Mâna 2 câștigă!"
else printfn "Egalitate!"
