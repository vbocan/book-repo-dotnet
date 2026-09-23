let descrieLista lista =
    match lista with
    | [] -> "lista vidă"
    | [x] -> $"un singur element: {x}"
    | [x; y] -> $"două elemente: {x} și {y}"
    | x :: _ -> $"lista începe cu {x} și are mai multe elemente"

printfn "%s" (descrieLista [])
printfn "%s" (descrieLista [42])
printfn "%s" (descrieLista [10; 20; 30; 40])
