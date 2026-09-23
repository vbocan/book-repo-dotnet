let catalog =
    Map.empty
    |> Map.add "Ana" 9.50
    |> Map.add "Ion" 7.30
    |> Map.add "Maria" 8.80

printfn "Catalog: %A" catalog

// Căutare sigură cu tryFind
match Map.tryFind "Ana" catalog with
| Some nota -> printfn "Ana: %.2f" nota
| None -> printfn "Ana nu a fost găsită"

match Map.tryFind "Vlad" catalog with
| Some nota -> printfn "Vlad: %.2f" nota
| None -> printfn "Vlad nu a fost găsit"

// Adăugare și ștergere returnează Map nou
let catalogActualizat =
    catalog
    |> Map.add "Vlad" 6.50       // adaugă o intrare nouă
    |> Map.add "Ion" 8.00        // suprascrie valoarea lui Ion
    |> Map.remove "Maria"        // elimină Maria

printfn "\nCatalog actualizat: %A" catalogActualizat
printfn "Catalog original neschimbat: %A" catalog
