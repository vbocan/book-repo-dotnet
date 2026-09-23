type OptionBuilder() =
    member _.Bind(opt, f) =
        match opt with
        | Some v -> f v
        | None -> None
    member _.Return(value) = Some value
    member _.ReturnFrom(opt) = opt

let option = OptionBuilder()

let cautaProdus cod inventar =
    inventar |> Map.tryFind cod

let inventar = Map.ofList [("A01", "Laptop"); ("A02", "Mouse"); ("A03", "Tastatură")]
let preturi = Map.ofList [("Laptop", 3500.0); ("Mouse", 75.0)]

let pretProdus cod =
    option {
        let! numeProdus = cautaProdus cod inventar
        let! pret = preturi |> Map.tryFind numeProdus
        return $"{numeProdus}: {pret} RON"
    }

printfn "%A" (pretProdus "A01")
printfn "%A" (pretProdus "A02")
printfn "%A" (pretProdus "A03")
printfn "%A" (pretProdus "A99")
