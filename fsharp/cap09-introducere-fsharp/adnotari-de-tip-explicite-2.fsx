// Fără adnotare, compilatorul nu știe ce supraîncărcare a lui .ToString să aleagă
let formatare (valoare : float) =
    valoare.ToString("F2")  // Acum compilatorul știe că e System.Double

printfn $"Formatat: {formatare 3.14159}"
