let multiplicator factor =
    fun x -> x * factor

let dublu = multiplicator 2
let triplu = multiplicator 3

printfn "dublu 7 = %d" (dublu 7)
printfn "triplu 7 = %d" (triplu 7)
