open System.Collections.Generic

let dictionar = Dictionary<string, string>()
dictionar["ro"] <- "Română"
dictionar["en"] <- "Engleză"

// TryGetValue returnează (bool * string) — pattern tipic .NET
let exista, valoare = dictionar.TryGetValue("ro")
if exista then
    printfn "Găsit: %s" valoare
else
    printfn "Negăsit"

// Abordarea funcțională: dict.TryGetValue convertit la Option
let cautaLimba (cod: string) =
    match dictionar.TryGetValue(cod) with
    | true, valoare -> Some valoare
    | false, _ -> None

let afiseazaLimba cod =
    cod
    |> cautaLimba
    |> Option.defaultValue "(necunoscută)"
    |> printfn "Limba '%s': %s" cod

afiseazaLimba "ro"
afiseazaLimba "fr"
