// O funcție care ia altă funcție ca parametru
let aplicaDeDouaOri f x = f (f x)

// Funcții simple
let dubleaza n = n * 2
let incrementeaza n = n + 1

// Transmiterea funcțiilor ca argumente
printfn $"Dublează de două ori 3: {aplicaDeDouaOri dubleaza 3}"
printfn $"Incrementează de două ori 10: {aplicaDeDouaOri incrementeaza 10}"
