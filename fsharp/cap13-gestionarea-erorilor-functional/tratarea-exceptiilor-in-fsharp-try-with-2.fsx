let incercaCitire cale : Result<string, string> =
    try
        Ok (System.IO.File.ReadAllText(cale))
    with
    | :? System.IO.FileNotFoundException ->
        Error $"Fișierul '{cale}' nu există"
    | :? System.IO.IOException as ex ->
        Error $"Eroare I/O: {ex.Message}"

printfn "%A" (incercaCitire "fisier_inexistent.txt")
