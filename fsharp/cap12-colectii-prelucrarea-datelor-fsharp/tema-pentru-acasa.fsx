// Temă pentru acasă, Tema 1 - Analiză de text
// Capitolul 12 - Colecții și prelucrarea datelor în F#
// Rulare: dotnet fsi fsharp/cap12-colectii-prelucrarea-datelor-fsharp/tema-pentru-acasa.fsx

let text =
    """Pe langa liste, un dictionar Map si un Set fara duplicate simplifica prelucrarea colectiilor.
In F# valorile sunt imutabile si functiile sunt pure.
Listele si colectiile imutabile sunt thread-safe implicit.
Sintaxa F# este eleganta si F# este preferata de studenti ca varianta functionala de studiu si de lucru.
F# este un limbaj concis care combina programarea functionala si programarea orientata pe obiecte.
Programarea functionala este populara, iar F# ofera tipuri verificate la compilare.
Modulele F# sustin structura aplicatiilor.
Stilul F# care evita starea mutabila produce programe usor de testat si de intretinut."""

// Împărțirea în cuvinte: separatorii sunt spațiile, punctuația și sfârșiturile de rând.
// Caracterul '#' nu este separator, deci "F#" rămâne un cuvânt.
let separatori = [| ' '; ','; '.'; ';'; ':'; '!'; '?'; '\r'; '\n' |]

let cuvinte =
    text.ToLower().Split(separatori, System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList

// Map: frecvența fiecărui cuvânt
let frecvente =
    cuvinte
    |> List.fold (fun (acc: Map<string, int>) cuvant ->
        let nr = acc |> Map.tryFind cuvant |> Option.defaultValue 0
        acc |> Map.add cuvant (nr + 1)) Map.empty

printfn "=== Analiză de text ==="
printfn "Total cuvinte: %d" cuvinte.Length

// Top 10: cuvintele distincte, în ordinea primei apariții în text, sortate descrescător
// după frecvența din Map. List.sortByDescending este stabilă, deci la frecvențe egale
// rămâne primul cuvântul care apare primul în text.
printfn "\nTop 10 cele mai frecvente cuvinte:"
cuvinte
|> List.distinct
|> List.map (fun cuvant -> cuvant, frecvente[cuvant])
|> List.sortByDescending snd
|> List.truncate 10
|> List.iteri (fun i (cuvant, nr) -> printfn "  %2d. %-16s: %d apariții" (i + 1) cuvant nr)

// Set: vocabularul (cuvintele distincte), respectiv hapax legomena (cuvintele care apar o singură dată)
let unice = cuvinte |> Set.ofList
let hapax = frecvente |> Map.filter (fun _ nr -> nr = 1) |> Map.keys |> Set.ofSeq

let procent = float unice.Count * 100.0 / float cuvinte.Length
printfn "\nCuvinte unice: %d din %d total (%.0f%% vocabular)" unice.Count cuvinte.Length procent

// %A afișează doar primele elemente ale unei mulțimi mari, urmate de "...".
// Lățimea 200 (%200A) păstrează afișarea pe un singur rând.
printfn "Hapax legomena (%d cuvinte): %200A" hapax.Count hapax
