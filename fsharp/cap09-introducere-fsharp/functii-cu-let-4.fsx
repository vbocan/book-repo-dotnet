// Factorial recursiv
let rec factorial n =
    if n <= 1 then 1
    else n * factorial (n - 1)

// Fibonacci recursiv
let rec fibonacci n =
    if n <= 1 then n
    else fibonacci (n - 1) + fibonacci (n - 2)

printfn $"5! = {factorial 5}"
printfn $"10! = {factorial 10}"
printfn $"Fibonacci(10) = {fibonacci 10}"
