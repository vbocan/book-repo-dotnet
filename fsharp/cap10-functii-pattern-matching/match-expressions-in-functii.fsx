// Cu match explicit
let descrieMatch x =
    match x with
    | 0 -> "zero"
    | n when n > 0 -> "pozitiv"
    | _ -> "negativ"

// Cu function (echivalent, dar mai concis)
let descrieFunction = function
    | 0 -> "zero"
    | n when n > 0 -> "pozitiv"
    | _ -> "negativ"

printfn "%s" (descrieMatch 5)
printfn "%s" (descrieFunction 5)
printfn "%s" (descrieFunction -3)
