[<Measure>] type m
[<Measure>] type km
[<Measure>] type s
[<Measure>] type h    // ore

let kmPerOra_la_mPerSecunda (v: float<km/h>) : float<m/s> =
    v * 1000.0<m/km> / 3600.0<s/h>

let vitezaMasina = 90.0<km/h>
let vitezaSI = kmPerOra_la_mPerSecunda vitezaMasina

printfn "Viteza: %.1f km/h = %.2f m/s" (float vitezaMasina) (float vitezaSI)
