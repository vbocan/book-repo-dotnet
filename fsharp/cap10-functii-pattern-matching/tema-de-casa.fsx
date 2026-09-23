let fizzBuzz n =
    match (n % 3, n % 5) with
    | (0, 0) -> "FizzBuzz"
    | (0, _) -> "Fizz"
    | (_, 0) -> "Buzz"
    | _ -> string n

for i in 1..30 do printf "%s " (fizzBuzz i)
printfn ""
