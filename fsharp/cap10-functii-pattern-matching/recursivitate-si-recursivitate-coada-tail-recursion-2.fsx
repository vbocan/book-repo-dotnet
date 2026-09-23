// Versiunea NON-tail recursive: n * factorial(n-1) — înmulțirea
// se face DUPĂ apelul recursiv, deci apelul NU este de coadă
let rec factorialNaiv n =
    if n <= 1 then 1
    else n * factorialNaiv (n - 1)

// Versiunea tail-recursive: folosește un acumulator
// Apelul recursiv este ULTIMA operație — este de coadă
// Tipul int64 (literali cu sufix L) evită depășirea pentru 20!
let factorialTR n =
    let rec loop acc n =
        if n <= 1L then acc
        else loop (acc * n) (n - 1L)
    loop 1L n

printfn "Naiv: 10! = %d" (factorialNaiv 10)
printfn "Tail-rec: 10! = %d" (factorialTR 10L)
printfn "Tail-rec: 20! = %d" (factorialTR 20L)
