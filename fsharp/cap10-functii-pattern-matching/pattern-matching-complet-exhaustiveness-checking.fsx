type CuloareSemafor = Verde | Galben | Rosu

// Compilatorul emite avertisment FS0025: lipsește cazul Galben!
let actiuneIncompleta culoare =
    match culoare with
    | Verde -> "mergi"
    | Rosu -> "oprește"

// Versiunea corectă acoperă toate cazurile
let actiune culoare =
    match culoare with
    | Verde -> "mergi"
    | Galben -> "pregătește-te"
    | Rosu -> "oprește"

printfn "%s, %s, %s" (actiune Verde) (actiune Galben) (actiune Rosu)
