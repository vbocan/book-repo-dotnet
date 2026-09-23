// Frecvența cuvintelor
let text = "ana are mere ana are pere maria are mere"

let frecvente =
    text.Split(' ')
    |> Array.fold (fun (acc: Map<string, int>) cuvant ->
        let count = acc |> Map.tryFind cuvant |> Option.defaultValue 0
        acc |> Map.add cuvant (count + 1)
    ) Map.empty

printfn "Frecvența cuvintelor:"
frecvente |> Map.iter (fun cuvant count -> printfn "  %-8s: %d" cuvant count)
