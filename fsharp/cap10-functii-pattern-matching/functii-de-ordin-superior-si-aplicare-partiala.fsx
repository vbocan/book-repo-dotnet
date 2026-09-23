let numere = [1 .. 10]

// map, filter, fold
let patrate = numere |> List.map (fun x -> x * x)
let pare = numere |> List.filter (fun x -> x % 2 = 0)
let suma = numere |> List.fold (fun acc x -> acc + x) 0
printfn "Pătrate: %A" patrate
printfn "Pare: %A" pare
printfn "Suma: %d" suma

// Pipeline: suma pătratelor numerelor impare
let rezultat =
    numere
    |> List.filter (fun x -> x % 2 <> 0)
    |> List.map (fun x -> x * x)
    |> List.fold (fun acc x -> acc + x) 0
printfn "Suma pătratelor impare: %d" rezultat

// Aplicare parțială: funcții financiare
let adaugaTaxa procent pret = pret * (1.0 + procent / 100.0)
let formateazaMoneda simbol (v: float) = $"{v:N2} {simbol}"

let adaugaTVA = adaugaTaxa 21.0
let formateazaRON = formateazaMoneda "RON"
let calculeazaSiFormateaza = adaugaTVA >> formateazaRON

[100.0; 250.0; 500.0]
|> List.map calculeazaSiFormateaza
|> List.iter (printfn "  %s")
