type ArboreBinar<'T> =
    | Frunza
    | Nod of valoare: 'T * stanga: ArboreBinar<'T> * dreapta: ArboreBinar<'T>

let arbore =
    Nod(5,
        Nod(3,
            Nod(1, Frunza, Frunza),
            Nod(4, Frunza, Frunza)),
        Nod(8,
            Nod(7, Frunza, Frunza),
            Nod(9, Frunza, Frunza)))

let rec parcurgereInOrdine arbore =
    match arbore with
    | Frunza -> []
    | Nod(valoare, stanga, dreapta) ->
        parcurgereInOrdine stanga @ [ valoare ] @ parcurgereInOrdine dreapta

let rec cautaInArbore valoare arbore =
    match arbore with
    | Frunza -> false
    | Nod(v, stanga, dreapta) ->
        if valoare = v then true
        elif valoare < v then cautaInArbore valoare stanga
        else cautaInArbore valoare dreapta

printfn "Parcurgere in-ordine: %A" (parcurgereInOrdine arbore)
printfn "Caut 4: %b" (cautaInArbore 4 arbore)
printfn "Caut 6: %b" (cautaInArbore 6 arbore)
