let descrie x =
    match x with
    | 0 -> "zero"
    | 1 -> "unu"
    | 2 -> "doi"
    | _ -> "altceva"

printfn "%s" (descrie 0)
printfn "%s" (descrie 1)
printfn "%s" (descrie 42)
