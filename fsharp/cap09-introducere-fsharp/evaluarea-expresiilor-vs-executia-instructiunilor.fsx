// F# — if-then-else ca expresie
let temperatura = 22
let mesaj = if temperatura > 30 then "Cald" elif temperatura > 15 then "Plăcut" else "Frig"
printfn $"Temperatura: {temperatura}°C — {mesaj}"
