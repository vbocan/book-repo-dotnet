// Funcția returnează automat valoarea ultimei expresii
let clasificare varsta =
    if varsta < 18 then "Minor"
    elif varsta < 65 then "Adult"
    else "Senior"

printfn $"25 de ani: {clasificare 25}"
printfn $"12 ani: {clasificare 12}"
printfn $"70 de ani: {clasificare 70}"
