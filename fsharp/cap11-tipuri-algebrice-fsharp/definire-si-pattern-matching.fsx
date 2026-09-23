type Forma =
    | Cerc of raza: float
    | Dreptunghi of latime: float * inaltime: float
    | Triunghi of baza: float * inaltime: float

let aria forma =
    match forma with
    | Cerc r -> System.Math.PI * r * r
    | Dreptunghi(l, i) -> l * i
    | Triunghi(b, i) -> 0.5 * b * i

let forme = [ Cerc 5.0; Dreptunghi(4.0, 6.0); Triunghi(3.0, 8.0) ]

for f in forme do
    printfn "Aria: %.2f" (aria f)
