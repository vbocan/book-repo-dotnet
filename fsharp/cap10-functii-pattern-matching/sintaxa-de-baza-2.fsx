let clasificaVarsta varsta =
    match varsta with
    | 0 -> "nou-născut"
    | v when v < 0 -> "vârstă invalidă"
    | v when v < 18 -> $"minor ({v} ani)"
    | v when v < 65 -> $"adult ({v} ani)"
    | v -> $"senior ({v} ani)"

printfn "%s" (clasificaVarsta 0)
printfn "%s" (clasificaVarsta -5)
printfn "%s" (clasificaVarsta 12)
printfn "%s" (clasificaVarsta 35)
printfn "%s" (clasificaVarsta 70)
