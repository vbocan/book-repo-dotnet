let factorial n =
    let rec loop acc n =
        if n <= 1L then acc
        else loop (acc * n) (n - 1L)
    loop 1L n  // int64: 20! depășește domeniul int

let fibonacci n =
    let rec loop a b count =
        if count = 0 then a
        else loop b (a + b) (count - 1)
    loop 0L 1L n  // int64: fibonacci(50) depășește domeniul int

let inverseaza lista =
    let rec loop acc lst =
        match lst with
        | [] -> acc
        | x :: rest -> loop (x :: acc) rest
    loop [] lista

printfn "5! = %d, 20! = %d" (factorial 5L) (factorial 20L)
for i in 0..9 do printf "%d " (fibonacci i)
printfn ""
printfn "fibonacci(50) = %d" (fibonacci 50)
printfn "Inversare [1;2;3;4;5] = %A" (inverseaza [1; 2; 3; 4; 5])
