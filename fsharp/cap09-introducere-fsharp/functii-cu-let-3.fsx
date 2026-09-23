let calculeazaStatistici note =
    let suma = List.sum note
    let numar = List.length note
    let media = float suma / float numar
    let maxim = List.max note
    let minim = List.min note
    (media, minim, maxim)

let (media, minim, maxim) = calculeazaStatistici [8; 9; 10; 7; 6; 9]
printfn $"Media: {media:F2}, Min: {minim}, Max: {maxim}"
