type Produs = { Nume: string; Categorie: string; Pret: decimal; Stoc: int }

let csvProduse = [|
    "Nume,Categorie,Pret,Stoc"
    "Laptop Dell,Electronice,3500,15"; "Monitor LG,Electronice,1200,30"
    "SSD 1TB,Electronice,500,60";     "Tastatură,Periferice,250,50"
    "Mouse wireless,Periferice,120,80"; "Webcam HD,Periferice,300,40"
    "Căști Sony,Audio,450,25";        "Microfon USB,Audio,380,20"
|]

let produse =
    csvProduse
    |> Array.skip 1
    |> Array.map (fun linie ->
        let p = linie.Split(',')
        { Nume = p.[0]; Categorie = p.[1]; Pret = decimal p.[2]; Stoc = int p.[3] })

// Produse cu preț > 400, ordonate descrescător
printfn "=== Produse cu preț > 400 RON ==="
produse
|> Array.filter (fun p -> p.Pret > 400m)
|> Array.sortByDescending (fun p -> p.Pret)
|> Array.iter (fun p ->
    printfn "  %-18s %8.2f RON  (stoc: %d)" p.Nume p.Pret p.Stoc)

// Statistici pe categorie
printfn "\n=== Statistici pe categorie ==="
produse
|> Array.groupBy (fun p -> p.Categorie)
|> Array.sortBy fst
|> Array.iter (fun (cat, items) ->
    let valoareStoc = items |> Array.sumBy (fun p -> p.Pret * decimal p.Stoc)
    let pretMediu = items |> Array.averageBy (fun p -> float p.Pret)
    printfn "  %-14s %d produse, preț mediu: %.0f RON, valoare stoc: %.0f RON"
        cat items.Length pretMediu valoareStoc)

let valoareTotala = produse |> Array.sumBy (fun p -> p.Pret * decimal p.Stoc)
printfn "\n  Valoare totală stoc: %.0f RON" valoareTotala
