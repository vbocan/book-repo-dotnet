// Exercițiul 4 - try-with și conversia la Result
// Capitolul 13 - Gestionarea erorilor în stil funcțional
// Rulare: dotnet fsi fsharp/cap13-gestionarea-erorilor-functional/try-with-si-conversia-la-result.fsx
// Fișierul de configurare citit: try-with-si-conversia-la-result-config.txt (în același folder)

open System.IO

type ResultBuilder() =
    member _.Bind(result, f) = Result.bind f result
    member _.Return(value) = Ok value
    member _.ReturnFrom(result) = result

let result = ResultBuilder()

// Granița I/O: excepțiile sunt prinse și transformate în Result
let citesteFisier (cale: string) : Result<string, string> =
    let nume = Path.GetFileName(cale)
    try
        Ok (File.ReadAllText(cale))
    with
    | :? FileNotFoundException -> Error $"Fișierul '{nume}' nu a fost găsit"
    | :? DirectoryNotFoundException -> Error $"Folderul fișierului '{nume}' nu a fost găsit"
    | :? IOException as ex -> Error $"Eroare I/O: {ex.Message}"
    | :? System.UnauthorizedAccessException -> Error $"Acces interzis la fișierul '{nume}'"

// Parsarea perechilor cheie=valoare; comentariile (#) și liniile goale sunt ignorate
let parseazaConfigurare (continut: string) : Result<Map<string, string>, string> =
    let linii =
        continut.Split('\n')
        |> Array.map (fun l -> l.Trim())
        |> Array.filter (fun l -> l <> "" && not (l.StartsWith("#")))
        |> Array.toList

    let parseazaLinie (linie: string) =
        match linie.Split('=', 2) with
        | [| cheie; valoare |] when cheie.Trim() <> "" -> Ok (cheie.Trim(), valoare.Trim())
        | _ -> Error $"Linie malformată: '{linie}'"

    // Oprire la prima linie malformată (scurt-circuit cu bind)
    linii
    |> List.fold (fun acc linie ->
        acc |> Result.bind (fun (config: Map<string, string>) ->
            parseazaLinie linie |> Result.map (fun (k, v) -> config |> Map.add k v))) (Ok Map.empty)

let incarcaConfigurare cale =
    result {
        let! continut = citesteFisier cale
        let! config = parseazaConfigurare continut
        return config
    }

let afiseaza rezultat =
    match rezultat with
    | Ok (config: Map<string, string>) ->
        printfn "  Config parsată:"
        config |> Map.iter (fun cheie valoare -> printfn "    %s = %s" cheie valoare)
    | Error mesaj ->
        printfn "  Eroare: %s" mesaj

printfn "=== Citire configurare ==="
afiseaza (incarcaConfigurare (Path.Combine(__SOURCE_DIRECTORY__, "config_inexistent.txt")))
printfn ""
afiseaza (incarcaConfigurare (Path.Combine(__SOURCE_DIRECTORY__, "try-with-si-conversia-la-result-config.txt")))
