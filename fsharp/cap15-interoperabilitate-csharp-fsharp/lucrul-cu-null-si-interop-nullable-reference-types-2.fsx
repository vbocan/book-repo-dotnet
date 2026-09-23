// Option.ofObj: convertește null la None, non-null la Some
// Option.toObj: convertește Some la valoare, None la null

let procesareText (text: string) =
    text
    |> Option.ofObj
    |> Option.map (fun s -> s.Trim().ToUpper())
    |> Option.defaultValue "(gol)"

printfn "%s" (procesareText "  salut  ")
printfn "%s" (procesareText null)
