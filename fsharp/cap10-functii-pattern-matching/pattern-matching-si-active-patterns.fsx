// Active pattern: clasificare fișiere
let (|Imagine|Document|CodSursa|Necunoscut|) (fisier: string) =
    match System.IO.Path.GetExtension(fisier).ToLower() with
    | ".png" | ".jpg" | ".gif" | ".svg" -> Imagine
    | ".pdf" | ".docx" | ".txt" | ".md" -> Document
    | ".cs" | ".fs" | ".py" | ".js" -> CodSursa
    | _ -> Necunoscut

let procesare = function
    | Imagine -> "imagine" | Document -> "document"
    | CodSursa -> "cod sursă" | Necunoscut -> "necunoscut"

["foto.png"; "raport.pdf"; "main.fs"; "date.csv"]
|> List.iter (fun f -> printfn "  %-12s -> %s" f (procesare f))

// Active pattern parțial: parsare
let (|Intreg|_|) (s: string) =
    match System.Int32.TryParse(s) with
    | (true, v) -> Some v | _ -> None

let (|Real|_|) (s: string) =
    match System.Double.TryParse(s, System.Globalization.CultureInfo.InvariantCulture) with
    | (true, v) -> Some v | _ -> None

let parseaza = function
    | Intreg n -> $"Întreg: {n}" | Real r -> $"Real: {r:F2}" | s -> $"Text: \"{s}\""

["42"; "3.14"; "abc"] |> List.iter (fun v -> printfn "  %-6s -> %s" v (parseaza v))
