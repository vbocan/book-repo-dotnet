// Funcția identitate — compilatorul inferă tipul generic 'a -> 'a
let identitate x = x

// Funcția care returnează primul element dintr-o pereche
let primul (a, b) = a

// Funcția care creează o pereche
let pereche a b = (a, b)

printfn $"Identitate 42: {identitate 42}"
printfn "Identitate \"text\": %s" (identitate "text")
printfn "Primul din (1, \"abc\"): %d" (primul (1, "abc"))
printfn "Pereche: %O" (pereche 3 "F#")
