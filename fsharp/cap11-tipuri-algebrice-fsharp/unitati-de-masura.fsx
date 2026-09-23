[<Measure>] type m      // metri
[<Measure>] type s      // secunde
[<Measure>] type kg     // kilograme

let distanta = 100.0<m>
let timp = 9.58<s>
let masa = 75.0<kg>

let viteza = distanta / timp   // float<m/s>
printfn "Viteza: %.2f m/s" (float viteza)

let acceleratia = viteza / timp  // float<m/s^2>
printfn "Accelerația: %.4f m/s²" (float acceleratia)

let forta = masa * acceleratia   // float<kg m/s^2> = Newton
printfn "Forța: %.2f N" (float forta)
