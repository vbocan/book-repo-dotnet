module Geometrie =
    type Forma =
        | Cerc of raza: float
        | Dreptunghi of latime: float * inaltime: float

    let aria forma =
        match forma with
        | Cerc r -> System.Math.PI * r * r
        | Dreptunghi(l, i) -> l * i

    let perimetru forma =
        match forma with
        | Cerc r -> 2.0 * System.Math.PI * r
        | Dreptunghi(l, i) -> 2.0 * (l + i)

    let descrie forma =
        match forma with
        | Cerc r -> $"Cerc(raza={r})"
        | Dreptunghi(l, i) -> $"Dreptunghi({l}×{i})"

// Utilizare cu calificare completă
let cerc = Geometrie.Cerc 5.0
printfn "%s: aria=%.2f, perimetru=%.2f"
    (Geometrie.descrie cerc)
    (Geometrie.aria cerc)
    (Geometrie.perimetru cerc)
