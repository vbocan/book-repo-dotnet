let rec factorial n =
    if n <= 1 then 1
    else n * factorial (n - 1)

printfn "5! = %d" (factorial 5)
printfn "10! = %d" (factorial 10)
