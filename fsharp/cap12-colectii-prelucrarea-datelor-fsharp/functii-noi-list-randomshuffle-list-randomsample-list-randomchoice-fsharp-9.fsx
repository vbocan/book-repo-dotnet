let carti = ["As"; "Rege"; "Damă"; "Valet"; "10"; "9"; "8"; "7"]

// Amestecă toată lista (Fisher-Yates shuffle)
let amestecate = carti |> List.randomShuffle
printfn "Amestecate: %A" amestecate

// Selectează 3 elemente aleatorii (fără repetiție)
let selectie = carti |> List.randomSample 3
printfn "Selecție de 3: %A" selectie

// Alege un singur element aleatoriu
let oCarteDinPachet = carti |> List.randomChoice
printfn "O carte: %s" oCarteDinPachet
