type Punct = { X: float; Y: float }

let p1 = { X = 3.0; Y = 4.0 }
let p2 = { X = 3.0; Y = 4.0 }
let p3 = { X = 1.0; Y = 2.0 }

printfn "p1 = p2: %b" (p1 = p2)           // true — aceleași valori
printfn "p1 = p3: %b" (p1 = p3)           // false — valori diferite
printfn "Referință identică: %b" (obj.ReferenceEquals(p1, p2))  // false — obiecte diferite
