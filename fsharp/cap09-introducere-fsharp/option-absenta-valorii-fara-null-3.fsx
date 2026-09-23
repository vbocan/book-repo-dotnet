let imparteSigur a b =
    if b = 0 then None
    else Some (a / b)

// Utilizare cu pattern matching
let afiseazaImpartire a b =
    match imparteSigur a b with
    | Some rezultat -> printfn $"{a} / {b} = {rezultat}"
    | None -> printfn $"{a} / {b} — împărțire la zero!"

afiseazaImpartire 10 3
afiseazaImpartire 10 0
afiseazaImpartire 15 5
