let studenti = ["Ana"; "Ion"; "Maria"]
let note = [9.5; 7.3; 8.8]

let catalog = List.zip studenti note
printfn "Catalog: %A" catalog

let (numeDezlipite, noteDezlipite) = List.unzip catalog
printfn "Nume: %A" numeDezlipite
printfn "Note: %A" noteDezlipite
