let fibonacciTR n =
    let rec loop a b count =
        if count = 0 then a
        else loop b (a + b) (count - 1)
    loop 0L 1L n  // acumulatori int64: fibonacci(50) depășește int

for i in 0..9 do printf "%d " (fibonacciTR i)
printfn ""
printfn "fibonacci(50) = %d" (fibonacciTR 50)
