// Exercițiul 6, Tema 3 - Cititor de configurare cu acumulare de erori
// Capitolul 13 - Gestionarea erorilor în stil funcțional
// Rulare: dotnet fsi fsharp/cap13-gestionarea-erorilor-functional/tema-de-casa-3.fsx

type AppConfig =
    { Host: string
      Port: int
      Database: string
      MaxConnections: int }

// Parsarea: fiecare linie "cheie=valoare" devine o intrare în Map;
// liniile malformate sunt semnalate toate, nu doar prima.
let parseaza (continut: string) : Result<Map<string, string>, string list> =
    let linii =
        continut.Split('\n')
        |> Array.map (fun l -> l.Trim())
        |> Array.filter (fun l -> l <> "" && not (l.StartsWith("#")))
        |> Array.toList

    let rezultate =
        linii
        |> List.mapi (fun i linie ->
            match linie.Split('=', 2) with
            | [| cheie; valoare |] when cheie.Trim() <> "" -> Ok (cheie.Trim(), valoare.Trim())
            | _ -> Error $"Linia {i + 1} este malformată: '{linie}'")

    let erori = rezultate |> List.choose (function Error e -> Some e | Ok _ -> None)
    if erori.IsEmpty then
        Ok (rezultate |> List.choose (function Ok kv -> Some kv | Error _ -> None) |> Map.ofList)
    else
        Error erori

// Validatoare independente pentru câmpuri
let cheieText (config: Map<string, string>) cheie =
    match config |> Map.tryFind cheie with
    | None -> Error $"Cheia obligatorie '{cheie}' lipsește"
    | Some "" -> Error $"'{cheie}' nu poate fi gol"
    | Some valoare -> Ok valoare

// Porturile și numărul de conexiuni sunt numere naturale nenule
let cheieNumar (config: Map<string, string>) cheie =
    cheieText config cheie
    |> Result.bind (fun valoare ->
        match System.Int32.TryParse(valoare) with
        | true, n when n > 0 -> Ok n
        | _ -> Error $"'{cheie}' trebuie să fie un număr: '{valoare}'")

let eroareDin rezultat =
    match rezultat with
    | Error e -> [ e ]
    | Ok _ -> []

// Validarea cu acumulare: toate câmpurile sunt verificate, erorile se adună într-o listă
let valideaza (config: Map<string, string>) : Result<AppConfig, string list> =
    let host = cheieText config "host"
    let port = cheieNumar config "port"
    let database = cheieText config "database"
    let maxConn = cheieNumar config "max_connections"

    match host, port, database, maxConn with
    | Ok h, Ok p, Ok d, Ok m -> Ok { Host = h; Port = p; Database = d; MaxConnections = m }
    | _ -> Error (eroareDin host @ eroareDin port @ eroareDin database @ eroareDin maxConn)

let citesteConfigurare continut = parseaza continut |> Result.bind valideaza

// Conținutul a trei fișiere de configurare
let configuratii =
    [ """# configurare completă
host=localhost
port=8080
database=studenti
max_connections=50"""
      """host=db.upt.ro
port=abc
max_connections=-1"""
      """host=
port=5432
# lipsesc database și max_connections""" ]

printfn "=== Cititor de configurare ==="
configuratii
|> List.iteri (fun i continut ->
    match citesteConfigurare continut with
    | Ok c ->
        printfn "  Config %d -> OK:" (i + 1)
        printfn "    Host: %s, Port: %d, DB: %s, MaxConn: %d" c.Host c.Port c.Database c.MaxConnections
    | Error erori ->
        printfn "  Config %d -> ERORI:" (i + 1)
        erori |> List.iter (printfn "    - %s"))
