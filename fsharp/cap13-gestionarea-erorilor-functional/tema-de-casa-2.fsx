// Exercițiul 6, Tema 2 - Pipeline de procesare comenzi
// Capitolul 13 - Gestionarea erorilor în stil funcțional
// Rulare: dotnet fsi fsharp/cap13-gestionarea-erorilor-functional/tema-de-casa-2.fsx

type Produs = { Cod: string; Nume: string; Pret: float }

type LinieComanda = { CodProdus: string; Cantitate: int }

// O comandă validată conține produsele găsite în catalog, cu cantitățile cerute
type ComandaValidata = { Linii: (Produs * int) list }

type ComandaCalculata =
    { Linii: (Produs * int) list
      Total: float }

type ComandaFinala =
    { Linii: (Produs * int) list
      Total: float
      Discount: float // procent
      Final: float }

let catalog =
    [ { Cod = "P01"; Nume = "Laptop"; Pret = 3500.0 }
      { Cod = "P02"; Nume = "Mouse"; Pret = 75.0 }
      { Cod = "P03"; Nume = "Tastatură"; Pret = 250.0 } ]
    |> List.map (fun p -> p.Cod, p)
    |> Map.ofList

let stoc = Map.ofList [ ("P01", 10); ("P02", 50); ("P03", 0) ]

// Pasul 1: comanda nu e goală, produsele există, cantitățile sunt pozitive
let valideazaComanda (linii: LinieComanda list) : Result<ComandaValidata, string> =
    let valideazaLinie (l: LinieComanda) =
        match catalog |> Map.tryFind l.CodProdus with
        | None -> Error $"Produsul '{l.CodProdus}' nu există în catalog"
        | Some _ when l.Cantitate <= 0 -> Error $"Cantitate nevalidă pentru '{l.CodProdus}': {l.Cantitate}"
        | Some p -> Ok (p, l.Cantitate)

    if List.isEmpty linii then
        Error "Comanda nu conține produse"
    else
        // Oprire la prima linie invalidă
        linii
        |> List.fold (fun acc l ->
            acc |> Result.bind (fun valide ->
                valideazaLinie l |> Result.map (fun linie -> valide @ [ linie ]))) (Ok [])
        |> Result.map (fun valide -> { ComandaValidata.Linii = valide })

// Pasul 2: fiecare produs trebuie să aibă stoc suficient
let verificaStoc (comanda: ComandaValidata) : Result<ComandaValidata, string> =
    let lipsa =
        comanda.Linii
        |> List.tryFind (fun (p, cantitate) -> cantitate > (stoc |> Map.tryFind p.Cod |> Option.defaultValue 0))

    match lipsa with
    | Some (p, cantitate) ->
        let disponibil = stoc |> Map.tryFind p.Cod |> Option.defaultValue 0
        Error $"Stoc insuficient pentru '{p.Nume}': disponibil {disponibil}, cerut {cantitate}"
    | None -> Ok comanda

// Pasul 3: totalul comenzii
let calculeazaTotal (comanda: ComandaValidata) : Result<ComandaCalculata, string> =
    let total = comanda.Linii |> List.sumBy (fun (p, cantitate) -> p.Pret * float cantitate)
    if total <= 0.0 then Error "Totalul comenzii trebuie să fie pozitiv"
    else Ok { Linii = comanda.Linii; Total = total }

// Pasul 4: discount de 10% pentru comenzile de cel puțin 5000 RON
let aplicaDiscount (comanda: ComandaCalculata) : Result<ComandaFinala, string> =
    let discount = if comanda.Total >= 5000.0 then 10.0 else 0.0
    Ok { Linii = comanda.Linii
         Total = comanda.Total
         Discount = discount
         Final = comanda.Total - comanda.Total * discount / 100.0 }

let proceseazaComanda linii =
    valideazaComanda linii
    |> Result.bind verificaStoc
    |> Result.bind calculeazaTotal
    |> Result.bind aplicaDiscount

let comenzi =
    [ "Comanda 1 (validă, cu discount)", [ { CodProdus = "P01"; Cantitate = 2 }; { CodProdus = "P02"; Cantitate = 3 } ]
      "Comanda 2 (produs inexistent)", [ { CodProdus = "P01"; Cantitate = 1 }; { CodProdus = "P99"; Cantitate = 1 } ]
      "Comanda 3 (stoc insuficient)", [ { CodProdus = "P02"; Cantitate = 1 }; { CodProdus = "P03"; Cantitate = 5 } ]
      "Comanda 4 (goală)", [] ]

// %g afișează numerele fără zecimale inutile (7000, dar 6502.5)
printfn "=== Procesare comenzi ==="
for (titlu, linii) in comenzi do
    printfn "\n%s:" titlu
    match proceseazaComanda linii with
    | Ok c ->
        printfn "  Produse:"
        for (p, cantitate) in c.Linii do
            printfn "    %s x%d = %g RON" p.Nume cantitate (p.Pret * float cantitate)
        printfn "  Total: %g RON | Discount: %g%% | Final: %g RON" c.Total c.Discount c.Final
    | Error mesaj ->
        printfn "  EROARE: %s" mesaj
