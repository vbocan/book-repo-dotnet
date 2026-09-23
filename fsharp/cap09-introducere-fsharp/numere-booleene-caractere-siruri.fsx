// Tipuri numerice
let intreg = 42                   // int
let lung = 100_000_000L           // int64 (separatorul _ pentru lizibilitate)
let dublu = 3.14159               // float (System.Double!)
let simplu = 2.71f                // float32 (System.Single)
let financiar = 19.99M            // decimal

// Tipuri logice și de caracter
let activ = true                  // bool
let litera = 'F'                  // char

// Operații aritmetice
let suma = intreg + 8             // 50
let produs = dublu * 2.0          // 6.28318
let restul = 17 % 5              // 2

printfn $"Întreg: {intreg}, Lung: {lung}"
printfn $"Dublu: {dublu}, Simplu: {simplu}, Decimal: {financiar}"
printfn "Caracter: %c, Activ: %b" litera activ
printfn $"Suma: {suma}, Produs: {produs}, Rest: {restul}"
