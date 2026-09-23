let calculeazaTVA procent pret =
    pret * (1.0 + procent / 100.0)

let tvaRomania = calculeazaTVA 21.0
let tvaUngaria = calculeazaTVA 27.0
let tvaGermania = calculeazaTVA 19.0

printfn "Preț 100 RON cu TVA România: %.2f" (tvaRomania 100.0)
printfn "Preț 100 EUR cu TVA Ungaria: %.2f" (tvaUngaria 100.0)
printfn "Preț 250 EUR cu TVA Germania: %.2f" (tvaGermania 250.0)
