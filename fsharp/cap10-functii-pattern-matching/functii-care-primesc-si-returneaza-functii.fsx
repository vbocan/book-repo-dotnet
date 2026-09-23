let aplicaDeDouaOri f x = f (f x)

let increment x = x + 1
let dublu x = x * 2

printfn "aplicaDeDouaOri increment 5 = %d" (aplicaDeDouaOri increment 5)
printfn "aplicaDeDouaOri dublu 3 = %d" (aplicaDeDouaOri dublu 3)
