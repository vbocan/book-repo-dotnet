let fructe = Set.ofList ["măr"; "pară"; "banană"; "măr"; "portocală"; "pară"]
printfn "Fructe unice: %A" fructe
printfn "Conține 'măr': %b" (Set.contains "măr" fructe)
printfn "Conține 'kiwi': %b" (Set.contains "kiwi" fructe)
printfn "Număr: %d" (Set.count fructe)

let tropicale = Set.ofList ["banană"; "mango"; "papaya"; "portocală"]

printfn "\nUniune: %A" (Set.union fructe tropicale)
printfn "Intersecție: %A" (Set.intersect fructe tropicale)
printfn "Diferență (fructe - tropicale): %A" (Set.difference fructe tropicale)
