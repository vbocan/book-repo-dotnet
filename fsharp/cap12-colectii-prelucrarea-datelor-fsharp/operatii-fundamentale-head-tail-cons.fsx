let numere = [10; 20; 30; 40; 50]

printfn "Head: %d" (List.head numere)
printfn "Tail: %A" (List.tail numere)
printfn "Al doilea element: %d" (List.head (List.tail numere))
printfn "Lungime: %d" (List.length numere)
printfn "Este vidă: %b" (List.isEmpty numere)
printfn "[] este vidă: %b" (List.isEmpty [])
