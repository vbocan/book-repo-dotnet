let citesteTextFisier cale =
    try
        let continut = System.IO.File.ReadAllText(cale)
        printfn "  Fișierul '%s' are %d caractere" cale continut.Length
    with
    | :? System.IO.FileNotFoundException as ex ->
        printfn "  Fișierul nu a fost găsit: %s" (System.IO.Path.GetFileName(ex.FileName))
    | :? System.IO.IOException as ex ->
        printfn "  Eroare I/O: %s" ex.Message
    | ex ->
        printfn "  Eroare neașteptată: %s" ex.Message

citesteTextFisier "fisier_inexistent.txt"
