open System

// --- Tipuri valoare: Option <-> Nullable ---
let nota: int option = Some 9
let notaLipsa: int option = None

// Către C# (Nullable<int>)
let notaNullable = Option.toNullable nota          // Nullable<int>(9)
let lipsaNullable = Option.toNullable notaLipsa    // Nullable<int>() — fără valoare

printfn "Option -> Nullable:"
printfn "  Some 9 -> HasValue=%b, Value=%A" notaNullable.HasValue notaNullable
printfn "  None -> HasValue=%b" lipsaNullable.HasValue

// De la C# (Nullable<int>)
let dinCSharp = Nullable<int>(7)
let dinCSharpGol = Nullable<int>()

let optiune1 = Option.ofNullable dinCSharp     // Some 7
let optiune2 = Option.ofNullable dinCSharpGol  // None

printfn "\nNullable -> Option:"
printfn "  Nullable(7) -> %A" optiune1
printfn "  Nullable() -> %A" optiune2

// --- Tipuri referință: Option <-> null ---
let text: string option = Some "salut"
let textGol: string option = None

let textObj = Option.toObj text       // "salut"
let golObj = Option.toObj textGol     // null

printfn "\nOption -> referință:"
printfn "  Some \"salut\" -> \"%s\"" textObj
printfn "  None -> %A" (box golObj)

let inapoi1 = Option.ofObj textObj    // Some "salut"
let inapoi2 = Option.ofObj golObj     // None

printfn "\nReferință -> Option:"
printfn "  \"salut\" -> %A" inapoi1
printfn "  null -> %A" inapoi2
