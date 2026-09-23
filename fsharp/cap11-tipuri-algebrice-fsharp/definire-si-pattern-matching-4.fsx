type Culoare =
    | RGB of r: int * g: int * b: int
    | Denumire of string

let c1 = RGB(255, 0, 0)
let c2 = RGB(255, 0, 0)
let c3 = Denumire "roșu"

printfn "c1 = c2: %b" (c1 = c2) // true
printfn "c1 = c3: %b" (c1 = c3) // false — cazuri diferite
