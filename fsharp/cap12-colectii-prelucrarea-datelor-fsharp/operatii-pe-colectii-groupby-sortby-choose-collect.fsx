// Exercițiul 2 - Operații pe colecții: groupBy, sortBy, choose, collect
// Capitolul 12 - Colecții și prelucrarea datelor în F#
// Rulare: dotnet fsi fsharp/cap12-colectii-prelucrarea-datelor-fsharp/operatii-pe-colectii-groupby-sortby-choose-collect.fsx

open System.Globalization

type Produs =
    { Nume: string
      Categorie: string
      Pret: float
      Stoc: int }

let produse =
    [ { Nume = "Laptop"; Categorie = "Electronice"; Pret = 3500.0; Stoc = 15 }
      { Nume = "Mouse"; Categorie = "Electronice"; Pret = 120.0; Stoc = 200 }
      { Nume = "Tastatura"; Categorie = "Electronice"; Pret = 250.0; Stoc = 150 }
      { Nume = "Monitor"; Categorie = "Electronice"; Pret = 1800.0; Stoc = 0 }
      { Nume = "Caiet A4"; Categorie = "Papetărie"; Pret = 8.5; Stoc = 500 }
      { Nume = "Pix"; Categorie = "Papetărie"; Pret = 3.5; Stoc = 1000 }
      { Nume = "Agenda"; Categorie = "Papetărie"; Pret = 25.0; Stoc = 300 }
      { Nume = "Rucsac"; Categorie = "Accesorii"; Pret = 180.0; Stoc = 45 }
      { Nume = "Casti"; Categorie = "Electronice"; Pret = 350.0; Stoc = 80 } ]

// 1. groupBy: produsele grupate pe categorii, cu valoarea stocului fiecărei categorii.
//    List.groupBy păstrează ordinea în care apare prima dată fiecare cheie.
printfn "=== Produse pe categorii ==="
produse
|> List.groupBy (fun p -> p.Categorie)
|> List.iter (fun (categorie, lista) ->
    let valoareStoc = lista |> List.sumBy (fun p -> p.Pret * float p.Stoc)
    printfn "  %s (%d produse, valoare stoc: %.0f RON):" categorie lista.Length valoareStoc
    for p in lista do
        printfn "    - %s: %.2f RON (stoc: %d)" p.Nume p.Pret p.Stoc)

// 2. choose: filtrare și transformare într-un singur pas.
//    Reducerea de 10% se aplică produselor aflate în stoc, de cel puțin 100 RON.
let aplicaReducere (p: Produs) =
    if p.Stoc > 0 && p.Pret >= 100.0 then Some(p.Nume, p.Pret, p.Pret * 0.9)
    else None

printfn "\n=== Produse cu reducere (doar cele în stoc) ==="
produse
|> List.choose aplicaReducere
|> List.iter (fun (nume, pretVechi, pretNou) ->
    printfn "  %s: %.2f RON -> %.2f RON (-10%%)" nume pretVechi pretNou)

// 3. sortByDescending: cele mai scumpe trei produse aflate în stoc
printfn "\n=== Top 3 cele mai scumpe (în stoc) ==="
produse
|> List.filter (fun p -> p.Stoc > 0)
|> List.sortByDescending (fun p -> p.Pret)
|> List.take 3
|> List.iteri (fun i p -> printfn "  %d. %s — %.2f RON" (i + 1) p.Nume p.Pret)

// 4. collect: fiecare produs produce mai multe linii de etichetă, apoi listele se aplatizează.
//    Formatul "N2" cu cultura invariantă afișează separatorul de mii (3,500.00).
let eticheta (p: Produs) =
    [ sprintf "  [%s] %s" p.Categorie p.Nume
      sprintf "    Preț: %s RON | Stoc: %d buc." (p.Pret.ToString("N2", CultureInfo.InvariantCulture)) p.Stoc
      "    ---" ]

printfn "\n=== Etichete (primele 3 produse) ==="
produse
|> List.take 3
|> List.collect eticheta
|> List.iter (printfn "%s")
