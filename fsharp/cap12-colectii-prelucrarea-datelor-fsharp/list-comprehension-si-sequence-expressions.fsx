let patrate = [ for i in 1 .. 10 -> i * i ]
printfn "Pătrate: %A" patrate

let pareSubForma = [ for i in 1 .. 20 do if i % 2 = 0 then yield i ]
printfn "Pare: %A" pareSubForma
