let dublu x = x * 2
let increment x = x + 1
let patrat x = x * x

// Compunere stânga -> dreapta
let dubleazaSiIncrementeaza = dublu >> increment
let dubleazaSiRidicaLaPatrat = dublu >> patrat

printfn "dubleazaSiIncrementeaza 5 = %d" (dubleazaSiIncrementeaza 5)   // (5*2)+1 = 11
printfn "dubleazaSiRidicaLaPatrat 3 = %d" (dubleazaSiRidicaLaPatrat 3) // (3*2)^2 = 36
