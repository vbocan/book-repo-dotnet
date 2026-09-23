// Exercițiul 9.2 — Inferența tipurilor și funcții

// Funcții simple — observați tipurile inferate
let aduna x y = x + y                  // int -> int -> int
let estePozitiv x = x > 0              // int -> bool
let salut nume = $"Salut, {nume}!"     // string -> string

// Funcții generice — compilatorul generalizează automat
let identitate x = x                   // 'a -> 'a
let primul (a, _) = a                  // 'a * 'b -> 'a
let aplica f x = f x                   // ('a -> 'b) -> 'a -> 'b

printfn "=== Funcții și inferență ==="
printfn $"aduna 3 5 = {aduna 3 5}"
printfn "estePozitiv 7 = %b" (estePozitiv 7)
printfn "estePozitiv (-3) = %b" (estePozitiv (-3))
printfn "salut \"Maria\" = %s" (salut "Maria")

printfn $"\nidentitate 42 = {identitate 42}"
printfn "identitate \"F#\" = %s" (identitate "F#")
printfn "primul (10, \"zece\") = %d" (primul (10, "zece"))
printfn "aplica estePozitiv 5 = %b" (aplica estePozitiv 5)

// Funcție cu expresie if-then-else
let clasificareNota nota =
    if nota >= 9 then "Excelent"
    elif nota >= 7 then "Bine"
    elif nota >= 5 then "Satisfăcător"
    else "Insuficient"

printfn "\n=== Clasificare note ==="
for n in [10; 8; 6; 4] do
    printfn $"  Nota {n}: {clasificareNota n}"
