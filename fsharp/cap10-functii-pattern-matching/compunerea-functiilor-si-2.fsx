open System

let trim (s: string) = s.Trim()
let toLower (s: string) = s.ToLower()
let replaceSpaces (s: string) = s.Replace(' ', '_')

// Compunere: creează o funcție de procesare
let normalizeaza = trim >> toLower >> replaceSpaces

printfn "'%s'" (normalizeaza "  Hello World  ")
printfn "'%s'" (normalizeaza "  Programare .NET  ")
