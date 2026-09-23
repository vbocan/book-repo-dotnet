open System

// Funcții individuale de procesare text
let trim (s: string) = s.Trim()
let toLower (s: string) = s.ToLower()
let inlocuiesteSpatii (s: string) = s.Replace(' ', '_')
let limiteazaLungime n (s: string) = if s.Length > n then s[..n-1] else s

// Compunere: creează o funcție de normalizare
let normalizeaza = trim >> toLower >> inlocuiesteSpatii >> limiteazaLungime 20

// Folosire în pipeline-uri pe colecții
let titluri = ["  Hello World  "; "  Programare .NET  "; " F# Collections ARE Amazing "]

let normalizeazaTitluri = List.map normalizeaza

let rezultat = titluri |> normalizeazaTitluri
printfn "Titluri normalizate: %A" rezultat
