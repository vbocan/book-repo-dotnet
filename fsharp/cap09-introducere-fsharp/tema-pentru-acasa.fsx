// Tema 1 — Convertor de temperaturi
// Capitolul 9: Introducere în F#
// Rulare: dotnet fsi fsharp/cap09-introducere-fsharp/tema-pentru-acasa.fsx

// Funcții pure de conversie
let celsiusLaFahrenheit (c: float) : float = c * 9.0 / 5.0 + 32.0
let fahrenheitLaCelsius (f: float) : float = (f - 32.0) * 5.0 / 9.0
let celsiusLaKelvin (c: float) : float = c + 273.15
let kelvinLaCelsius (k: float) : float = k - 273.15

// Conversii obținute prin compunerea funcțiilor anterioare
let fahrenheitLaKelvin : float -> float = fahrenheitLaCelsius >> celsiusLaKelvin
let kelvinLaFahrenheit : float -> float = kelvinLaCelsius >> celsiusLaFahrenheit

printfn "=== Convertor de temperaturi ==="

printfn "\nCelsius → Fahrenheit:"
for c in [ 0.0; 20.0; 37.0; 100.0 ] do
    printfn "  %.1f°C = %.2f°F" c (celsiusLaFahrenheit c)

printfn "\nFahrenheit → Celsius:"
for f in [ 32.0; 72.0; 98.6; 212.0 ] do
    printfn "  %.1f°F = %.2f°C" f (fahrenheitLaCelsius f)

printfn "\nCelsius → Kelvin:"
for c in [ -273.15; 0.0; 25.0; 100.0 ] do
    printfn "  %.2f°C = %.2f K" c (celsiusLaKelvin c)

printfn "\nKelvin → Fahrenheit:"
for k in [ 0.0; 273.15; 310.15; 373.15 ] do
    printfn "  %.2f K = %.2f°F" k (kelvinLaFahrenheit k)

// Verificare: fahrenheitLaKelvin 32°F trebuie să dea 273.15 K
assert (abs (fahrenheitLaKelvin 32.0 - 273.15) < 1e-9)
