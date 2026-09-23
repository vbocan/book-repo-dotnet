let descriePunct (x, y) =
    match (x, y) with
    | (0, 0) -> "originea"
    | (x, 0) -> $"pe axa X la {x}"
    | (0, y) -> $"pe axa Y la {y}"
    | (x, y) -> $"punctul ({x}, {y})"

printfn "%s" (descriePunct (0, 0))
printfn "%s" (descriePunct (3, 0))
printfn "%s" (descriePunct (0, -2))
printfn "%s" (descriePunct (3, 4))
