type Forma =
    | Cerc of raza: float
    | Dreptunghi of latime: float * inaltime: float
    | Triunghi of baza: float * inaltime: float

let arie forma =
    match forma with
    | Cerc raza -> System.Math.PI * raza * raza
    | Dreptunghi (latime, inaltime) -> latime * inaltime
    | Triunghi (baza, inaltime) -> baza * inaltime / 2.0

let forme = [Cerc 5.0; Dreptunghi (4.0, 6.0); Triunghi (3.0, 8.0)]

forme |> List.iter (fun f -> printfn "Aria: %.2f" (arie f))
