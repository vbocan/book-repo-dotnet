// Generarea tripletelor pitagoreice
let tripletePitagoreice limit =
    seq {
        for a in 1 .. limit do
            for b in a .. limit do
                let cPatrat = a * a + b * b
                let c = int (sqrt (float cPatrat))
                if c * c = cPatrat && c <= limit then
                    yield (a, b, c)
    }

printfn "Triplete pitagoreice (1..20):"
tripletePitagoreice 20
|> Seq.iter (fun (a, b, c) -> printfn "  %d² + %d² = %d²  (%d + %d = %d)" a b c (a*a) (b*b) (c*c))
