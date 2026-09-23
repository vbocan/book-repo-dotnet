module Matematica =
    let pi = System.Math.PI
    let patrat x = x * x
    let cub x = x * x * x
    let factorial n =
        let rec loop acc n =
            if n <= 1 then acc
            else loop (acc * n) (n - 1)
        loop 1 n

open Matematica

printfn "PI = %.6f" pi
printfn "5² = %d" (patrat 5)
printfn "3³ = %d" (cub 3)
printfn "6! = %d" (factorial 6)
