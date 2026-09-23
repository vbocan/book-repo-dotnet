// Corect: corpul funcției este indentat
let calculeazaMedia note =
    let suma = List.sum note
    let numar = List.length note
    float suma / float numar

printfn $"Media: {calculeazaMedia [8; 9; 10; 7]}"
