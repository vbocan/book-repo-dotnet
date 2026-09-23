// Valoare
let pi = 3.14159

// Funcție cu un parametru
let patrat x = x * x

// Funcție cu doi parametri
let aduna x y = x + y

// Funcție cu trei parametri
let volumCilindru raza inaltime =
    pi * patrat raza * inaltime

printfn $"π = {pi}"
printfn $"Pătratul lui 5: {patrat 5.0}"
printfn $"3 + 7 = {aduna 3 7}"
printfn $"Volum cilindru (r=3, h=10): {volumCilindru 3.0 10.0:F2}"
